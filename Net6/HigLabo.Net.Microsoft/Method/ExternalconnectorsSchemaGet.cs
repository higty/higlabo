using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalConnectorsSchemaGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ConnectionsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_ConnectionsId_Schema: return $"/external/connections/{ConnectionsId}/schema";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Schema,
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
    public partial class ExternalConnectorsSchemaGetResponse : RestApiResponse
    {
        public string? BaseType { get; set; }
        public ExternalConnectorsProperty[]? Properties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsSchemaGetResponse> ExternalConnectorsSchemaGetAsync()
        {
            var p = new ExternalConnectorsSchemaGetParameter();
            return await this.SendAsync<ExternalConnectorsSchemaGetParameter, ExternalConnectorsSchemaGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsSchemaGetResponse> ExternalConnectorsSchemaGetAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsSchemaGetParameter();
            return await this.SendAsync<ExternalConnectorsSchemaGetParameter, ExternalConnectorsSchemaGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsSchemaGetResponse> ExternalConnectorsSchemaGetAsync(ExternalConnectorsSchemaGetParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsSchemaGetParameter, ExternalConnectorsSchemaGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsSchemaGetResponse> ExternalConnectorsSchemaGetAsync(ExternalConnectorsSchemaGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsSchemaGetParameter, ExternalConnectorsSchemaGetResponse>(parameter, cancellationToken);
        }
    }
}
