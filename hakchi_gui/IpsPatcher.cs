using System;
using System.IO;
using System.Text;

namespace com.clusterrr.hakchi_gui
{
    public static class IpsPatcher
    {
        public static void Patch(byte[] patch, ref byte[] data)
        {
            if (patch == null) throw new ArgumentNullException(nameof(patch));
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (patch.Length < 5 || Encoding.ASCII.GetString(patch, 0, 5) != "PATCH")
                throw new Exception("Invalid IPS file");

            int pos = 5;
            // IPS records are addressed by a 24-bit offset. The 'EOF' marker is the
            // 3-byte value 0x454F46 ('E','O','F') and terminates the patch.
            const uint IPS_EOF = 0x454F46;

            while (pos + 3 <= patch.Length)
            {
                UInt32 address = (UInt32)(patch[pos + 2] | patch[pos + 1] * 0x100 | patch[pos] * 0x10000);
                // Stop at the EOF marker.
                if (address == IPS_EOF) break;
                if (pos + 5 > patch.Length) break;
                UInt16 length = (UInt16)(patch[pos + 4] | patch[pos + 3] * 0x100);
                pos += 5;
                if (length > 0)
                {
                    EnsureCapacity(ref data, address + length);
                    while (length > 0)
                    {
                        if (pos >= patch.Length) break;
                        data[address] = patch[pos];
                        address++;
                        pos++;
                        length--;
                    }
                }
                else
                {
                    if (pos + 3 > patch.Length) break;
                    length = (UInt16)(patch[pos + 1] | patch[pos] * 0x100);
                    var b = patch[pos + 2];
                    pos += 3;
                    EnsureCapacity(ref data, address + length);
                    while (length > 0)
                    {
                        data[address] = b;
                        address++;
                        length--;
                    }
                }
            }
        }

        // Grow 'data' so index (target-1) is writable. Avoids the previous
        // data.Length*2 strategy which infinite-loops when data.Length == 0.
        private static void EnsureCapacity(ref byte[] data, uint target)
        {
            if (data == null) { data = new byte[target]; return; }
            if (target <= data.Length) return;
            int newLen = data.Length;
            if (newLen == 0) newLen = 1;
            while (newLen < target) newLen *= 2;
            Array.Resize(ref data, newLen);
        }

        public static void Patch(string patchFile, ref byte[] data)
        {
            Patch(File.ReadAllBytes(patchFile), ref data);
        }

        public static void Patch(string patchFile, string inFile, string outFile)
        {
            var patch = File.ReadAllBytes(patchFile);
            var data = File.ReadAllBytes(inFile);
            Patch(patch, ref data);
            File.WriteAllBytes(outFile, data);
        }
    }
}
