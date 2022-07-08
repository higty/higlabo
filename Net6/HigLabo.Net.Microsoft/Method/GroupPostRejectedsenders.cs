using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupPostRejectedsendersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class GroupPostRejectedsendersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostRejectedsendersResponse> GroupPostRejectedsendersAsync()
        {
            var p = new GroupPostRejectedsendersParameter();
            return await this.SendAsync<GroupPostRejectedsendersParameter, GroupPostRejectedsendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostRejectedsendersResponse> GroupPostRejectedsendersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupPostRejectedsendersParameter();
            return await this.SendAsync<GroupPostRejectedsendersParameter, GroupPostRejectedsendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostRejectedsendersResponse> GroupPostRejectedsendersAsync(GroupPostRejectedsendersParameter parameter)
        {
            return await this.SendAsync<GroupPostRejectedsendersParameter, GroupPostRejectedsendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostRejectedsendersResponse> GroupPostRejectedsendersAsync(GroupPostRejectedsendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupPostRejectedsendersParameter, GroupPostRejectedsendersResponse>(parameter, cancellationToken);
        }
    }
}
