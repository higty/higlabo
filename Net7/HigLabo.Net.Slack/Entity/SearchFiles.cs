using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class SearchFiles
    {
        public SearchFile[]? Matches { get; set; }
        public Pagination? Pagination { get; set; }
        public Paging? Paging { get; set; }
        public Int32 Total { get; set; }
    }
}
