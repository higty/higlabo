using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class Conversation
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public Boolean Is_Channel { get; set; }
        public Boolean Is_Group { get; set; }
        public Boolean Is_Im { get; set; }
        public Int32 Created { get; set; }
        public String Creator { get; set; }
        public Boolean Is_Archived { get; set; }
        public Boolean Is_General { get; set; }
        public Int32 UnLinked { get; set; }
        public String Name_Normalized { get; set; }
        public Boolean Is_Read_Only { get; set; }
        public Boolean Is_Shared { get; set; }
        public Boolean Is_Ext_Shared { get; set; }
        public Boolean Is_Org_Shared { get; set; }
        public String[] Pending_Shared { get; set; }
        public Boolean Is_Pending_Ext_Shared { get; set; }
        public Boolean Is_Member { get; set; }
        public Boolean Is_Private { get; set; }
        public Boolean Is_Mpim { get; set; }
        public String Last_Read { get; set; }

        public (String Type, String User, String Text, String Ts) Latest { get; set; }
        public (String Value, String Creator, Int32 Last_Set) Topic { get; set; }
        public (String Value, String Creator, Int32 Last_Set) Purpose { get; set; }

        public Int32 Unread_Count { get; set; }
        public Int32 Unread_Count_Display { get; set; }
        public Boolean Is_Open { get; set; }
        public Double Priority { get; set; }

        public String[]? Previous_Names { get; set; }
        public Int32 Num_Members { get; set; }
        public String Locale { get; set; }
    }
}
