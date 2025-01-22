using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class AdminApiKeyOwner
{
    public string Type { get; set; } = "";
    public string Object { get; set; } = "";
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public long Created_At { get; set; }
    public string Role { get; set; } = "";
}
