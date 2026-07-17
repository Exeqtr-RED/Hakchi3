using com.clusterrr.ssh;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace com.clusterrr.hakchi_gui.SshClient
{
    public class DnsListener(string name) : IListener
    {
        public const int TTL = 60;
        public const int TTR = 15;

        private readonly string serviceName = name;
        private readonly List<Device> devices = [];
        private DateTime lastUpdated = DateTime.Now.Subtract(TimeSpan.FromSeconds(TTL));
        private DateTime lastChecked = DateTime.Now;

        public IList<Device> Available
        {
            get
            {
                if (DateTime.Now.Subtract(lastChecked) > TimeSpan.FromSeconds(TTR))
                {
                    lastChecked = DateTime.Now;
                    Query();
                }
                return devices;
            }
        }

        private void Query()
        {
            if (DateTime.Now.Subtract(lastUpdated) > TimeSpan.FromSeconds(TTL))
            {
                devices.Clear();
                try
                {
                    IPHostEntry ihe = Dns.GetHostEntry(serviceName);
                    if (ihe.AddressList != null && ihe.AddressList.Length > 0)
                    {
                        Trace.WriteLine("DNS Resolution returned IPs: " + string.Join(", ", (IEnumerable<IPAddress>)ihe.AddressList));
                        lastUpdated = DateTime.Now;
                        foreach (var address in ihe.AddressList)
                            devices.Add(new Device() { Addresses = [address], Port = SshClientWrapper.DEFAULT_SSH_PORT });
                    }
                }
                catch
                {
                    // no-op (dns resolution fail causes exception)
                }
            }
        }

        public void Cycle()
        {
            devices.Clear();
        }

        public void Dispose()
        {
            devices.Clear();
            GC.SuppressFinalize(this);
        }
    }
}