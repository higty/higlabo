using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContractListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Contracts: return $"/contracts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ContractType,
            CustomerId,
            DefaultDomainName,
            DisplayName,
            Id,
        }
        public enum ApiPath
        {
            Contracts,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
