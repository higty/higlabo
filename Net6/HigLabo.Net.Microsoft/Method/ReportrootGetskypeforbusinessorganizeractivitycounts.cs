using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetskypeforbusinessorganizeractivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessOrganizerActivityCounts: return $"/reports/getSkypeForBusinessOrganizerActivityCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessOrganizerActivityCounts,
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
    public partial class ReportRootGetskypeforbusinessorganizeractivitycountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessorganizeractivitycountsResponse> ReportRootGetskypeforbusinessorganizeractivitycountsAsync()
        {
            var p = new ReportRootGetskypeforbusinessorganizeractivitycountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessorganizeractivitycountsParameter, ReportRootGetskypeforbusinessorganizeractivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessorganizeractivitycountsResponse> ReportRootGetskypeforbusinessorganizeractivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetskypeforbusinessorganizeractivitycountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessorganizeractivitycountsParameter, ReportRootGetskypeforbusinessorganizeractivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessorganizeractivitycountsResponse> ReportRootGetskypeforbusinessorganizeractivitycountsAsync(ReportRootGetskypeforbusinessorganizeractivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessorganizeractivitycountsParameter, ReportRootGetskypeforbusinessorganizeractivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessorganizeractivitycountsResponse> ReportRootGetskypeforbusinessorganizeractivitycountsAsync(ReportRootGetskypeforbusinessorganizeractivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessorganizeractivitycountsParameter, ReportRootGetskypeforbusinessorganizeractivitycountsResponse>(parameter, cancellationToken);
        }
    }
}
