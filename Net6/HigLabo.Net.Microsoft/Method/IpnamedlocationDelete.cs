using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IpnamedlocationDeleteParameter : IRestApiParameter
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
    public partial class IpnamedlocationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/ipnamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IpnamedlocationDeleteResponse> IpnamedlocationDeleteAsync()
        {
            var p = new IpnamedlocationDeleteParameter();
            return await this.SendAsync<IpnamedlocationDeleteParameter, IpnamedlocationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/ipnamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IpnamedlocationDeleteResponse> IpnamedlocationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IpnamedlocationDeleteParameter();
            return await this.SendAsync<IpnamedlocationDeleteParameter, IpnamedlocationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/ipnamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IpnamedlocationDeleteResponse> IpnamedlocationDeleteAsync(IpnamedlocationDeleteParameter parameter)
        {
            return await this.SendAsync<IpnamedlocationDeleteParameter, IpnamedlocationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/ipnamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IpnamedlocationDeleteResponse> IpnamedlocationDeleteAsync(IpnamedlocationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IpnamedlocationDeleteParameter, IpnamedlocationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
