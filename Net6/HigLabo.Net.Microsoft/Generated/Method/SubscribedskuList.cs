using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subscribedsku-list?view=graph-rest-1.0
    /// </summary>
    public partial class SubscribedskuListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.SubscribedSkus: return $"/subscribedSkus";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AppliesTo,
            CapabilityStatus,
            ConsumedUnits,
            Id,
            PrepaidUnits,
            ServicePlans,
            SkuId,
            SkuPartNumber,
        }
        public enum ApiPath
        {
            SubscribedSkus,
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
    public partial class SubscribedskuListResponse : RestApiResponse
    {
        public SubscribedSku[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subscribedsku-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subscribedsku-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscribedskuListResponse> SubscribedskuListAsync()
        {
            var p = new SubscribedskuListParameter();
            return await this.SendAsync<SubscribedskuListParameter, SubscribedskuListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subscribedsku-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscribedskuListResponse> SubscribedskuListAsync(CancellationToken cancellationToken)
        {
            var p = new SubscribedskuListParameter();
            return await this.SendAsync<SubscribedskuListParameter, SubscribedskuListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subscribedsku-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscribedskuListResponse> SubscribedskuListAsync(SubscribedskuListParameter parameter)
        {
            return await this.SendAsync<SubscribedskuListParameter, SubscribedskuListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subscribedsku-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscribedskuListResponse> SubscribedskuListAsync(SubscribedskuListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubscribedskuListParameter, SubscribedskuListResponse>(parameter, cancellationToken);
        }
    }
}
