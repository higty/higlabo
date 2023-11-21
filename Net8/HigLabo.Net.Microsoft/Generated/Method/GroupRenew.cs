using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-renew?view=graph-rest-1.0
    /// </summary>
    public partial class GroupRenewParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Renew: return $"/groups/{Id}/renew";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_Renew,
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
    public partial class GroupRenewResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-renew?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-renew?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupRenewResponse> GroupRenewAsync()
        {
            var p = new GroupRenewParameter();
            return await this.SendAsync<GroupRenewParameter, GroupRenewResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-renew?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupRenewResponse> GroupRenewAsync(CancellationToken cancellationToken)
        {
            var p = new GroupRenewParameter();
            return await this.SendAsync<GroupRenewParameter, GroupRenewResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-renew?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupRenewResponse> GroupRenewAsync(GroupRenewParameter parameter)
        {
            return await this.SendAsync<GroupRenewParameter, GroupRenewResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-renew?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupRenewResponse> GroupRenewAsync(GroupRenewParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupRenewParameter, GroupRenewResponse>(parameter, cancellationToken);
        }
    }
}
