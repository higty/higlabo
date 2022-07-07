using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class NamedlocationDeleteParameter : IRestApiParameter
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
    public partial class NamedlocationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/namedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<NamedlocationDeleteResponse> NamedlocationDeleteAsync()
        {
            var p = new NamedlocationDeleteParameter();
            return await this.SendAsync<NamedlocationDeleteParameter, NamedlocationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/namedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<NamedlocationDeleteResponse> NamedlocationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new NamedlocationDeleteParameter();
            return await this.SendAsync<NamedlocationDeleteParameter, NamedlocationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/namedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<NamedlocationDeleteResponse> NamedlocationDeleteAsync(NamedlocationDeleteParameter parameter)
        {
            return await this.SendAsync<NamedlocationDeleteParameter, NamedlocationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/namedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<NamedlocationDeleteResponse> NamedlocationDeleteAsync(NamedlocationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NamedlocationDeleteParameter, NamedlocationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
