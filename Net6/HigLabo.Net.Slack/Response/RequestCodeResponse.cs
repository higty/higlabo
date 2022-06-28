using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class RequestCodeResponse : HigLabo.Net.OAuth.RequestCodeResponse
    {
        public class IdName
        {
            public String Name { get; set; } = "";
            public String Id { get; set; } = "";
        }
        public class User
        {
            public String Id { get; set; } = "";
            public String Scope { get; set; } = "";
            public String Access_Token { get; set; } = "";
            public String Token_Type { get; set; } = "";
        }

        public Boolean Ok { get; set; }
        public String Scope { get; set; } = "";
        public String Bot_User_Id { get; set; } = "";
        public String App_Id { get; set; } = "";
        public IdName Team { get; set; }
        public IdName Enterprise { get; set; }
        public User Authed_User { get; set; }
    }
}
