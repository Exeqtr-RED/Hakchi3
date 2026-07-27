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
            using (var reader = SharpCompress.Readers.ReaderFactory.OpenReader(licenseMs))
            {
                while (reader.MoveToNextEntry())
                {
                    if (reader.Entry.IsDirectory) continue;
                    using (var ms = new MemoryStream())
                    {
                        reader.WriteEntryTo(ms);
                        ms.Position = 0;
                        using (var sr = new StreamReader(ms))
                        {
                            var license = sr.ReadToEnd();
                            if (license.Length > 0)
                            {
                                licenses.Add(license);
                            }
                        }
                    }
                }
            }

            licenses.Sort();

            textBoxInfo.Text = string.Join("\n--------------------------------------------------------------------------------\n", licenses.ToArray()).Replace("\r", "").Replace("\n", "\r\n");
        }
    }
}