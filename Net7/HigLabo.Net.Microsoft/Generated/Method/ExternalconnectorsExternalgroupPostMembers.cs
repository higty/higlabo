using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-post-members?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalGroupPostMembersParameter : IRestApiParameter
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
                    case ApiPath.External_Connections_ConnectionsId_Groups_ExternalGroupId_Members: return $"/external/connections/{ConnectionsId}/groups/{ExternalGroupId}/members";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ExternalConnectorsExternalGroupPostMembersParameterExternalConnectorsIdentityType
        {
            User,
            Group,
            ExternalGroup,
        }
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Groups_ExternalGroupId_Members,
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
        public ExternalConnectorsExternalGroupPostMembersParameterExternalConnectorsIdentityType Type { get; set; }
    }
    public partial class ExternalConnectorsExternalGroupPostMembersResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-post-members?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-post-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalGroupPostMembersResponse> ExternalConnectorsExternalGroupPostMembersAsync()
        {
            var p = new ExternalConnectorsExternalGroupPostMembersParameter();
            return await this.SendAsync<ExternalConnectorsExternalGroupPostMembersParameter, ExternalConnectorsExternalGroupPostMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-post-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalGroupPostMembersResponse> ExternalConnectorsExternalGroupPostMembersAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalGroupPostMembersParameter();
            return await this.SendAsync<ExternalConnectorsExternalGroupPostMembersParameter, ExternalConnectorsExternalGroupPostMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-post-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalGroupPostMembersResponse> ExternalConnectorsExternalGroupPostMembersAsync(ExternalConnectorsExternalGroupPostMembersParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalGroupPostMembersParameter, ExternalConnectorsExternalGroupPostMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-post-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalGroupPostMembersResponse> ExternalConnectorsExternalGroupPostMembersAsync(ExternalConnectorsExternalGroupPostMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalGroupPostMembersParameter, ExternalConnectorsExternalGroupPostMembersResponse>(parameter, cancellationToken);
        }
    }
}
