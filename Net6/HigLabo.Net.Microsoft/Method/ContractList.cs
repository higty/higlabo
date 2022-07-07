using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContractListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Contracts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Contracts: return $"/contracts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class ContractListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/contract?view=graph-rest-1.0
        /// </summary>
        public partial class Contract
        {
            public string? ContractType { get; set; }
            public Guid? CustomerId { get; set; }
            public string? DefaultDomainName { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
        }

        public Contract[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contract-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ContractListResponse> ContractListAsync()
        {
            var p = new ContractListParameter();
            return await this.SendAsync<ContractListParameter, ContractListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contract-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ContractListResponse> ContractListAsync(CancellationToken cancellationToken)
        {
            var p = new ContractListParameter();
            return await this.SendAsync<ContractListParameter, ContractListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contract-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ContractListResponse> ContractListAsync(ContractListParameter parameter)
        {
            return await this.SendAsync<ContractListParameter, ContractListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contract-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ContractListResponse> ContractListAsync(ContractListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContractListParameter, ContractListResponse>(parameter, cancellationToken);
        }
    }
}
