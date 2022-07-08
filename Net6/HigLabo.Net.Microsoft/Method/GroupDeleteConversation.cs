using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupDeleteConversationParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string GroupsId { get; set; }
            public string ConversationsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Conversations_Id: return $"/groups/{GroupsId}/conversations/{ConversationsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_Conversations_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class GroupDeleteConversationResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-conversation?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteConversationResponse> GroupDeleteConversationAsync()
        {
            var p = new GroupDeleteConversationParameter();
            return await this.SendAsync<GroupDeleteConversationParameter, GroupDeleteConversationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-conversation?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteConversationResponse> GroupDeleteConversationAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteConversationParameter();
            return await this.SendAsync<GroupDeleteConversationParameter, GroupDeleteConversationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-conversation?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteConversationResponse> GroupDeleteConversationAsync(GroupDeleteConversationParameter parameter)
        {
            return await this.SendAsync<GroupDeleteConversationParameter, GroupDeleteConversationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-conversation?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteConversationResponse> GroupDeleteConversationAsync(GroupDeleteConversationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteConversationParameter, GroupDeleteConversationResponse>(parameter, cancellationToken);
        }
    }
}
