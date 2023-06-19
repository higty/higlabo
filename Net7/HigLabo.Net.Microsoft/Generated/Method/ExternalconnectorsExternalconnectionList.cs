using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
    /// </summary>
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
            ActivitySettings,
            Configuration,
            Description,
            Id,
            Name,
            SearchSettings,
            State,
            Items,
            Operations,
            Schema,
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionListResponse> ExternalConnectorsExternalconnectionListAsync()
        {
            var p = new ExternalConnectorsExternalconnectionListParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionListResponse> ExternalConnectorsExternalconnectionListAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalconnectionListParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionListResponse> ExternalConnectorsExternalconnectionListAsync(ExternalConnectorsExternalconnectionListParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionListResponse> ExternalConnectorsExternalconnectionListAsync(ExternalConnectorsExternalconnectionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(parameter, cancellationToken);
        }
    }
}
