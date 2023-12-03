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
        /// <summary>
        /// The intended purpose of the file. Supported values are fine-tune, fine-tune-results, assistants, and assistants_output.
        /// </summary>
        public string Purpose { get; set; } = "";

        public override string ToString()
        {
            return $"{this.Id} {this.FileName}";
        }
    }
    public class FileObjectResponse: RestApiResponse
    {
        public string Id { get; set; } = "";
        public int Bytes { get; set; }
        public int CreateAt { get; set; }
        public string FileName { get; set; } = "";
        public string Purpose { get; set; } = "";

        public override string ToString()
        {
            return $"{this.Id} {this.FileName}";
        }
    }
}
