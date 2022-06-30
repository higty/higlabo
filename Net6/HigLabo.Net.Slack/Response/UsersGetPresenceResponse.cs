using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public partial class UsersGetPresenceResponse
    {
        public string Presence { get; set; }
        public bool Online { get; set; }
        public bool Auto_Away { get; set; }
        public bool Manual_Away { get; set; }
        public int Connection_Count { get; set; }
        public int Last_Activity { get; set; }
    }
}
