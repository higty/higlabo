using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
    /// </summary>
    public partial class ConversationmembersAddParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Members_Add: return $"/teams/{TeamId}/members/add";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Members_Add,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public ConversationMember[]? Values { get; set; }
    }
    public partial class ConversationmembersAddResponse : RestApiResponse
    {
        public ActionResultPart[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationmembersAddResponse> ConversationmembersAddAsync()
        {
            var p = new ConversationmembersAddParameter();
            return await this.SendAsync<ConversationmembersAddParameter, ConversationmembersAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationmembersAddResponse> ConversationmembersAddAsync(CancellationToken cancellationToken)
        {
            var p = new ConversationmembersAddParameter();
            return await this.SendAsync<ConversationmembersAddParameter, ConversationmembersAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationmembersAddResponse> ConversationmembersAddAsync(ConversationmembersAddParameter parameter)
        {
            return await this.SendAsync<ConversationmembersAddParameter, ConversationmembersAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conversationmembers-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationmembersAddResponse> ConversationmembersAddAsync(ConversationmembersAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationmembersAddParameter, ConversationmembersAddResponse>(parameter, cancellationToken);
        }
    }
}
