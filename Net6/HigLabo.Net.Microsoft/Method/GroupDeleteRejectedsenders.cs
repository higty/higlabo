using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete-rejectedsenders?view=graph-rest-1.0
    /// </summary>
    public partial class GroupDeleteRejectedsendersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_RejectedSenders_ref: return $"/groups/{Id}/rejectedSenders/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_RejectedSenders_ref,
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
    public partial class GroupDeleteRejectedsendersResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete-rejectedsenders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteRejectedsendersResponse> GroupDeleteRejectedsendersAsync()
        {
            var p = new GroupDeleteRejectedsendersParameter();
            return await this.SendAsync<GroupDeleteRejectedsendersParameter, GroupDeleteRejectedsendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteRejectedsendersResponse> GroupDeleteRejectedsendersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteRejectedsendersParameter();
            return await this.SendAsync<GroupDeleteRejectedsendersParameter, GroupDeleteRejectedsendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteRejectedsendersResponse> GroupDeleteRejectedsendersAsync(GroupDeleteRejectedsendersParameter parameter)
        {
            return await this.SendAsync<GroupDeleteRejectedsendersParameter, GroupDeleteRejectedsendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteRejectedsendersResponse> GroupDeleteRejectedsendersAsync(GroupDeleteRejectedsendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteRejectedsendersParameter, GroupDeleteRejectedsendersResponse>(parameter, cancellationToken);
        }
    }
}
