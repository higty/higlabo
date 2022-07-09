using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContractGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Contracts_Id: return $"/contracts/{Id}";
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
            Contracts_Id,
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
    public partial class ContractGetResponse : RestApiResponse
    {
        public string? ContractType { get; set; }
        public Guid? CustomerId { get; set; }
        public string? DefaultDomainName { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contract-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ContractGetResponse> ContractGetAsync()
        {
            var p = new ContractGetParameter();
            return await this.SendAsync<ContractGetParameter, ContractGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contract-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ContractGetResponse> ContractGetAsync(CancellationToken cancellationToken)
        {
            var p = new ContractGetParameter();
            return await this.SendAsync<ContractGetParameter, ContractGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contract-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ContractGetResponse> ContractGetAsync(ContractGetParameter parameter)
        {
            return await this.SendAsync<ContractGetParameter, ContractGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contract-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ContractGetResponse> ContractGetAsync(ContractGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContractGetParameter, ContractGetResponse>(parameter, cancellationToken);
        }
    }
}
