using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public partial class FilesListResponse
    {
        public File[]? Files { get; set; }
        public Paging? Paging { get; set; }
    }
}
