using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public interface IFileParameter
    {
        string ParameterName { get; }
        string FileName { get; set; }
        Stream GetFileStream();
        void SetFile(string fileName, Stream stream);
    }
    public static class IFileParameterExtensions
    {
        public static void SetFile(this IFileParameter parameter, string fileName, byte[] data)
        {
            var p = parameter;
            p.SetFile(fileName, new MemoryStream(data));
        }
    }
}
