using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsIdentityDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            External_Connections_ConnectionId_Groups_ExternalGroupId_Members_IdentityId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections_ConnectionId_Groups_ExternalGroupId_Members_IdentityId: return $"/external/connections/{ConnectionId}/groups/{ExternalGroupId}/members/{IdentityId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ConnectionId { get; set; }
        public string ExternalGroupId { get; set; }
        public string IdentityId { get; set; }
    }
    public partial class ExternalconnectorsIdentityDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-identity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsIdentityDeleteResponse> ExternalconnectorsIdentityDeleteAsync()
        {
            var p = new ExternalconnectorsIdentityDeleteParameter();
            return await this.SendAsync<ExternalconnectorsIdentityDeleteParameter, ExternalconnectorsIdentityDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-identity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsIdentityDeleteResponse> ExternalconnectorsIdentityDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsIdentityDeleteParameter();
            return await this.SendAsync<ExternalconnectorsIdentityDeleteParameter, ExternalconnectorsIdentityDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-identity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsIdentityDeleteResponse> ExternalconnectorsIdentityDeleteAsync(ExternalconnectorsIdentityDeleteParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsIdentityDeleteParameter, ExternalconnectorsIdentityDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-identity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsIdentityDeleteResponse> ExternalconnectorsIdentityDeleteAsync(ExternalconnectorsIdentityDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsIdentityDeleteParameter, ExternalconnectorsIdentityDeleteResponse>(parameter, cancellationToken);
        }
    }
}
