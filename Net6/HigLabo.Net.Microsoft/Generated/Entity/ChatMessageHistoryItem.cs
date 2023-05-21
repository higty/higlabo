using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/chatmessagehistoryitem?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMessageHistoryItem
    {
        public enum ChatMessageHistoryItemChatMessageActions
        {
            ReactionAdded,
            ReactionRemoved,
            ActionUndefined,
            UnknownFutureValue,
        }

        public ChatMessageHistoryItemChatMessageActions Actions { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public ChatMessageReAction? Reaction { get; set; }
    }
}
