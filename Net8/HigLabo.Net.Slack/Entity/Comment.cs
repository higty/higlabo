using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack;

public partial class SlackComment
{
    public string? Type { get; set; }
    public string? Comment { get; set; }
    public Int32 Created { get; set; }
    public string? Id { get; set; }
    public Reaction[]? Reactions { get; set; }
    public Int32 Timestamp { get; set; }
    public string? User { get; set; }
}
