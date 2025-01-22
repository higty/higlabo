using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack;

public partial class Paging
{
    public Int32 Count { get; set; }
    public Int32 Total { get; set; }
    public Int32 Page { get; set; }
    public Int32 Pages { get; set; }
}
