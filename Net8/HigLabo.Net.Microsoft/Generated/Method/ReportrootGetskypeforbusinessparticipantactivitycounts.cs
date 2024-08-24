using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetSkypeforBusinessparticipantActivitycountsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetSkypeforBusinessparticipantActivitycountsResponse : RestApiResponse
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
        public async ValueTask<ReportRootGetSkypeforBusinessparticipantActivitycountsResponse> ReportRootGetSkypeforBusinessparticipantActivitycountsAsync()
        {
            var p = new ReportRootGetSkypeforBusinessparticipantActivitycountsParameter();
            return await this.SendAsync<ReportRootGetSkypeforBusinessparticipantActivitycountsParameter, ReportRootGetSkypeforBusinessparticipantActivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessparticipantActivitycountsResponse> ReportRootGetSkypeforBusinessparticipantActivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetSkypeforBusinessparticipantActivitycountsParameter();
            return await this.SendAsync<ReportRootGetSkypeforBusinessparticipantActivitycountsParameter, ReportRootGetSkypeforBusinessparticipantActivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessparticipantActivitycountsResponse> ReportRootGetSkypeforBusinessparticipantActivitycountsAsync(ReportRootGetSkypeforBusinessparticipantActivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetSkypeforBusinessparticipantActivitycountsParameter, ReportRootGetSkypeforBusinessparticipantActivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessparticipantActivitycountsResponse> ReportRootGetSkypeforBusinessparticipantActivitycountsAsync(ReportRootGetSkypeforBusinessparticipantActivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetSkypeforBusinessparticipantActivitycountsParameter, ReportRootGetSkypeforBusinessparticipantActivitycountsResponse>(parameter, cancellationToken);
        }
    }
}
