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
            public string? User { get; set; }
            public string? Ts { get; set; }
            public DateTimeOffset? Ts_DateTimeOffset
            {
                get { return this.Ts.GetDateTimeOffsetFromTs(); }
            }
        }
        public string? Id { get; set; }
        public string? Type { get; set; }
        public string? Channel { get; set; }
        public string? User { get; set; }
        public string? Text { get; set; }
        public string? Ts { get; set; }
        public DateTimeOffset? Ts_DateTimeOffset
        {
            get { return this.Ts.GetDateTimeOffsetFromTs(); }
        }
        public string? Deleted_Ts { get; set; }
        public DateTimeOffset? Deleted_Ts_DateTimeOffset
        {
            get { return this.Deleted_Ts.GetDateTimeOffsetFromTs(); }
        }
        public string? Event_Ts { get; set; }
        public DateTimeOffset? Event_Ts_DateTimeOffset
        {
            get { return this.Event_Ts.GetDateTimeOffsetFromTs(); }
        }

        public string? Parent_User_Id { get; set; }
        public string? Thread_Ts { get; set; }
        public DateTimeOffset? Thread_Ts_DateTimeOffset
        {
            get { return this.Thread_Ts.GetDateTimeOffsetFromTs(); }
        }
        public int Reply_Count { get; set; }
        public string? Last_Read { get; set; }
        public Int32 Unread_Count { get; set; }
        public EditedUser? Edited { get; set; }

        public File[]? Files { get; set; }
        public Attachment[]? Attachments { get; set; }

        public Boolean? IsStarred { get; set; }
        public String[]? Pinned_To { get; set; }
        public (string? Name, Int32 Count, String[]? Users)[]? Reactions { get; set; }
    }
}
