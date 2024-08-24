using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-addactivities?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalItemAddactivitiesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ConnectionsId { get; set; }
            public string? ExternalItemId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Connections_ConnectionsId_Items_ExternalItemId_AddActivities: return $"/connections/{ConnectionsId}/items/{ExternalItemId}/addActivities";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Connections_ConnectionsId_Items_ExternalItemId_AddActivities,
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
        public ExternalConnectorsExternalActivity[]? Activities { get; set; }
    }
    public partial class ExternalConnectorsExternalItemAddactivitiesResponse : RestApiResponse<ExternalConnectorsExternalActivityResult>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-addactivities?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-addactivities?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalItemAddactivitiesResponse> ExternalConnectorsExternalItemAddactivitiesAsync()
        {
            var p = new ExternalConnectorsExternalItemAddactivitiesParameter();
            return await this.SendAsync<ExternalConnectorsExternalItemAddactivitiesParameter, ExternalConnectorsExternalItemAddactivitiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-addactivities?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalItemAddactivitiesResponse> ExternalConnectorsExternalItemAddactivitiesAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalItemAddactivitiesParameter();
            return await this.SendAsync<ExternalConnectorsExternalItemAddactivitiesParameter, ExternalConnectorsExternalItemAddactivitiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-addactivities?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalItemAddactivitiesResponse> ExternalConnectorsExternalItemAddactivitiesAsync(ExternalConnectorsExternalItemAddactivitiesParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalItemAddactivitiesParameter, ExternalConnectorsExternalItemAddactivitiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-addactivities?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalItemAddactivitiesResponse> ExternalConnectorsExternalItemAddactivitiesAsync(ExternalConnectorsExternalItemAddactivitiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalItemAddactivitiesParameter, ExternalConnectorsExternalItemAddactivitiesResponse>(parameter, cancellationToken);
        }
    }
}
