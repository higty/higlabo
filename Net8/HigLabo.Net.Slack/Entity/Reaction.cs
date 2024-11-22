using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack;

public class Reaction
{
    public Int32 Count { get; set; }
    public string? Name { get; set; }
    public string[]? Users { get; set; }
}
