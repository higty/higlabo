using System;
using System.Collections.Generic;
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
}
