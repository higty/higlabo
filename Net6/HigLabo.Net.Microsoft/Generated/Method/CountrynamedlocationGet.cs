using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/countrynamedlocation-get?view=graph-rest-1.0
    /// </summary>
    public partial class CountrynamedLocationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_ConditionalAccess_NamedLocations_Id: return $"/identity/conditionalAccess/namedLocations/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_ConditionalAccess_NamedLocations_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class CountrynamedLocationGetResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/countrynamedlocation-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/countrynamedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedLocationGetResponse> CountrynamedLocationGetAsync()
        {
            var p = new CountrynamedLocationGetParameter();
            return await this.SendAsync<CountrynamedLocationGetParameter, CountrynamedLocationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/countrynamedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedLocationGetResponse> CountrynamedLocationGetAsync(CancellationToken cancellationToken)
        {
            var p = new CountrynamedLocationGetParameter();
            return await this.SendAsync<CountrynamedLocationGetParameter, CountrynamedLocationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/countrynamedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedLocationGetResponse> CountrynamedLocationGetAsync(CountrynamedLocationGetParameter parameter)
        {
            return await this.SendAsync<CountrynamedLocationGetParameter, CountrynamedLocationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/countrynamedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedLocationGetResponse> CountrynamedLocationGetAsync(CountrynamedLocationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CountrynamedLocationGetParameter, CountrynamedLocationGetResponse>(parameter, cancellationToken);
        }
    }
}
