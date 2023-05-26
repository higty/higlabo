using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class User
    {
        public String Id { get; set; }
        public String Team_Id { get; set; }
        public String Name { get; set; }
        public Boolean Deleted { get; set; }
        public String Color { get; set; }
        public String Real_Name { get; set; }
        public String Tz { get; set; }
        public String Tz_Label { get; set; }
        public Int32 Tz_Offset { get; set; }
        public Profile Profile { get; set; }
        public Boolean Is_Admin { get; set; }
        public Boolean Is_Owner { get; set; }
        public Boolean Is_Primary_Owner { get; set; }
        public Boolean Is_Restricted { get; set; }
        public Boolean Is_Ultra_restricted { get; set; }
        public Boolean Is_Bot { get; set; }
        public Boolean Is_Stranger { get; set; }
        public Int64 Updated { get; set; }
        public Boolean Is_App_User { get; set; }
        public Boolean Is_Invited_User { get; set; }
        public Boolean Has_2fa { get; set; }
        public String Locale { get; set; }
    }
}
