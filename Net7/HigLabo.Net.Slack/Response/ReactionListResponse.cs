using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public partial class ReactionListResponse
    {
        public class ReactionMessage
        {
            public string Bot_Id { get; set; }
            public Reaction[] Reactions { get; set; }
            public string SubType { get; set; }
            public string Text { get; set; }
            public string Ts { get; set; }
            public string UserName { get; set; }
        }
        public class ReactionComment
        {
            public string Type { get; set; }
            public string Bot_Id { get; set; }
            public string Comment { get; set; }
            public Int32 Created { get; set; }
            public string Id { get; set; }
            public Reaction[] Reactions { get; set; }
            public Int32 Timestamp { get; set; }
            public String User { get; set; }
        }
        public class ReactionFile
        {
            public string[] Channels { get; set; }
            public string Bot_Id { get; set; }
            public Int32 CommentCount { get; set; }
            public Int32 Created { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
            public Reaction[] Reactions { get; set; }
            public int Size { get; set; }
            public string Title { get; set; }
            public string User { get; set; }
            public string UserName { get; set; }
        }
        public ReactionListItem[] Items { get; set; }
    }
    public class ReactionListItem
    {
        public string Type { get; set; }
        public ReactionListResponse.ReactionMessage Message { get; set; }
        public ReactionListResponse.ReactionComment Comment { get; set; }
        public ReactionListResponse.ReactionFile File { get; set; }
    }
}
