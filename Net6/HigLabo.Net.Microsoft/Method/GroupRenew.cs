using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupRenewParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_Renew,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Renew: return $"/groups/{Id}/renew";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class GroupRenewResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-renew?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupRenewResponse> GroupRenewAsync()
        {
            var p = new GroupRenewParameter();
            return await this.SendAsync<GroupRenewParameter, GroupRenewResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-renew?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupRenewResponse> GroupRenewAsync(CancellationToken cancellationToken)
        {
            var p = new GroupRenewParameter();
            return await this.SendAsync<GroupRenewParameter, GroupRenewResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-renew?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupRenewResponse> GroupRenewAsync(GroupRenewParameter parameter)
        {
            return await this.SendAsync<GroupRenewParameter, GroupRenewResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-renew?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupRenewResponse> GroupRenewAsync(GroupRenewParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupRenewParameter, GroupRenewResponse>(parameter, cancellationToken);
        }
    }
}
