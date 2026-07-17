using System.Collections.Generic;

namespace com.clusterrr.hakchi_gui.SshClient
{
    public interface IListener
    {
        IList<Device> Available { get; }
        void Cycle();
        void Dispose();
    }
}