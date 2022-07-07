using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsExternalgroupDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Groups_ExternalGroupId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections_ConnectionsId_Groups_ExternalGroupId: return $"/external/connections/{ConnectionsId}/groups/{ExternalGroupId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ConnectionsId { get; set; }
        public string ExternalGroupId { get; set; }
    }
    public partial class ExternalconnectorsExternalgroupDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalgroupDeleteResponse> ExternalconnectorsExternalgroupDeleteAsync()
        {
            var p = new ExternalconnectorsExternalgroupDeleteParameter();
            return await this.SendAsync<ExternalconnectorsExternalgroupDeleteParameter, ExternalconnectorsExternalgroupDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalgroupDeleteResponse> ExternalconnectorsExternalgroupDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsExternalgroupDeleteParameter();
            return await this.SendAsync<ExternalconnectorsExternalgroupDeleteParameter, ExternalconnectorsExternalgroupDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalgroupDeleteResponse> ExternalconnectorsExternalgroupDeleteAsync(ExternalconnectorsExternalgroupDeleteParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsExternalgroupDeleteParameter, ExternalconnectorsExternalgroupDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalgroupDeleteResponse> ExternalconnectorsExternalgroupDeleteAsync(ExternalconnectorsExternalgroupDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsExternalgroupDeleteParameter, ExternalconnectorsExternalgroupDeleteResponse>(parameter, cancellationToken);
        }
    }
}
