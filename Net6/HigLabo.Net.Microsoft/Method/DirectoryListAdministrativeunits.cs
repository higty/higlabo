using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryListAdministrativeunitsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Directory_AdministrativeUnits,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_AdministrativeUnits: return $"/directory/administrativeUnits";
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
    public partial class DirectoryListAdministrativeunitsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/administrativeunit?view=graph-rest-1.0
        /// </summary>
        public partial class AdministrativeUnit
        {
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public string? Visibility { get; set; }
        }

        public AdministrativeUnit[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-list-administrativeunits?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryListAdministrativeunitsResponse> DirectoryListAdministrativeunitsAsync()
        {
            var p = new DirectoryListAdministrativeunitsParameter();
            return await this.SendAsync<DirectoryListAdministrativeunitsParameter, DirectoryListAdministrativeunitsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-list-administrativeunits?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryListAdministrativeunitsResponse> DirectoryListAdministrativeunitsAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryListAdministrativeunitsParameter();
            return await this.SendAsync<DirectoryListAdministrativeunitsParameter, DirectoryListAdministrativeunitsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-list-administrativeunits?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryListAdministrativeunitsResponse> DirectoryListAdministrativeunitsAsync(DirectoryListAdministrativeunitsParameter parameter)
        {
            return await this.SendAsync<DirectoryListAdministrativeunitsParameter, DirectoryListAdministrativeunitsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-list-administrativeunits?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryListAdministrativeunitsResponse> DirectoryListAdministrativeunitsAsync(DirectoryListAdministrativeunitsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryListAdministrativeunitsParameter, DirectoryListAdministrativeunitsResponse>(parameter, cancellationToken);
        }
    }
}
