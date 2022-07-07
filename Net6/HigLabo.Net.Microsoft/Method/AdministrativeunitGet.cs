using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdministrativeunitGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Directory_AdministrativeUnits_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_AdministrativeUnits_Id: return $"/directory/administrativeUnits/{Id}";
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
    public partial class AdministrativeunitGetResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? Visibility { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitGetResponse> AdministrativeunitGetAsync()
        {
            var p = new AdministrativeunitGetParameter();
            return await this.SendAsync<AdministrativeunitGetParameter, AdministrativeunitGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitGetResponse> AdministrativeunitGetAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitGetParameter();
            return await this.SendAsync<AdministrativeunitGetParameter, AdministrativeunitGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitGetResponse> AdministrativeunitGetAsync(AdministrativeunitGetParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitGetParameter, AdministrativeunitGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitGetResponse> AdministrativeunitGetAsync(AdministrativeunitGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitGetParameter, AdministrativeunitGetResponse>(parameter, cancellationToken);
        }
    }
}
