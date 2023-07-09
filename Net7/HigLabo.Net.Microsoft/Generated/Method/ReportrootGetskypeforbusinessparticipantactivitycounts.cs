using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetskypeforbusinessparticipantactivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessParticipantActivityCounts: return $"/reports/getSkypeForBusinessParticipantActivityCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessParticipantActivityCounts,
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
    public partial class ReportRootGetskypeforbusinessparticipantactivitycountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessparticipantactivitycountsResponse> ReportRootGetskypeforbusinessparticipantactivitycountsAsync()
        {
            var p = new ReportRootGetskypeforbusinessparticipantactivitycountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessparticipantactivitycountsParameter, ReportRootGetskypeforbusinessparticipantactivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessparticipantactivitycountsResponse> ReportRootGetskypeforbusinessparticipantactivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetskypeforbusinessparticipantactivitycountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessparticipantactivitycountsParameter, ReportRootGetskypeforbusinessparticipantactivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessparticipantactivitycountsResponse> ReportRootGetskypeforbusinessparticipantactivitycountsAsync(ReportRootGetskypeforbusinessparticipantactivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessparticipantactivitycountsParameter, ReportRootGetskypeforbusinessparticipantactivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessparticipantactivitycountsResponse> ReportRootGetskypeforbusinessparticipantactivitycountsAsync(ReportRootGetskypeforbusinessparticipantactivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessparticipantactivitycountsParameter, ReportRootGetskypeforbusinessparticipantactivitycountsResponse>(parameter, cancellationToken);
        }
    }
}
