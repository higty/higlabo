using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalConnectorsExternalGroupGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ConnectionsId { get; set; }
            public string ExternalGroupId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_ConnectionsId_Groups_ExternalGroupId: return $"/external/connections/{ConnectionsId}/groups/{ExternalGroupId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Groups_ExternalGroupId,
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
    public partial class ExternalConnectorsExternalGroupGetResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalGroupGetResponse> ExternalConnectorsExternalGroupGetAsync()
        {
            var p = new ExternalConnectorsExternalGroupGetParameter();
            return await this.SendAsync<ExternalConnectorsExternalGroupGetParameter, ExternalConnectorsExternalGroupGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalGroupGetResponse> ExternalConnectorsExternalGroupGetAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalGroupGetParameter();
            return await this.SendAsync<ExternalConnectorsExternalGroupGetParameter, ExternalConnectorsExternalGroupGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalGroupGetResponse> ExternalConnectorsExternalGroupGetAsync(ExternalConnectorsExternalGroupGetParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalGroupGetParameter, ExternalConnectorsExternalGroupGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalGroupGetResponse> ExternalConnectorsExternalGroupGetAsync(ExternalConnectorsExternalGroupGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalGroupGetParameter, ExternalConnectorsExternalGroupGetResponse>(parameter, cancellationToken);
        }
    }
}
