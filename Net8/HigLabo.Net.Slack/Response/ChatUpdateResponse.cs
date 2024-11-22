using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack;

public partial class ChatUpdateResponse
{
    public string? Channel { get; set; }
    public string? Ts { get; set; }
    public string? Text { get; set; }
    public Message? Message { get; set; }
}
