using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalConnectorsExternalGroupUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ConnectionsId { get; set; }
            public string? ExternalGroupId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_ConnectionsId_Groups_ExternalGroupId: return $"/external/connections/{ConnectionsId}/groups/{ExternalGroupId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
    }
    public partial class ExternalConnectorsExternalGroupUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalGroupUpdateResponse> ExternalConnectorsExternalGroupUpdateAsync()
        {
            var p = new ExternalConnectorsExternalGroupUpdateParameter();
            return await this.SendAsync<ExternalConnectorsExternalGroupUpdateParameter, ExternalConnectorsExternalGroupUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalGroupUpdateResponse> ExternalConnectorsExternalGroupUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalGroupUpdateParameter();
            return await this.SendAsync<ExternalConnectorsExternalGroupUpdateParameter, ExternalConnectorsExternalGroupUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalGroupUpdateResponse> ExternalConnectorsExternalGroupUpdateAsync(ExternalConnectorsExternalGroupUpdateParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalGroupUpdateParameter, ExternalConnectorsExternalGroupUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalGroupUpdateResponse> ExternalConnectorsExternalGroupUpdateAsync(ExternalConnectorsExternalGroupUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalGroupUpdateParameter, ExternalConnectorsExternalGroupUpdateResponse>(parameter, cancellationToken);
        }
    }
}
