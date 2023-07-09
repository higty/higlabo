using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/ipnamedlocation-delete?view=graph-rest-1.0
    /// </summary>
    public partial class IpnamedLocationDeleteParameter : IRestApiParameter
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
    public partial class IpnamedLocationDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/ipnamedlocation-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/ipnamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IpnamedLocationDeleteResponse> IpnamedLocationDeleteAsync()
        {
            var p = new IpnamedLocationDeleteParameter();
            return await this.SendAsync<IpnamedLocationDeleteParameter, IpnamedLocationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/ipnamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IpnamedLocationDeleteResponse> IpnamedLocationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IpnamedLocationDeleteParameter();
            return await this.SendAsync<IpnamedLocationDeleteParameter, IpnamedLocationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/ipnamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IpnamedLocationDeleteResponse> IpnamedLocationDeleteAsync(IpnamedLocationDeleteParameter parameter)
        {
            return await this.SendAsync<IpnamedLocationDeleteParameter, IpnamedLocationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/ipnamedlocation-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IpnamedLocationDeleteResponse> IpnamedLocationDeleteAsync(IpnamedLocationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IpnamedLocationDeleteParameter, IpnamedLocationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
