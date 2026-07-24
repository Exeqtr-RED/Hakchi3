using com.clusterrr.hakchi_gui.Properties;
using System.Collections.Generic;
using System.IO;

namespace com.clusterrr.hakchi_gui
{
    public class LicenseInfo : TextInfo
    {
        public LicenseInfo() : base()
        {
            this.Text = Resources.LicenseInformation;
            var licenses = new List<string>();

            using (var licenseMs = new MemoryStream(Properties.Resources.LicensesTar))
            using (var archive = SharpCompress.Archives.Tar.TarArchive.OpenArchive(licenseMs))
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.IsDirectory) continue;
                    using (var entryStream = entry.OpenEntryStream())
                    using (var sr = new StreamReader(entryStream))
                    {
                        var license = sr.ReadToEnd();
                        if (license.Length > 0)
                        {
                            licenses.Add(license);
                        }
                    }
                }
            }

            licenses.Sort();

            textBoxInfo.Text = string.Join("\n--------------------------------------------------------------------------------\n", licenses.ToArray()).Replace("\r", "").Replace("\n", "\r\n");
        }
    }
}