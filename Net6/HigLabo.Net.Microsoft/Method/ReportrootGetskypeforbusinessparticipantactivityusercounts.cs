using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootGetskypeforbusinessparticipantactivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessParticipantActivityUserCounts: return $"/reports/getSkypeForBusinessParticipantActivityUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessParticipantActivityUserCounts,
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
    public partial class ReportRootGetskypeforbusinessparticipantactivityUsercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessparticipantactivityUsercountsResponse> ReportRootGetskypeforbusinessparticipantactivityUsercountsAsync()
        {
            var p = new ReportRootGetskypeforbusinessparticipantactivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessparticipantactivityUsercountsParameter, ReportRootGetskypeforbusinessparticipantactivityUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessparticipantactivityUsercountsResponse> ReportRootGetskypeforbusinessparticipantactivityUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetskypeforbusinessparticipantactivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessparticipantactivityUsercountsParameter, ReportRootGetskypeforbusinessparticipantactivityUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessparticipantactivityUsercountsResponse> ReportRootGetskypeforbusinessparticipantactivityUsercountsAsync(ReportRootGetskypeforbusinessparticipantactivityUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessparticipantactivityUsercountsParameter, ReportRootGetskypeforbusinessparticipantactivityUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinessparticipantactivityUsercountsResponse> ReportRootGetskypeforbusinessparticipantactivityUsercountsAsync(ReportRootGetskypeforbusinessparticipantactivityUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessparticipantactivityUsercountsParameter, ReportRootGetskypeforbusinessparticipantactivityUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
