using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ClaimsmappingpolicyListAppliestoParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_ClaimsMappingPolicies_Id_AppliesTo,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_ClaimsMappingPolicies_Id_AppliesTo: return $"/policies/claimsMappingPolicies/{Id}/appliesTo";
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
        public string Id { get; set; }
    }
    public partial class ClaimsmappingpolicyListAppliestoResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryobject?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryObject
        {
            public DateTimeOffset? DeletedDateTime { get; set; }
            public string? Id { get; set; }
        }

        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyListAppliestoResponse> ClaimsmappingpolicyListAppliestoAsync()
        {
            var p = new ClaimsmappingpolicyListAppliestoParameter();
            return await this.SendAsync<ClaimsmappingpolicyListAppliestoParameter, ClaimsmappingpolicyListAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyListAppliestoResponse> ClaimsmappingpolicyListAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new ClaimsmappingpolicyListAppliestoParameter();
            return await this.SendAsync<ClaimsmappingpolicyListAppliestoParameter, ClaimsmappingpolicyListAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyListAppliestoResponse> ClaimsmappingpolicyListAppliestoAsync(ClaimsmappingpolicyListAppliestoParameter parameter)
        {
            return await this.SendAsync<ClaimsmappingpolicyListAppliestoParameter, ClaimsmappingpolicyListAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyListAppliestoResponse> ClaimsmappingpolicyListAppliestoAsync(ClaimsmappingpolicyListAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ClaimsmappingpolicyListAppliestoParameter, ClaimsmappingpolicyListAppliestoResponse>(parameter, cancellationToken);
        }
    }
}
