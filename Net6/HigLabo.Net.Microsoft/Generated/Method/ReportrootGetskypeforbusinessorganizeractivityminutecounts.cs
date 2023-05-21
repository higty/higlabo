using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetskypeforbusinessorganizeractivityminutecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessOrganizerActivityMinuteCounts: return $"/reports/getSkypeForBusinessOrganizerActivityMinuteCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessOrganizerActivityMinuteCounts,
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
    public partial class ReportRootGetskypeforbusinessorganizeractivityminutecountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessorganizeractivityminutecountsResponse> ReportRootGetskypeforbusinessorganizeractivityminutecountsAsync()
        {
            var p = new ReportRootGetskypeforbusinessorganizeractivityminutecountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessorganizeractivityminutecountsParameter, ReportRootGetskypeforbusinessorganizeractivityminutecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessorganizeractivityminutecountsResponse> ReportRootGetskypeforbusinessorganizeractivityminutecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetskypeforbusinessorganizeractivityminutecountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessorganizeractivityminutecountsParameter, ReportRootGetskypeforbusinessorganizeractivityminutecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessorganizeractivityminutecountsResponse> ReportRootGetskypeforbusinessorganizeractivityminutecountsAsync(ReportRootGetskypeforbusinessorganizeractivityminutecountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessorganizeractivityminutecountsParameter, ReportRootGetskypeforbusinessorganizeractivityminutecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessorganizeractivityminutecountsResponse> ReportRootGetskypeforbusinessorganizeractivityminutecountsAsync(ReportRootGetskypeforbusinessorganizeractivityminutecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessorganizeractivityminutecountsParameter, ReportRootGetskypeforbusinessorganizeractivityminutecountsResponse>(parameter, cancellationToken);
        }
    }
}
