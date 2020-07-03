using System;
using System.IO;

namespace HigLabo.Core
{
    public static class StreamExtensions
    {
        public static Byte[] ToByteArray(this Stream stream)
        {
            var mm = new MemoryStream();
            stream.CopyTo(mm);
            return mm.ToArray();
        }
        public static void Write(this Stream stream, Byte[] data)
        {
            stream.Write(data, 0, data.Length);
        }
        public static void CopyTo(this Stream source, Stream target)
        {
            var bb = new Byte[source.Length];
            source.Read(bb, 0, bb.Length);
            target.Write(bb, 0, bb.Length);
        }
    }
}
