using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetskypeforbusinessactivitycountsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetskypeforbusinessactivitycountsResponse : RestApiResponse
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
        public async ValueTask<ReportRootGetskypeforbusinessactivitycountsResponse> ReportRootGetskypeforbusinessactivitycountsAsync()
        {
            var p = new ReportRootGetskypeforbusinessactivitycountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessactivitycountsParameter, ReportRootGetskypeforbusinessactivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessactivitycountsResponse> ReportRootGetskypeforbusinessactivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetskypeforbusinessactivitycountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessactivitycountsParameter, ReportRootGetskypeforbusinessactivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessactivitycountsResponse> ReportRootGetskypeforbusinessactivitycountsAsync(ReportRootGetskypeforbusinessactivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessactivitycountsParameter, ReportRootGetskypeforbusinessactivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessactivitycountsResponse> ReportRootGetskypeforbusinessactivitycountsAsync(ReportRootGetskypeforbusinessactivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessactivitycountsParameter, ReportRootGetskypeforbusinessactivitycountsResponse>(parameter, cancellationToken);
        }
    }
}
