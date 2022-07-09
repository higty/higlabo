using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteListOperationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Operations: return $"/sites/{SiteId}/operations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            Error,
            Id,
            LastActionDateTime,
            PercentageComplete,
            ResourceId,
            ResourceLocation,
            Status,
            StatusDetail,
            Type,
        }
        public enum ApiPath
        {
            Sites_SiteId_Operations,
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
    public partial class SiteListOperationsResponse : RestApiResponse
    {
        public RichLongRunningOperation[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListOperationsResponse> SiteListOperationsAsync()
        {
            var p = new SiteListOperationsParameter();
            return await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListOperationsResponse> SiteListOperationsAsync(CancellationToken cancellationToken)
        {
            var p = new SiteListOperationsParameter();
            return await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListOperationsResponse> SiteListOperationsAsync(SiteListOperationsParameter parameter)
        {
            return await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-operations?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListOperationsResponse> SiteListOperationsAsync(SiteListOperationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteListOperationsParameter, SiteListOperationsResponse>(parameter, cancellationToken);
        }
    }
}
