using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RiskyUserListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskyUsers: return $"/identityProtection/riskyUsers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            IsDeleted,
            IsProcessing,
            RiskDetail,
            RiskLastUpdatedDateTime,
            RiskLevel,
            RiskState,
            UserDisplayName,
            UserPrincipalName,
            History,
        }
        public enum ApiPath
        {
            IdentityProtection_RiskyUsers,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class RiskyUserListResponse : RestApiResponse
    {
        public RiskyUser[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyUserListResponse> RiskyUserListAsync()
        {
            var p = new RiskyUserListParameter();
            return await this.SendAsync<RiskyUserListParameter, RiskyUserListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyUserListResponse> RiskyUserListAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyUserListParameter();
            return await this.SendAsync<RiskyUserListParameter, RiskyUserListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyUserListResponse> RiskyUserListAsync(RiskyUserListParameter parameter)
        {
            return await this.SendAsync<RiskyUserListParameter, RiskyUserListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyUserListResponse> RiskyUserListAsync(RiskyUserListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyUserListParameter, RiskyUserListResponse>(parameter, cancellationToken);
        }
    }
}
