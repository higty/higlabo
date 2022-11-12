using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HigLabo.Core
{
    public static class AssemblyExtensions
    {
        public static String GetManifestResourceText(this Assembly assembly, String name)
        {
            return assembly.GetManifestResourceText(name, Encoding.UTF8);
        }
        public static String GetManifestResourceText(this Assembly assembly, String name, Encoding encoding)
        {
            var bb = assembly.GetManifestResourceStream(name).ToByteArray();
            if (bb.HasUTF8ByteOrderMark())
            {
                return encoding.GetString(bb.Skip(3).ToArray());
            }
            return encoding.GetString(bb);
        }
    }
}
