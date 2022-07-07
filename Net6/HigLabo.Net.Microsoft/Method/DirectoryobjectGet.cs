using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryobjectGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DirectoryObjects_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryObjects_Id: return $"/directoryObjects/{Id}";
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
    public partial class DirectoryobjectGetResponse : RestApiResponse
    {
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetResponse> DirectoryobjectGetAsync()
        {
            var p = new DirectoryobjectGetParameter();
            return await this.SendAsync<DirectoryobjectGetParameter, DirectoryobjectGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetResponse> DirectoryobjectGetAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryobjectGetParameter();
            return await this.SendAsync<DirectoryobjectGetParameter, DirectoryobjectGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetResponse> DirectoryobjectGetAsync(DirectoryobjectGetParameter parameter)
        {
            return await this.SendAsync<DirectoryobjectGetParameter, DirectoryobjectGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetResponse> DirectoryobjectGetAsync(DirectoryobjectGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryobjectGetParameter, DirectoryobjectGetResponse>(parameter, cancellationToken);
        }
    }
}
