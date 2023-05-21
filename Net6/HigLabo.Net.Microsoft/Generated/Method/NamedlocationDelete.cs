using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/namedlocation-delete?view=graph-rest-1.0
    /// </summary>
    public partial class NamedLocationDeleteParameter : IRestApiParameter
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
    public partial class NamedLocationDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/namedlocation-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/namedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<NamedLocationDeleteResponse> NamedLocationDeleteAsync()
        {
            var p = new NamedLocationDeleteParameter();
            return await this.SendAsync<NamedLocationDeleteParameter, NamedLocationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/namedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<NamedLocationDeleteResponse> NamedLocationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new NamedLocationDeleteParameter();
            return await this.SendAsync<NamedLocationDeleteParameter, NamedLocationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/namedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<NamedLocationDeleteResponse> NamedLocationDeleteAsync(NamedLocationDeleteParameter parameter)
        {
            return await this.SendAsync<NamedLocationDeleteParameter, NamedLocationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/namedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<NamedLocationDeleteResponse> NamedLocationDeleteAsync(NamedLocationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NamedLocationDeleteParameter, NamedLocationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
