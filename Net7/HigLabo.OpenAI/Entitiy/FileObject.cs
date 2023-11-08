using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class FileObject
    {
        public string Id { get; set; } = "";
        public int Bytes { get; set; }
        public int CreateAt { get; set; }
        public string FileName { get; set; } = "";
        public string Object { get; set; } = "";
        public string Purpose { get; set; } = "";
    }
    public class FileObjectResponse: RestApiResponse
    {
        public string Id { get; set; } = "";
        public int Bytes { get; set; }
        public int CreateAt { get; set; }
        public string FileName { get; set; } = "";
        public string Purpose { get; set; } = "";
    }
}
