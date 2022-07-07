using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DomainForcedeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Domains_Id_ForceDelete,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Domains_Id_ForceDelete: return $"/domains/{Id}/forceDelete";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public bool? DisableUserAccounts { get; set; }
        public string Id { get; set; }
    }
    public partial class DomainForcedeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-forcedelete?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainForcedeleteResponse> DomainForcedeleteAsync()
        {
            var p = new DomainForcedeleteParameter();
            return await this.SendAsync<DomainForcedeleteParameter, DomainForcedeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-forcedelete?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainForcedeleteResponse> DomainForcedeleteAsync(CancellationToken cancellationToken)
        {
            var p = new DomainForcedeleteParameter();
            return await this.SendAsync<DomainForcedeleteParameter, DomainForcedeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-forcedelete?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainForcedeleteResponse> DomainForcedeleteAsync(DomainForcedeleteParameter parameter)
        {
            return await this.SendAsync<DomainForcedeleteParameter, DomainForcedeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-forcedelete?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainForcedeleteResponse> DomainForcedeleteAsync(DomainForcedeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainForcedeleteParameter, DomainForcedeleteResponse>(parameter, cancellationToken);
        }
    }
}
