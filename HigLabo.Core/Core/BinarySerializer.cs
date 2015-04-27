using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HigLabo.Core
{
    public class BinarySerializer
    {
        public Byte[] Serialize(Object o)
        {
            if (o == null) return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, o);
                return memoryStream.ToArray();
            }
        }
        public T Deserialize<T>(Byte[] stream)
        {
            if (stream == null) return default(T);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(stream))
            {
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
