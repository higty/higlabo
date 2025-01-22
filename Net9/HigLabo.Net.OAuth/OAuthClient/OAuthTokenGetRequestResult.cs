using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth;

public class OAuthTokenGetRequestResult
{
    public String Access_Token { get; set; } = "";
    public String Refresh_Token { get; set; } = "";
    public Int32 Expires_In { get; set; }
    public String Token_Type { get; set; } = "";
}
