using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryroletemplateGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DirectoryRoleTemplates_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryRoleTemplates_Id: return $"/directoryRoleTemplates/{Id}";
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
        public string Id { get; set; }
    }
    public partial class DirectoryroletemplateGetResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroletemplateGetResponse> DirectoryroletemplateGetAsync()
        {
            var p = new DirectoryroletemplateGetParameter();
            return await this.SendAsync<DirectoryroletemplateGetParameter, DirectoryroletemplateGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroletemplateGetResponse> DirectoryroletemplateGetAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroletemplateGetParameter();
            return await this.SendAsync<DirectoryroletemplateGetParameter, DirectoryroletemplateGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroletemplateGetResponse> DirectoryroletemplateGetAsync(DirectoryroletemplateGetParameter parameter)
        {
            return await this.SendAsync<DirectoryroletemplateGetParameter, DirectoryroletemplateGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroletemplateGetResponse> DirectoryroletemplateGetAsync(DirectoryroletemplateGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroletemplateGetParameter, DirectoryroletemplateGetResponse>(parameter, cancellationToken);
        }
    }
}
