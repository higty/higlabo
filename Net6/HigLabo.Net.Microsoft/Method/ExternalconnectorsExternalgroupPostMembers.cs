using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsExternalgroupPostMembersParameter : IRestApiParameter
    {
        public enum ExternalconnectorsExternalgroupPostMembersParameterExternalConnectorsIdentityType
        {
            User,
            Group,
            ExternalGroup,
        }
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Groups_ExternalGroupId_Members,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections_ConnectionsId_Groups_ExternalGroupId_Members: return $"/external/connections/{ConnectionsId}/groups/{ExternalGroupId}/members";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public ExternalconnectorsExternalgroupPostMembersParameterExternalConnectorsIdentityType Type { get; set; }
        public string ConnectionsId { get; set; }
        public string ExternalGroupId { get; set; }
    }
    public partial class ExternalconnectorsExternalgroupPostMembersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalgroupPostMembersResponse> ExternalconnectorsExternalgroupPostMembersAsync()
        {
            var p = new ExternalconnectorsExternalgroupPostMembersParameter();
            return await this.SendAsync<ExternalconnectorsExternalgroupPostMembersParameter, ExternalconnectorsExternalgroupPostMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalgroupPostMembersResponse> ExternalconnectorsExternalgroupPostMembersAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsExternalgroupPostMembersParameter();
            return await this.SendAsync<ExternalconnectorsExternalgroupPostMembersParameter, ExternalconnectorsExternalgroupPostMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalgroupPostMembersResponse> ExternalconnectorsExternalgroupPostMembersAsync(ExternalconnectorsExternalgroupPostMembersParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsExternalgroupPostMembersParameter, ExternalconnectorsExternalgroupPostMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalgroupPostMembersResponse> ExternalconnectorsExternalgroupPostMembersAsync(ExternalconnectorsExternalgroupPostMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsExternalgroupPostMembersParameter, ExternalconnectorsExternalgroupPostMembersResponse>(parameter, cancellationToken);
        }
    }
}
