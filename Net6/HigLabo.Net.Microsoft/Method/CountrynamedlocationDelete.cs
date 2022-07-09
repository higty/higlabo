using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CountrynamedLocationDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class CountrynamedLocationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/countrynamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedLocationDeleteResponse> CountrynamedLocationDeleteAsync()
        {
            var p = new CountrynamedLocationDeleteParameter();
            return await this.SendAsync<CountrynamedLocationDeleteParameter, CountrynamedLocationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/countrynamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedLocationDeleteResponse> CountrynamedLocationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new CountrynamedLocationDeleteParameter();
            return await this.SendAsync<CountrynamedLocationDeleteParameter, CountrynamedLocationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/countrynamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedLocationDeleteResponse> CountrynamedLocationDeleteAsync(CountrynamedLocationDeleteParameter parameter)
        {
            return await this.SendAsync<CountrynamedLocationDeleteParameter, CountrynamedLocationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/countrynamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedLocationDeleteResponse> CountrynamedLocationDeleteAsync(CountrynamedLocationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CountrynamedLocationDeleteParameter, CountrynamedLocationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
