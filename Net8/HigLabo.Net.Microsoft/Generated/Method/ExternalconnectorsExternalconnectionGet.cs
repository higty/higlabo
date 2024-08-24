using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-get?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalconnectionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ConnectionsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_ConnectionsId: return $"/external/connections/{ConnectionsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections_ConnectionsId,
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
    public partial class ExternalConnectorsExternalconnectionGetResponse : RestApiResponse
    {
        public enum ExternalConnectorsExternalconnectionExternalConnectorsConnectionState
        {
            Draft,
            Ready,
            Obsolete,
            LimitExceeded,
            UnknownFutureValue,
        }

        public ExternalConnectorsActivitySettings? ActivitySettings { get; set; }
        public ExternalConnectorsConfiguration? Configuration { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public ExternalConnectorsSearchSettings? SearchSettings { get; set; }
        public ExternalConnectorsExternalconnectionExternalConnectorsConnectionState State { get; set; }
        public ExternalConnectorsExternalItem[]? Items { get; set; }
        public ExternalConnectorsConnectionOperation[]? Operations { get; set; }
        public ExternalConnectorsSchema? Schema { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionGetResponse> ExternalConnectorsExternalconnectionGetAsync()
        {
            var p = new ExternalConnectorsExternalconnectionGetParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionGetParameter, ExternalConnectorsExternalconnectionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionGetResponse> ExternalConnectorsExternalconnectionGetAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalconnectionGetParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionGetParameter, ExternalConnectorsExternalconnectionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionGetResponse> ExternalConnectorsExternalconnectionGetAsync(ExternalConnectorsExternalconnectionGetParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionGetParameter, ExternalConnectorsExternalconnectionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionGetResponse> ExternalConnectorsExternalconnectionGetAsync(ExternalConnectorsExternalconnectionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionGetParameter, ExternalConnectorsExternalconnectionGetResponse>(parameter, cancellationToken);
        }
    }
}
