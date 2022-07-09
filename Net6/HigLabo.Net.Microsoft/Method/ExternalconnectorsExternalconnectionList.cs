using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalConnectorsExternalconnectionListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections: return $"/external/connections";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections,
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
    public partial class ExternalConnectorsExternalconnectionListResponse : RestApiResponse
    {
        public ExternalConnectorsExternalconnection[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalconnectionListResponse> ExternalConnectorsExternalconnectionListAsync()
        {
            var p = new ExternalConnectorsExternalconnectionListParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalconnectionListResponse> ExternalConnectorsExternalconnectionListAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalconnectionListParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalconnectionListResponse> ExternalConnectorsExternalconnectionListAsync(ExternalConnectorsExternalconnectionListParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalconnectionListResponse> ExternalConnectorsExternalconnectionListAsync(ExternalConnectorsExternalconnectionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(parameter, cancellationToken);
        }
    }
}
