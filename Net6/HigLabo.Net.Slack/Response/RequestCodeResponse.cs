using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class RequestCodeResponse : RestApiResponse
    {
        public class IdName
        {
            public string Name { get; set; } = "";
            public string Id { get; set; } = "";
        }
        public class User
        {
            public string Id { get; set; } = "";
            public string Scope { get; set; } = "";
            public string Access_Token { get; set; } = "";
            public string Refresh_Token { get; set; } = "";
            public string Token_Type { get; set; } = "";
        }
        public string Access_Token { get; set; } = "";
        public string Refresh_Token { get; set; } = "";
        public int Expires_In { get; set; }
        public string Token_Type { get; set; } = "";

        public string Scope { get; set; } = "";
        public string Bot_User_Id { get; set; } = "";
        public string App_Id { get; set; } = "";
        public IdName Team { get; set; }
        public IdName Enterprise { get; set; }
        public User Authed_User { get; set; }
    }
}
