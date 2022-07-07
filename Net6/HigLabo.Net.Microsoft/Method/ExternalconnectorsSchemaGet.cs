using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsSchemaGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Schema,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections_ConnectionsId_Schema: return $"/external/connections/{ConnectionsId}/schema";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string ConnectionsId { get; set; }
    }
    public partial class ExternalconnectorsSchemaGetResponse : RestApiResponse
    {
        public string? BaseType { get; set; }
        public Property[]? Properties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsSchemaGetResponse> ExternalconnectorsSchemaGetAsync()
        {
            var p = new ExternalconnectorsSchemaGetParameter();
            return await this.SendAsync<ExternalconnectorsSchemaGetParameter, ExternalconnectorsSchemaGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsSchemaGetResponse> ExternalconnectorsSchemaGetAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsSchemaGetParameter();
            return await this.SendAsync<ExternalconnectorsSchemaGetParameter, ExternalconnectorsSchemaGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsSchemaGetResponse> ExternalconnectorsSchemaGetAsync(ExternalconnectorsSchemaGetParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsSchemaGetParameter, ExternalconnectorsSchemaGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsSchemaGetResponse> ExternalconnectorsSchemaGetAsync(ExternalconnectorsSchemaGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsSchemaGetParameter, ExternalconnectorsSchemaGetResponse>(parameter, cancellationToken);
        }
    }
}
