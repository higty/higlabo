using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryroleListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class DirectoryroleListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryrole?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryRole
        {
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public string? RoleTemplateId { get; set; }
        }

        public DirectoryRole[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListResponse> DirectoryroleListAsync()
        {
            var p = new DirectoryroleListParameter();
            return await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListResponse> DirectoryroleListAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroleListParameter();
            return await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListResponse> DirectoryroleListAsync(DirectoryroleListParameter parameter)
        {
            return await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListResponse> DirectoryroleListAsync(DirectoryroleListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(parameter, cancellationToken);
        }
    }
}
