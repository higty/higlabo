using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class Message
    {
        public class EditedUser
        {
            public String User { get; set; }
            public String Ts { get; set; }
            public DateTimeOffset? Ts_DateTimeOffset
            {
                get { return this.Ts.GetDateTimeOffsetFromTs(); }
            }
        }
        public String Id { get; set; }
        public String Type { get; set; }
        public String Channel { get; set; }
        public String User { get; set; }
        public String Text { get; set; }
        public String Ts { get; set; }
        public DateTimeOffset? Ts_DateTimeOffset
        {
            get { return this.Ts.GetDateTimeOffsetFromTs(); }
        }
        public String Deleted_Ts { get; set; }
        public DateTimeOffset? Deleted_Ts_DateTimeOffset
        {
            get { return this.Deleted_Ts.GetDateTimeOffsetFromTs(); }
        }
        public String Event_Ts { get; set; }
        public DateTimeOffset? Event_Ts_DateTimeOffset
        {
            get { return this.Event_Ts.GetDateTimeOffsetFromTs(); }
        }
        public EditedUser Edited { get; set; }

        public File[] Files { get; set; }
        public Attachment[] Attachments { get; set; }

        public Boolean? IsStarred { get; set; }
        public String[] Pinned_To { get; set; }
        public (String Name, Int32 Count, String[] Users)[] Reactions { get; set; }
    }
}
