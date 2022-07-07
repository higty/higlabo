using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CountrynamedlocationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_ConditionalAccess_NamedLocations_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_ConditionalAccess_NamedLocations_Id: return $"/identity/conditionalAccess/namedLocations/{Id}";
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
    public partial class CountrynamedlocationGetResponse : RestApiResponse
    {
        public enum CountryNamedLocationCountryLookupMethodType
        {
            ClientIpAddress,
            AuthenticatorAppGps,
        }

        public String[]? CountriesAndRegions { get; set; }
        public CountryNamedLocationCountryLookupMethodType CountryLookupMethod { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IncludeUnknownCountriesAndRegions { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/countrynamedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedlocationGetResponse> CountrynamedlocationGetAsync()
        {
            var p = new CountrynamedlocationGetParameter();
            return await this.SendAsync<CountrynamedlocationGetParameter, CountrynamedlocationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/countrynamedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedlocationGetResponse> CountrynamedlocationGetAsync(CancellationToken cancellationToken)
        {
            var p = new CountrynamedlocationGetParameter();
            return await this.SendAsync<CountrynamedlocationGetParameter, CountrynamedlocationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/countrynamedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedlocationGetResponse> CountrynamedlocationGetAsync(CountrynamedlocationGetParameter parameter)
        {
            return await this.SendAsync<CountrynamedlocationGetParameter, CountrynamedlocationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/countrynamedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedlocationGetResponse> CountrynamedlocationGetAsync(CountrynamedlocationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CountrynamedlocationGetParameter, CountrynamedlocationGetResponse>(parameter, cancellationToken);
        }
    }
}
