using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsSchemaCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            External_Connections_Id_Schema,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections_Id_Schema: return $"/external/connections/{Id}/schema";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class ExternalconnectorsSchemaCreateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsSchemaCreateResponse> ExternalconnectorsSchemaCreateAsync()
        {
            var p = new ExternalconnectorsSchemaCreateParameter();
            return await this.SendAsync<ExternalconnectorsSchemaCreateParameter, ExternalconnectorsSchemaCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsSchemaCreateResponse> ExternalconnectorsSchemaCreateAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsSchemaCreateParameter();
            return await this.SendAsync<ExternalconnectorsSchemaCreateParameter, ExternalconnectorsSchemaCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsSchemaCreateResponse> ExternalconnectorsSchemaCreateAsync(ExternalconnectorsSchemaCreateParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsSchemaCreateParameter, ExternalconnectorsSchemaCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsSchemaCreateResponse> ExternalconnectorsSchemaCreateAsync(ExternalconnectorsSchemaCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsSchemaCreateParameter, ExternalconnectorsSchemaCreateResponse>(parameter, cancellationToken);
        }
    }
}
