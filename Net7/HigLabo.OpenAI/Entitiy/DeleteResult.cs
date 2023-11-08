using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class DeleteResult
    {
        public string Id { get; set; } = "";
        public string Object { get; set; } = "";
        public bool Deleted { get; set; }
    }
}
