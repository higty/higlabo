using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contract-list?view=graph-rest-1.0
    /// </summary>
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
    public partial class ContractListResponse : RestApiResponse<Contract>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contract-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contract-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContractListResponse> ContractListAsync()
        {
            var p = new ContractListParameter();
            return await this.SendAsync<ContractListParameter, ContractListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contract-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContractListResponse> ContractListAsync(CancellationToken cancellationToken)
        {
            var p = new ContractListParameter();
            return await this.SendAsync<ContractListParameter, ContractListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contract-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContractListResponse> ContractListAsync(ContractListParameter parameter)
        {
            return await this.SendAsync<ContractListParameter, ContractListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contract-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContractListResponse> ContractListAsync(ContractListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContractListParameter, ContractListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contract-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Contract> ContractListEnumerateAsync(ContractListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ContractListParameter, ContractListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Contract>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
