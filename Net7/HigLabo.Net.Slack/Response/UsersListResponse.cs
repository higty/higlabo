using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public partial class UsersListResponse : RestApiResponse
    {
        public User[] Members { get; set; }
        public Int32 Cache_Ts { get; set; }
    }
}
