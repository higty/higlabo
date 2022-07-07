using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryroletemplateListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DirectoryRoleTemplates,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryRoleTemplates: return $"/directoryRoleTemplates";
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
    public partial class DirectoryroletemplateListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryroletemplate?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryRoleTemplate
        {
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
        }

        public DirectoryRoleTemplate[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroletemplateListResponse> DirectoryroletemplateListAsync()
        {
            var p = new DirectoryroletemplateListParameter();
            return await this.SendAsync<DirectoryroletemplateListParameter, DirectoryroletemplateListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroletemplateListResponse> DirectoryroletemplateListAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroletemplateListParameter();
            return await this.SendAsync<DirectoryroletemplateListParameter, DirectoryroletemplateListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroletemplateListResponse> DirectoryroletemplateListAsync(DirectoryroletemplateListParameter parameter)
        {
            return await this.SendAsync<DirectoryroletemplateListParameter, DirectoryroletemplateListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroletemplateListResponse> DirectoryroletemplateListAsync(DirectoryroletemplateListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroletemplateListParameter, DirectoryroletemplateListResponse>(parameter, cancellationToken);
        }
    }
}
