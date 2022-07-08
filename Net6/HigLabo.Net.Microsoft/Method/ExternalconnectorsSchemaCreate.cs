using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalConnectorsSchemaCreateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_Id_Schema: return $"/external/connections/{Id}/schema";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            External_Connections_Id_Schema,
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
    public partial class ExternalConnectorsSchemaCreateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsSchemaCreateResponse> ExternalConnectorsSchemaCreateAsync()
        {
            var p = new ExternalConnectorsSchemaCreateParameter();
            return await this.SendAsync<ExternalConnectorsSchemaCreateParameter, ExternalConnectorsSchemaCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsSchemaCreateResponse> ExternalConnectorsSchemaCreateAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsSchemaCreateParameter();
            return await this.SendAsync<ExternalConnectorsSchemaCreateParameter, ExternalConnectorsSchemaCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsSchemaCreateResponse> ExternalConnectorsSchemaCreateAsync(ExternalConnectorsSchemaCreateParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsSchemaCreateParameter, ExternalConnectorsSchemaCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-schema-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsSchemaCreateResponse> ExternalConnectorsSchemaCreateAsync(ExternalConnectorsSchemaCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsSchemaCreateParameter, ExternalConnectorsSchemaCreateResponse>(parameter, cancellationToken);
        }
    }
}
