using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class TokenissuancePolicyListAppliestoParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_TokenIssuancePolicies_Id_AppliesTo: return $"/policies/tokenIssuancePolicies/{Id}/appliesTo";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_TokenIssuancePolicies_Id_AppliesTo,
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
    public partial class TokenissuancePolicyListAppliestoResponse : RestApiResponse<DirectoryObject>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TokenissuancePolicyListAppliestoResponse> TokenissuancePolicyListAppliestoAsync()
        {
            var p = new TokenissuancePolicyListAppliestoParameter();
            return await this.SendAsync<TokenissuancePolicyListAppliestoParameter, TokenissuancePolicyListAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TokenissuancePolicyListAppliestoResponse> TokenissuancePolicyListAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new TokenissuancePolicyListAppliestoParameter();
            return await this.SendAsync<TokenissuancePolicyListAppliestoParameter, TokenissuancePolicyListAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TokenissuancePolicyListAppliestoResponse> TokenissuancePolicyListAppliestoAsync(TokenissuancePolicyListAppliestoParameter parameter)
        {
            return await this.SendAsync<TokenissuancePolicyListAppliestoParameter, TokenissuancePolicyListAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TokenissuancePolicyListAppliestoResponse> TokenissuancePolicyListAppliestoAsync(TokenissuancePolicyListAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenissuancePolicyListAppliestoParameter, TokenissuancePolicyListAppliestoResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryObject> TokenissuancePolicyListAppliestoEnumerateAsync(TokenissuancePolicyListAppliestoParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<TokenissuancePolicyListAppliestoParameter, TokenissuancePolicyListAppliestoResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
