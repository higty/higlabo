using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class Pagination
    {
        public Int32 First { get; set; }
        public Int32 Last { get; set; }
        public Int32 Page { get; set; }
        public Int32 Page_Count { get; set; }
        public Int32 Per_Page { get; set; }
        public Int32 Total_Count { get; set; }
    }
}
