using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupPostOwnersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Owners_ref: return $"/groups/{Id}/owners/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_Owners_ref,
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
    public partial class GroupPostOwnersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostOwnersResponse> GroupPostOwnersAsync()
        {
            var p = new GroupPostOwnersParameter();
            return await this.SendAsync<GroupPostOwnersParameter, GroupPostOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostOwnersResponse> GroupPostOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupPostOwnersParameter();
            return await this.SendAsync<GroupPostOwnersParameter, GroupPostOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostOwnersResponse> GroupPostOwnersAsync(GroupPostOwnersParameter parameter)
        {
            return await this.SendAsync<GroupPostOwnersParameter, GroupPostOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostOwnersResponse> GroupPostOwnersAsync(GroupPostOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupPostOwnersParameter, GroupPostOwnersResponse>(parameter, cancellationToken);
        }
    }
}
