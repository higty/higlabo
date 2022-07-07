using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id: return $"/groups/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class GroupDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteResponse> GroupDeleteAsync()
        {
            var p = new GroupDeleteParameter();
            return await this.SendAsync<GroupDeleteParameter, GroupDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteResponse> GroupDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteParameter();
            return await this.SendAsync<GroupDeleteParameter, GroupDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteResponse> GroupDeleteAsync(GroupDeleteParameter parameter)
        {
            return await this.SendAsync<GroupDeleteParameter, GroupDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteResponse> GroupDeleteAsync(GroupDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteParameter, GroupDeleteResponse>(parameter, cancellationToken);
        }
    }
}
