using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-update?view=graph-rest-1.0
    /// </summary>
    public partial class DomainUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Domains_Id: return $"/domains/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Domains_Id,
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
    }
    public partial class DomainUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-update?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainUpdateResponse> DomainUpdateAsync()
        {
            var p = new DomainUpdateParameter();
            return await this.SendAsync<DomainUpdateParameter, DomainUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-update?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainUpdateResponse> DomainUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new DomainUpdateParameter();
            return await this.SendAsync<DomainUpdateParameter, DomainUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-update?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainUpdateResponse> DomainUpdateAsync(DomainUpdateParameter parameter)
        {
            return await this.SendAsync<DomainUpdateParameter, DomainUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-update?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainUpdateResponse> DomainUpdateAsync(DomainUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainUpdateParameter, DomainUpdateResponse>(parameter, cancellationToken);
        }
    }
}
