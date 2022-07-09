using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chatmessagereactionidentityset?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMessageReActionIdentitySet
    {
        public Identity? Application { get; set; }
        public Identity? Device { get; set; }
        public Identity? User { get; set; }
    }
}
