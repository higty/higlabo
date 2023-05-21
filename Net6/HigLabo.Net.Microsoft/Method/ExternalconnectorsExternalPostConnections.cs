using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-external-post-connections?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalPostConnectionsParameter : IRestApiParameter
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

        public enum ExternalConnectorsExternalconnectionExternalConnectorsConnectionState
        {
            Draft,
            Ready,
            Obsolete,
            LimitExceeded,
            UnknownFutureValue,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ExternalConnectorsConfiguration? Configuration { get; set; }
        public ExternalConnectorsActivitySettings? ActivitySettings { get; set; }
        public ExternalConnectorsSearchSettings? SearchSettings { get; set; }
        public ExternalConnectorsExternalconnectionExternalConnectorsConnectionState State { get; set; }
        public ExternalConnectorsExternalitem[]? Items { get; set; }
        public ExternalConnectorsConnectionOperation[]? Operations { get; set; }
        public ExternalConnectorsSchema? Schema { get; set; }
    }
    public partial class ExternalConnectorsExternalPostConnectionsResponse : RestApiResponse
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
        public ExternalConnectorsExternalitem[]? Items { get; set; }
        public ExternalConnectorsConnectionOperation[]? Operations { get; set; }
        public ExternalConnectorsSchema? Schema { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-external-post-connections?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-external-post-connections?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalPostConnectionsResponse> ExternalConnectorsExternalPostConnectionsAsync()
        {
            var p = new ExternalConnectorsExternalPostConnectionsParameter();
            return await this.SendAsync<ExternalConnectorsExternalPostConnectionsParameter, ExternalConnectorsExternalPostConnectionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-external-post-connections?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalPostConnectionsResponse> ExternalConnectorsExternalPostConnectionsAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalPostConnectionsParameter();
            return await this.SendAsync<ExternalConnectorsExternalPostConnectionsParameter, ExternalConnectorsExternalPostConnectionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-external-post-connections?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalPostConnectionsResponse> ExternalConnectorsExternalPostConnectionsAsync(ExternalConnectorsExternalPostConnectionsParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalPostConnectionsParameter, ExternalConnectorsExternalPostConnectionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-external-post-connections?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalPostConnectionsResponse> ExternalConnectorsExternalPostConnectionsAsync(ExternalConnectorsExternalPostConnectionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalPostConnectionsParameter, ExternalConnectorsExternalPostConnectionsResponse>(parameter, cancellationToken);
        }
    }
}
