using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack;

public class SearchMessage
{
    public class SearchMessageNext
    {
        public string? Iid { get; set; }
        public string? Text { get; set; }
        public string? Ts { get; set; }
        public string? Type { get; set; }
        public string? User { get; set; }
        public string? UserName { get; set; }
    }

    public class SearchMessagePrevious
    {
        public string? Iid { get; set; }
        public string? Text { get; set; }
        public string? Ts { get; set; }
        public string? Type { get; set; }
        public string? User { get; set; }
        public string? UserName { get; set; }
    }

    public Channel? Channel { get; set; }
    public string? Iid { get; set; }
    public SearchMessageNext? Next { get; set; }
    public string? Permalink { get; set; }
    public SearchMessagePrevious? Previous { get; set; }
    public string? Team { get; set; }
    public string? Text { get; set; }
    public string? Ts { get; set; }
    public string? Type { get; set; }
    public string? User { get; set; }
    public string? UserName { get; set; }
}
