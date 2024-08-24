using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetSkypeforBusinessActivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessActivityCounts: return $"/reports/getSkypeForBusinessActivityCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessActivityCounts,
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
    public partial class ReportRootGetSkypeforBusinessActivitycountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessActivitycountsResponse> ReportRootGetSkypeforBusinessActivitycountsAsync()
        {
            var p = new ReportRootGetSkypeforBusinessActivitycountsParameter();
            return await this.SendAsync<ReportRootGetSkypeforBusinessActivitycountsParameter, ReportRootGetSkypeforBusinessActivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessActivitycountsResponse> ReportRootGetSkypeforBusinessActivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetSkypeforBusinessActivitycountsParameter();
            return await this.SendAsync<ReportRootGetSkypeforBusinessActivitycountsParameter, ReportRootGetSkypeforBusinessActivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessActivitycountsResponse> ReportRootGetSkypeforBusinessActivitycountsAsync(ReportRootGetSkypeforBusinessActivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetSkypeforBusinessActivitycountsParameter, ReportRootGetSkypeforBusinessActivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessActivitycountsResponse> ReportRootGetSkypeforBusinessActivitycountsAsync(ReportRootGetSkypeforBusinessActivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetSkypeforBusinessActivitycountsParameter, ReportRootGetSkypeforBusinessActivitycountsResponse>(parameter, cancellationToken);
        }
    }
}
