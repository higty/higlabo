using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SubscribedskuListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            SubscribedSkus,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.SubscribedSkus: return $"/subscribedSkus";
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
    public partial class SubscribedskuListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/subscribedsku?view=graph-rest-1.0
        /// </summary>
        public partial class SubscribedSku
        {
            public string? AppliesTo { get; set; }
            public string? CapabilityStatus { get; set; }
            public Int32? ConsumedUnits { get; set; }
            public string? Id { get; set; }
            public LicenseUnitsDetail? PrepaidUnits { get; set; }
            public ServicePlanInfo[]? ServicePlans { get; set; }
            public Guid? SkuId { get; set; }
            public string? SkuPartNumber { get; set; }
        }

        public SubscribedSku[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subscribedsku-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscribedskuListResponse> SubscribedskuListAsync()
        {
            var p = new SubscribedskuListParameter();
            return await this.SendAsync<SubscribedskuListParameter, SubscribedskuListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subscribedsku-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscribedskuListResponse> SubscribedskuListAsync(CancellationToken cancellationToken)
        {
            var p = new SubscribedskuListParameter();
            return await this.SendAsync<SubscribedskuListParameter, SubscribedskuListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subscribedsku-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscribedskuListResponse> SubscribedskuListAsync(SubscribedskuListParameter parameter)
        {
            return await this.SendAsync<SubscribedskuListParameter, SubscribedskuListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subscribedsku-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscribedskuListResponse> SubscribedskuListAsync(SubscribedskuListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubscribedskuListParameter, SubscribedskuListResponse>(parameter, cancellationToken);
        }
    }
}
