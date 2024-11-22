using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack;

public partial class SearchFilesResponse
{
    public SearchFiles? Files { get; set; }
    public string? Query { get; set; }
}
