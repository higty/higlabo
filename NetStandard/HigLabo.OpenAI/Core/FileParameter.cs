using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace HigLabo.OpenAI
{
    public interface IFileParameter
    {
        IEnumerable<FileParameter> GetFileParameters();
    }

    public class FileParameter
    {
        private Stream? _Stream = null;

        public string Name { get; private set; } = "";
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
