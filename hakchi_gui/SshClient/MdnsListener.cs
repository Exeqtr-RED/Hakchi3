using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Tmds.MDns;

namespace com.clusterrr.hakchi_gui.SshClient
{
    public class MdnsListener : IListener
    {
        private readonly ServiceBrowser serviceBrowser;
        private readonly string serviceName;
        private readonly string serviceType;

        public IList<Device> Available { get; }

        public MdnsListener(string name, string type)
        {
            serviceName = name;
            serviceType = type;
            Available = new List<Device>();

            // enable service browser
            serviceBrowser = new ServiceBrowser();
            serviceBrowser.ServiceAdded += OnServiceAdded;
            serviceBrowser.ServiceChanged += OnServiceChanged;
            serviceBrowser.ServiceRemoved += OnServiceRemoved;
            serviceBrowser.StartBrowse(type);
        }

        public void Cycle()
        {
            // no-op
        }

        public void Dispose()
        {
            serviceBrowser.StopBrowse();
            Available.Clear();
            GC.SuppressFinalize(this);
        }

        // ИСПРАВЛЕНО: Метод сделан static (предупреждение CA1822)
        private static void DebugAnnouncement(string header, ServiceAnnouncement a)
        {
            Trace.WriteLine(header);
            Trace.Indent();
            Trace.WriteLine("Instance: " + a.Instance);
            Trace.WriteLine("Type: " + a.Type);
            Trace.WriteLine("IP: " + string.Join(", ", a.Addresses));
            Trace.WriteLine("Port: " + a.Port);
            Trace.WriteLine("Txt: " + string.Join(", ", a.Txt));
            Trace.Unindent();
        }

        private void OnServiceAdded(object sender, ServiceAnnouncementEventArgs e)
        {
            if (e.Announcement.Instance != serviceName) return;

            DebugAnnouncement("Service added:", e.Announcement);

            var dev = new Device()
            {
                Addresses = e.Announcement.Addresses,
                Port = e.Announcement.Port,
            };

            foreach (var txt in e.Announcement.Txt)
            {
                var tokens = txt.Split('=');
                if (tokens.Length == 2)
                {
                    switch (tokens[0])
                    {
                        case "hwid":
                            dev.UniqueID = tokens[1].Replace(" ", "").ToUpper();
                            break;
                        case "type":
                            dev.ConsoleType = tokens[1];
                            break;
                        case "region":
                            dev.ConsoleRegion = tokens[1];
                            break;
                    }
                }
            }

            foreach (var a in Available)
            {
                if (dev.Addresses.SequenceEqual(e.Announcement.Addresses))
                {
                    Trace.WriteLine("Duplicate announce for addresses: " + string.Join(", ", e.Announcement.Addresses));
                    return;
                }
                if (dev.UniqueID == a.UniqueID)
                {
                    Trace.WriteLine("Duplicate announce for same device: " + a.UniqueID);
                    return;
                }
            }

            Available.Add(dev);
        }

        private void OnServiceChanged(object sender, ServiceAnnouncementEventArgs e)
        {
            if (e.Announcement.Instance != serviceName) return;
            DebugAnnouncement("A service changed:", e.Announcement);
        }

        private void OnServiceRemoved(object sender, ServiceAnnouncementEventArgs e)
        {
            if (e.Announcement.Instance != serviceName) return;
            DebugAnnouncement("A service was removed:", e.Announcement);

            foreach (var a in Available)
            {
                if (a.Addresses.SequenceEqual(e.Announcement.Addresses))
                {
                    Available.Remove(a);
                    return;
                }
            }
            Trace.WriteLine("Service had not been detected before. Hmmm...");
        }
    }
}