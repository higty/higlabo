using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryroleGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DirectoryRoles_RoleId,
            DirectoryRoles_RoleTemplateId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryRoles_RoleId: return $"/directoryRoles/{RoleId}";
                    case ApiPath.DirectoryRoles_RoleTemplateId: return $"/directoryRoles/roleTemplateId";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string RoleId { get; set; }
    }
    public partial class DirectoryroleGetResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? RoleTemplateId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleGetResponse> DirectoryroleGetAsync()
        {
            var p = new DirectoryroleGetParameter();
            return await this.SendAsync<DirectoryroleGetParameter, DirectoryroleGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleGetResponse> DirectoryroleGetAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroleGetParameter();
            return await this.SendAsync<DirectoryroleGetParameter, DirectoryroleGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleGetResponse> DirectoryroleGetAsync(DirectoryroleGetParameter parameter)
        {
            return await this.SendAsync<DirectoryroleGetParameter, DirectoryroleGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleGetResponse> DirectoryroleGetAsync(DirectoryroleGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroleGetParameter, DirectoryroleGetResponse>(parameter, cancellationToken);
        }
    }
}
