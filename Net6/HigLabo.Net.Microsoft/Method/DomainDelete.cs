using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DomainDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Domains_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Domains_Id: return $"/domains/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class DomainDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainDeleteResponse> DomainDeleteAsync()
        {
            var p = new DomainDeleteParameter();
            return await this.SendAsync<DomainDeleteParameter, DomainDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainDeleteResponse> DomainDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new DomainDeleteParameter();
            return await this.SendAsync<DomainDeleteParameter, DomainDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainDeleteResponse> DomainDeleteAsync(DomainDeleteParameter parameter)
        {
            return await this.SendAsync<DomainDeleteParameter, DomainDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainDeleteResponse> DomainDeleteAsync(DomainDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainDeleteParameter, DomainDeleteResponse>(parameter, cancellationToken);
        }
    }
}
