using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class TokenlifetimePolicyListAppliestoParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_TokenLifetimePolicies_Id_AppliesTo: return $"/policies/tokenLifetimePolicies/{Id}/appliesTo";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_TokenLifetimePolicies_Id_AppliesTo,
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
    public partial class TokenlifetimePolicyListAppliestoResponse : RestApiResponse<DirectoryObject>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TokenlifetimePolicyListAppliestoResponse> TokenlifetimePolicyListAppliestoAsync()
        {
            var p = new TokenlifetimePolicyListAppliestoParameter();
            return await this.SendAsync<TokenlifetimePolicyListAppliestoParameter, TokenlifetimePolicyListAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TokenlifetimePolicyListAppliestoResponse> TokenlifetimePolicyListAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new TokenlifetimePolicyListAppliestoParameter();
            return await this.SendAsync<TokenlifetimePolicyListAppliestoParameter, TokenlifetimePolicyListAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TokenlifetimePolicyListAppliestoResponse> TokenlifetimePolicyListAppliestoAsync(TokenlifetimePolicyListAppliestoParameter parameter)
        {
            return await this.SendAsync<TokenlifetimePolicyListAppliestoParameter, TokenlifetimePolicyListAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TokenlifetimePolicyListAppliestoResponse> TokenlifetimePolicyListAppliestoAsync(TokenlifetimePolicyListAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TokenlifetimePolicyListAppliestoParameter, TokenlifetimePolicyListAppliestoResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryObject> TokenlifetimePolicyListAppliestoEnumerateAsync(TokenlifetimePolicyListAppliestoParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<TokenlifetimePolicyListAppliestoParameter, TokenlifetimePolicyListAppliestoResponse>(parameter, cancellationToken);
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
