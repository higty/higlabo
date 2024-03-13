using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HigLabo.OpenAI
{
    public interface IFileParameter
    {
        IEnumerable<FileParameter> GetFileParameters();
    }

    public class FileParameter
    {
        private Stream? _Stream = null;

        public string Name { get; init; } = "";
        public string? FileName { get; set; }

        public FileParameter(string name)
        {
            this.Name = name;
        }

        public Stream? GetFileStream()
        {
            return _Stream;
        }
        public void SetFile(string fileName, Byte[] data)
        {
            this.SetFile(fileName, new MemoryStream(data));
        }
        public void SetFile(string fileName, Stream stream)
        {
            this.FileName = fileName;
            _Stream = stream;
        }

    }
}
