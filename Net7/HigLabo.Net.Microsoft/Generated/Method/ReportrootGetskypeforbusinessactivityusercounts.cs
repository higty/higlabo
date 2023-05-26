using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetskypeforbusinessactivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessActivityUserCounts: return $"/reports/getSkypeForBusinessActivityUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessActivityUserCounts,
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
    public partial class ReportRootGetskypeforbusinessactivityUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessactivityUsercountsResponse> ReportRootGetskypeforbusinessactivityUsercountsAsync()
        {
            var p = new ReportRootGetskypeforbusinessactivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessactivityUsercountsParameter, ReportRootGetskypeforbusinessactivityUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessactivityUsercountsResponse> ReportRootGetskypeforbusinessactivityUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetskypeforbusinessactivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessactivityUsercountsParameter, ReportRootGetskypeforbusinessactivityUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessactivityUsercountsResponse> ReportRootGetskypeforbusinessactivityUsercountsAsync(ReportRootGetskypeforbusinessactivityUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessactivityUsercountsParameter, ReportRootGetskypeforbusinessactivityUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessactivityUsercountsResponse> ReportRootGetskypeforbusinessactivityUsercountsAsync(ReportRootGetskypeforbusinessactivityUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessactivityUsercountsParameter, ReportRootGetskypeforbusinessactivityUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
