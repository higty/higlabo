using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryroleDeleteMemberParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DirectoryRoles_RoleId_Members_Id_ref,
            DirectoryRoles_RoleTemplateId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryRoles_RoleId_Members_Id_ref: return $"/directoryRoles/{RoleId}/members/{Id}/$ref";
                    case ApiPath.DirectoryRoles_RoleTemplateId: return $"/directoryRoles/roleTemplateId";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string RoleId { get; set; }
        public string Id { get; set; }
    }
    public partial class DirectoryroleDeleteMemberResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-delete-member?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleDeleteMemberResponse> DirectoryroleDeleteMemberAsync()
        {
            var p = new DirectoryroleDeleteMemberParameter();
            return await this.SendAsync<DirectoryroleDeleteMemberParameter, DirectoryroleDeleteMemberResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-delete-member?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleDeleteMemberResponse> DirectoryroleDeleteMemberAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroleDeleteMemberParameter();
            return await this.SendAsync<DirectoryroleDeleteMemberParameter, DirectoryroleDeleteMemberResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-delete-member?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleDeleteMemberResponse> DirectoryroleDeleteMemberAsync(DirectoryroleDeleteMemberParameter parameter)
        {
            return await this.SendAsync<DirectoryroleDeleteMemberParameter, DirectoryroleDeleteMemberResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-delete-member?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleDeleteMemberResponse> DirectoryroleDeleteMemberAsync(DirectoryroleDeleteMemberParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroleDeleteMemberParameter, DirectoryroleDeleteMemberResponse>(parameter, cancellationToken);
        }
    }
}
