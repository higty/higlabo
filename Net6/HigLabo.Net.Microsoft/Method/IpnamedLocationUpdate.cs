using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IpnamedLocationUpdateParameter : IRestApiParameter
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
        public string? DisplayName { get; set; }
        public IpRange[]? IpRanges { get; set; }
        public bool? IsTrusted { get; set; }
    }
    public partial class IpnamedLocationUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/ipnamedlocation-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IpnamedLocationUpdateResponse> IpnamedLocationUpdateAsync()
        {
            var p = new IpnamedLocationUpdateParameter();
            return await this.SendAsync<IpnamedLocationUpdateParameter, IpnamedLocationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/ipnamedlocation-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IpnamedLocationUpdateResponse> IpnamedLocationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new IpnamedLocationUpdateParameter();
            return await this.SendAsync<IpnamedLocationUpdateParameter, IpnamedLocationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/ipnamedlocation-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IpnamedLocationUpdateResponse> IpnamedLocationUpdateAsync(IpnamedLocationUpdateParameter parameter)
        {
            return await this.SendAsync<IpnamedLocationUpdateParameter, IpnamedLocationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/ipnamedlocation-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IpnamedLocationUpdateResponse> IpnamedLocationUpdateAsync(IpnamedLocationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IpnamedLocationUpdateParameter, IpnamedLocationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
