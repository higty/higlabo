using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupPostMembersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string GroupId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_GroupId_Members_ref: return $"/groups/{GroupId}/members/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_GroupId_Members_ref,
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
    public partial class GroupPostMembersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostMembersResponse> GroupPostMembersAsync()
        {
            var p = new GroupPostMembersParameter();
            return await this.SendAsync<GroupPostMembersParameter, GroupPostMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostMembersResponse> GroupPostMembersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupPostMembersParameter();
            return await this.SendAsync<GroupPostMembersParameter, GroupPostMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostMembersResponse> GroupPostMembersAsync(GroupPostMembersParameter parameter)
        {
            return await this.SendAsync<GroupPostMembersParameter, GroupPostMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostMembersResponse> GroupPostMembersAsync(GroupPostMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupPostMembersParameter, GroupPostMembersResponse>(parameter, cancellationToken);
        }
    }
}
