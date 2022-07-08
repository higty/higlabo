using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalConnectorsExternalitemGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ConnectionsId { get; set; }
            public string ExternalItemId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_ConnectionsId_Items_ExternalItemId: return $"/external/connections/{ConnectionsId}/items/{ExternalItemId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Items_ExternalItemId,
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
    public partial class ExternalConnectorsExternalitemGetResponse : RestApiResponse
    {
        public ExternalConnectorsAcl[]? Acl { get; set; }
        public ExternalConnectorsExternalitemContent? Content { get; set; }
        public string? Id { get; set; }
        public ExternalConnectorsProperties? Properties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalitemGetResponse> ExternalConnectorsExternalitemGetAsync()
        {
            var p = new ExternalConnectorsExternalitemGetParameter();
            return await this.SendAsync<ExternalConnectorsExternalitemGetParameter, ExternalConnectorsExternalitemGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalitemGetResponse> ExternalConnectorsExternalitemGetAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalitemGetParameter();
            return await this.SendAsync<ExternalConnectorsExternalitemGetParameter, ExternalConnectorsExternalitemGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalitemGetResponse> ExternalConnectorsExternalitemGetAsync(ExternalConnectorsExternalitemGetParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalitemGetParameter, ExternalConnectorsExternalitemGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalitemGetResponse> ExternalConnectorsExternalitemGetAsync(ExternalConnectorsExternalitemGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalitemGetParameter, ExternalConnectorsExternalitemGetResponse>(parameter, cancellationToken);
        }
    }
}
