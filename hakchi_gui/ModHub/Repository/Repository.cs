using com.clusterrr.hakchi_gui.Properties;
using com.clusterrr.hakchi_gui.Tasks;
using com.clusterrr.util;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static com.clusterrr.hakchi_gui.Tasks.Tasker;

namespace com.clusterrr.hakchi_gui.ModHub.Repository
{
    public delegate void RepositoryProgressHandler(long current, long max);
    public delegate void RepositoryLoadedHandler(Repository.Item[] items);

    public static class ItemKindMethods
    {
        public static string GetFileExtension(this Repository.ItemKind kind)
        {
            return Repository.ItemKindFileExtensions[(int)kind];
        }
    }

    public class Repository
    {
        public event RepositoryProgressHandler RepositoryProgress;
        public event RepositoryLoadedHandler RepositoryLoaded;

        public string RepositoryURL { get; private set; }

        public string RepositoryPackURL => RepositoryURL + "pack.tgz";
        public string RepositoryListURL => RepositoryURL + "list";

        public List<Item> Items = new List<Item>();
        public string Readme { get; private set; } = null;

        public static readonly string[] ItemKindFileExtensions = { null, ".hmod", ".clvg" };

        public enum ItemKind
        {
            Unknown,
            Hmod,
            Game
        }

        private static readonly Regex RegexList =
            new Regex(@"^(?:\./)?list$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex RegexReadme =
            new Regex(@"^(?:\./)?readme\.md$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex RegexModMeta =
            new Regex(@"^(?:\./)?([^/]+)/(extract|link|md5|sha1|readme(?:\.(?:md|txt)?)?)$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static ItemKind ItemKindFromFilename(string filename)
        {
            string lowerFilename = filename.ToLower();
            foreach (ItemKind kind in Enum.GetValues(typeof(ItemKind)))
            {
                if (kind == ItemKind.Unknown)
                    continue;
                if (lowerFilename.EndsWith(kind.GetFileExtension()))
                    return kind;
            }
            return ItemKind.Unknown;
        }

        public class Item
        {
            public string FileName { get; private set; }
            public string RawName => FileName.EndsWith(".hmod") || FileName.EndsWith(".clvg")
                ? FileName.Substring(0, FileName.Length - 5) : FileName;
            public string CleanName => Kind == ItemKind.Hmod
                ? Hmod.Hmod.GetCleanName(RawName, true) : RawName;
            public string Name { get; private set; }
            public string Category { get; private set; }
            public string Creator { get; private set; }
            public string Version { get; private set; }
            public string EmulatedSystem { get; private set; }
            public string URL { get; private set; }
            public string MD5 { get; private set; }
            public string SHA1 { get; private set; }
            public bool Extract { get; private set; }
            public ItemKind Kind { get; private set; }
            public HmodReadme Readme { get; private set; }

            public Item(string filename, string readme = null, bool markdownReadme = false)
            {
                FileName = filename;
                Kind = ItemKindFromFilename(FileName);
                Name = RawName;
                Readme = new HmodReadme(readme ?? "", markdownReadme);
                setValues();
            }

            public void setURL(string url) { URL = url; }
            public void setMD5(string md5) { MD5 = md5; }
            public void setSHA1(string sha1) { SHA1 = sha1; }
            public void setExtract(bool extract) { Extract = extract; }
            public void setReadme(string readme, bool markdown = false)
            {
                Readme = new HmodReadme(readme, markdown);
                setValues();
            }

            private void setValues()
            {
                Name = Readme.frontMatter.ContainsKey("Name") ? Readme.frontMatter["Name"] : CleanName;
                Category = Readme.frontMatter.ContainsKey("Category") ? Readme.frontMatter["Category"] : null;
                Creator = Readme.frontMatter.ContainsKey("Creator") ? Readme.frontMatter["Creator"] : null;
                Version = Readme.frontMatter.ContainsKey("Version") ? Readme.frontMatter["Version"] : null;
                EmulatedSystem = Readme.frontMatter.ContainsKey("Emulated System") ? Readme.frontMatter["Emulated System"] : null;
            }
        }

        public Repository(string repositoryURL)
        {
            RepositoryURL = repositoryURL;
            if (!RepositoryURL.EndsWith("/"))
                RepositoryURL += "/";
            if (!RepositoryURL.EndsWith("/.repo/"))
                RepositoryURL += ".repo/";
        }

        private static string StreamToString(Stream stream)
        {
            if (stream.CanSeek)
                stream.Position = 0;
            using (var sr = new StreamReader(stream, Encoding.UTF8))
                return sr.ReadToEnd();
        }

        public void Load()
        {
            // Пытаемся загрузить pack.tgz (быстрый путь)
            if (TryLoadPack())
                return;

            // Фоллбэк: пофайловая загрузка
            LoadIndividual();
        }

        private bool TryLoadPack()
        {
            try
            {
                var repoResponse = HTTPHelpers.GetHTTPResponseStreamAsync(RepositoryPackURL).GetAwaiter().GetResult();

                if (repoResponse.Status != HttpStatusCode.OK)
                    return false;

                string[] list = new string[] { };
                var tempDict = new Dictionary<string, Item>();
                var trackableStream = new TrackableStream(repoResponse.Stream);

                trackableStream.OnProgress += (long current, long total) =>
                {
                    RepositoryProgress?.Invoke(current, repoResponse.Length);
                };

                using (var decompressedStream = new System.IO.Compression.GZipStream(
                    trackableStream, System.IO.Compression.CompressionMode.Decompress))
                using (var tarReader = new TarReader(decompressedStream))
                {
                    TarEntry entry;
                    while ((entry = tarReader.GetNextEntry()) != null)
                    {
                        if (entry.EntryType == TarEntryType.Directory)
                            continue;

                        string entryName = entry.Name;

                        if (RegexList.IsMatch(entryName))
                        {
                            list = Regex.Replace(
                                StreamToString(entry.DataStream),
                                @"[\r\n]+", "\n").Split('\n');
                        }

                        if (RegexReadme.IsMatch(entryName))
                        {
                            Readme = StreamToString(entry.DataStream);
                        }

                        var match = RegexModMeta.Match(entryName);
                        if (match.Success)
                        {
                            var mod = match.Groups[1].Value;
                            var fileName = match.Groups[2].Value;

                            if (!tempDict.TryGetValue(mod, out Item item))
                            {
                                item = new Item(mod);
                                tempDict.Add(mod, item);
                            }

                            switch (fileName.ToLower())
                            {
                                case "extract":
                                    item.setExtract(true);
                                    break;
                                case "link":
                                    item.setURL(StreamToString(entry.DataStream).Trim());
                                    break;
                                case "md5":
                                    item.setMD5(StreamToString(entry.DataStream).Trim());
                                    break;
                                case "sha1":
                                    item.setSHA1(StreamToString(entry.DataStream).Trim());
                                    break;
                                case "readme":
                                case "readme.txt":
                                case "readme.md":
                                    item.setReadme(
                                        StreamToString(entry.DataStream).Trim(),
                                        fileName.EndsWith(".md"));
                                    break;
                            }
                        }
                    }
                }

                if (list.Length == 0)
                    list = tempDict.Keys.ToArray();

                foreach (var key in tempDict.Keys.ToArray())
                {
                    if (list.Contains(key))
                        Items.Add(tempDict[key]);
                }

                tempDict.Clear();
                Items.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));
                RepositoryLoaded?.Invoke(Items.ToArray());
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Pack loading failed, falling back to individual: " + ex.Message);
                Items.Clear();
                return false;
            }
        }

        private void LoadIndividual()
        {
            var taskList = HTTPHelpers.GetHTTPResponseStringAsync(RepositoryListURL).GetAwaiter().GetResult();
            string[] list = (taskList ?? "").Split('\n');

            for (int i = 0; i < list.Length; i++)
            {
                string mod = list[i];
                if (string.IsNullOrWhiteSpace(mod))
                    continue;

                Item item = new Item(mod);

                var taskExtract = HTTPHelpers.GetHTTPStatusCodeAsync($"{RepositoryURL}{mod}/extract").GetAwaiter().GetResult();
                var taskURL = HTTPHelpers.GetHTTPResponseStringAsync($"{RepositoryURL}{mod}/link").GetAwaiter().GetResult();
                var taskMD5 = HTTPHelpers.GetHTTPResponseStringAsync($"{RepositoryURL}{mod}/md5").GetAwaiter().GetResult();
                var taskSHA1 = HTTPHelpers.GetHTTPResponseStringAsync($"{RepositoryURL}{mod}/sha1").GetAwaiter().GetResult();

                item.setExtract(taskExtract == HttpStatusCode.OK);
                item.setURL(taskURL);
                item.setMD5(taskMD5);
                item.setSHA1(taskSHA1);

                for (int x = 0; x < HmodReadme.readmeFiles.Length; x++)
                {
                    string readmeContent = HTTPHelpers
                        .GetHTTPResponseStringAsync($"{RepositoryURL}{mod}/{HmodReadme.readmeFiles[x]}")
                        .GetAwaiter().GetResult();

                    if (readmeContent != null)
                    {
                        item.setReadme(readmeContent, HmodReadme.readmeFiles[x].EndsWith(".md"));
                        break;
                    }
                }

                Items.Add(item);
                RepositoryProgress?.Invoke(i + 1, list.Length);
            }

            Items.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));
            RepositoryLoaded?.Invoke(Items.ToArray());
        }

        public Item[] LoadTasker(Form hostForm)
        {
            using (var tasker = new Tasks.Tasker(hostForm))
            {
                tasker.AttachViews(new TaskerTaskbar(), new TaskerForm());
                tasker.SetStatusImage(Resources.sign_cogs);
                tasker.SetTitle("Loading Repository");
                tasker.AddTask(LoadTask);
                if (tasker.Start() == Tasker.Conclusion.Success)
                    return Items.ToArray();
                return null;
            }
        }

        private Conclusion LoadTask(Tasker tasker, Object syncObject)
        {
            tasker.SetStatus("Loading...");
            RepositoryProgress += (long current, long max) =>
            {
                tasker.SetProgress(current, max);
            };
            Load();
            return Conclusion.Success;
        }
    }
}
