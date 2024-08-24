using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetSkypeforBusinesspeertopeerActivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessPeerToPeerActivityCounts: return $"/reports/getSkypeForBusinessPeerToPeerActivityCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessPeerToPeerActivityCounts,
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
    public partial class ReportRootGetSkypeforBusinesspeertopeerActivitycountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinesspeertopeerActivitycountsResponse> ReportRootGetSkypeforBusinesspeertopeerActivitycountsAsync()
        {
            var p = new ReportRootGetSkypeforBusinesspeertopeerActivitycountsParameter();
            return await this.SendAsync<ReportRootGetSkypeforBusinesspeertopeerActivitycountsParameter, ReportRootGetSkypeforBusinesspeertopeerActivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinesspeertopeerActivitycountsResponse> ReportRootGetSkypeforBusinesspeertopeerActivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetSkypeforBusinesspeertopeerActivitycountsParameter();
            return await this.SendAsync<ReportRootGetSkypeforBusinesspeertopeerActivitycountsParameter, ReportRootGetSkypeforBusinesspeertopeerActivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinesspeertopeerActivitycountsResponse> ReportRootGetSkypeforBusinesspeertopeerActivitycountsAsync(ReportRootGetSkypeforBusinesspeertopeerActivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetSkypeforBusinesspeertopeerActivitycountsParameter, ReportRootGetSkypeforBusinesspeertopeerActivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinesspeertopeerActivitycountsResponse> ReportRootGetSkypeforBusinesspeertopeerActivitycountsAsync(ReportRootGetSkypeforBusinesspeertopeerActivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetSkypeforBusinesspeertopeerActivitycountsParameter, ReportRootGetSkypeforBusinesspeertopeerActivitycountsResponse>(parameter, cancellationToken);
        }
    }
}
