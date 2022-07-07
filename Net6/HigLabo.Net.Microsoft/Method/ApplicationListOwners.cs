using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationListOwnersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Applications_Id_Owners,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_Id_Owners: return $"/applications/{Id}/owners";
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
    public partial class ApplicationListOwnersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryobject?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryObject
        {
            public DateTimeOffset? DeletedDateTime { get; set; }
            public string? Id { get; set; }
        }

        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListOwnersResponse> ApplicationListOwnersAsync()
        {
            var p = new ApplicationListOwnersParameter();
            return await this.SendAsync<ApplicationListOwnersParameter, ApplicationListOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListOwnersResponse> ApplicationListOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationListOwnersParameter();
            return await this.SendAsync<ApplicationListOwnersParameter, ApplicationListOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListOwnersResponse> ApplicationListOwnersAsync(ApplicationListOwnersParameter parameter)
        {
            return await this.SendAsync<ApplicationListOwnersParameter, ApplicationListOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListOwnersResponse> ApplicationListOwnersAsync(ApplicationListOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationListOwnersParameter, ApplicationListOwnersResponse>(parameter, cancellationToken);
        }
    }
}
