using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryrolePostMembersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DirectoryRoles_RoleId_Members_ref,
            DirectoryRoles_RoleTemplateId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryRoles_RoleId_Members_ref: return $"/directoryRoles/{RoleId}/members/$ref";
                    case ApiPath.DirectoryRoles_RoleTemplateId: return $"/directoryRoles/roleTemplateId";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string RoleId { get; set; }
    }
    public partial class DirectoryrolePostMembersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryrolePostMembersResponse> DirectoryrolePostMembersAsync()
        {
            var p = new DirectoryrolePostMembersParameter();
            return await this.SendAsync<DirectoryrolePostMembersParameter, DirectoryrolePostMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryrolePostMembersResponse> DirectoryrolePostMembersAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryrolePostMembersParameter();
            return await this.SendAsync<DirectoryrolePostMembersParameter, DirectoryrolePostMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryrolePostMembersResponse> DirectoryrolePostMembersAsync(DirectoryrolePostMembersParameter parameter)
        {
            return await this.SendAsync<DirectoryrolePostMembersParameter, DirectoryrolePostMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryrolePostMembersResponse> DirectoryrolePostMembersAsync(DirectoryrolePostMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryrolePostMembersParameter, DirectoryrolePostMembersResponse>(parameter, cancellationToken);
        }
    }
}
