using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConversationmembersAddParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Members_Add,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Members_Add: return $"/teams/{TeamId}/members/add";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public ConversationMember[]? Values { get; set; }
        public string TeamId { get; set; }
    }
    public partial class ConversationmembersAddResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/actionresultpart?view=graph-rest-1.0
        /// </summary>
        public partial class ActionResultPart
        {
            public PublicError? Error { get; set; }
        }

        public ActionResultPart[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationmembersAddResponse> ConversationmembersAddAsync()
        {
            var p = new ConversationmembersAddParameter();
            return await this.SendAsync<ConversationmembersAddParameter, ConversationmembersAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationmembersAddResponse> ConversationmembersAddAsync(CancellationToken cancellationToken)
        {
            var p = new ConversationmembersAddParameter();
            return await this.SendAsync<ConversationmembersAddParameter, ConversationmembersAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationmembersAddResponse> ConversationmembersAddAsync(ConversationmembersAddParameter parameter)
        {
            return await this.SendAsync<ConversationmembersAddParameter, ConversationmembersAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationmembersAddResponse> ConversationmembersAddAsync(ConversationmembersAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationmembersAddParameter, ConversationmembersAddResponse>(parameter, cancellationToken);
        }
    }
}
