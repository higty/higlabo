using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-list-history?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyUserListHistoryParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? RiskyUserId { get; set; }
            public string? RiskyUserHistoryItemId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskyUsers_RiskyUserId_History: return $"/identityProtection/riskyUsers/{RiskyUserId}/history";
                    case ApiPath.IdentityProtection_RiskyUsers_RiskyUserId_History_RiskyUserHistoryItemId_History: return $"/identityProtection/riskyUsers/{RiskyUserId}/history/{RiskyUserHistoryItemId}/history";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProtection_RiskyUsers_RiskyUserId_History,
            IdentityProtection_RiskyUsers_RiskyUserId_History_RiskyUserHistoryItemId_History,
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
    public partial class RiskyUserListHistoryResponse : RestApiResponse
    {
        public RiskyUserHistoryItem[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-list-history?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-list-history?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyUserListHistoryResponse> RiskyUserListHistoryAsync()
        {
            var p = new RiskyUserListHistoryParameter();
            return await this.SendAsync<RiskyUserListHistoryParameter, RiskyUserListHistoryResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-list-history?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyUserListHistoryResponse> RiskyUserListHistoryAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyUserListHistoryParameter();
            return await this.SendAsync<RiskyUserListHistoryParameter, RiskyUserListHistoryResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-list-history?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyUserListHistoryResponse> RiskyUserListHistoryAsync(RiskyUserListHistoryParameter parameter)
        {
            return await this.SendAsync<RiskyUserListHistoryParameter, RiskyUserListHistoryResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-list-history?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyUserListHistoryResponse> RiskyUserListHistoryAsync(RiskyUserListHistoryParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyUserListHistoryParameter, RiskyUserListHistoryResponse>(parameter, cancellationToken);
        }
    }
}
