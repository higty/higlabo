using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/countrynamedlocation-update?view=graph-rest-1.0
    /// </summary>
    public partial class CountrynamedLocationUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public String[]? CountriesAndRegions { get; set; }
        public string? DisplayName { get; set; }
        public bool? IncludeUnknownCountriesAndRegions { get; set; }
    }
    public partial class CountrynamedLocationUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/countrynamedlocation-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/countrynamedlocation-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedLocationUpdateResponse> CountrynamedLocationUpdateAsync()
        {
            var p = new CountrynamedLocationUpdateParameter();
            return await this.SendAsync<CountrynamedLocationUpdateParameter, CountrynamedLocationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/countrynamedlocation-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedLocationUpdateResponse> CountrynamedLocationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new CountrynamedLocationUpdateParameter();
            return await this.SendAsync<CountrynamedLocationUpdateParameter, CountrynamedLocationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/countrynamedlocation-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedLocationUpdateResponse> CountrynamedLocationUpdateAsync(CountrynamedLocationUpdateParameter parameter)
        {
            return await this.SendAsync<CountrynamedLocationUpdateParameter, CountrynamedLocationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/countrynamedlocation-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedLocationUpdateResponse> CountrynamedLocationUpdateAsync(CountrynamedLocationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CountrynamedLocationUpdateParameter, CountrynamedLocationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
