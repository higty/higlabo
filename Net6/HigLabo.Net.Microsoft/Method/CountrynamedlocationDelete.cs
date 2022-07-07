using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CountrynamedlocationDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class CountrynamedlocationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/countrynamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedlocationDeleteResponse> CountrynamedlocationDeleteAsync()
        {
            var p = new CountrynamedlocationDeleteParameter();
            return await this.SendAsync<CountrynamedlocationDeleteParameter, CountrynamedlocationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/countrynamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedlocationDeleteResponse> CountrynamedlocationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new CountrynamedlocationDeleteParameter();
            return await this.SendAsync<CountrynamedlocationDeleteParameter, CountrynamedlocationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/countrynamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedlocationDeleteResponse> CountrynamedlocationDeleteAsync(CountrynamedlocationDeleteParameter parameter)
        {
            return await this.SendAsync<CountrynamedlocationDeleteParameter, CountrynamedlocationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/countrynamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CountrynamedlocationDeleteResponse> CountrynamedlocationDeleteAsync(CountrynamedlocationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CountrynamedlocationDeleteParameter, CountrynamedlocationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
