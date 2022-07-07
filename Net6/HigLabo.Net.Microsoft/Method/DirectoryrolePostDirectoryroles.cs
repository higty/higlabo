using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryrolePostDirectoryrolesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DirectoryRoles,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryRoles: return $"/directoryRoles";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? RoleTemplateId { get; set; }
    }
    public partial class DirectoryrolePostDirectoryrolesResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? RoleTemplateId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-post-directoryroles?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryrolePostDirectoryrolesResponse> DirectoryrolePostDirectoryrolesAsync()
        {
            var p = new DirectoryrolePostDirectoryrolesParameter();
            return await this.SendAsync<DirectoryrolePostDirectoryrolesParameter, DirectoryrolePostDirectoryrolesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-post-directoryroles?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryrolePostDirectoryrolesResponse> DirectoryrolePostDirectoryrolesAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryrolePostDirectoryrolesParameter();
            return await this.SendAsync<DirectoryrolePostDirectoryrolesParameter, DirectoryrolePostDirectoryrolesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-post-directoryroles?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryrolePostDirectoryrolesResponse> DirectoryrolePostDirectoryrolesAsync(DirectoryrolePostDirectoryrolesParameter parameter)
        {
            return await this.SendAsync<DirectoryrolePostDirectoryrolesParameter, DirectoryrolePostDirectoryrolesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-post-directoryroles?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryrolePostDirectoryrolesResponse> DirectoryrolePostDirectoryrolesAsync(DirectoryrolePostDirectoryrolesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryrolePostDirectoryrolesParameter, DirectoryrolePostDirectoryrolesResponse>(parameter, cancellationToken);
        }
    }
}
