using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/meetingattendancereport-get?view=graph-rest-1.0
    /// </summary>
    public partial class MeetingattendancereportGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? MeetingId { get; set; }
            public string? ReportId { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_OnlineMeetings_MeetingId_AttendanceReports_ReportId: return $"/me/onlineMeetings/{MeetingId}/attendanceReports/{ReportId}";
                    case ApiPath.Users_UserId_OnlineMeetings_MeetingId_AttendanceReports_ReportId: return $"/users/{UserId}/onlineMeetings/{MeetingId}/attendanceReports/{ReportId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_OnlineMeetings_MeetingId_AttendanceReports_ReportId,
            Users_UserId_OnlineMeetings_MeetingId_AttendanceReports_ReportId,
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
    public partial class MeetingattendancereportGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? MeetingEndDateTime { get; set; }
        public DateTimeOffset? MeetingStartDateTime { get; set; }
        public Int32? TotalParticipantCount { get; set; }
        public AttendanceRecord[]? AttendanceRecords { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/meetingattendancereport-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/meetingattendancereport-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MeetingattendancereportGetResponse> MeetingattendancereportGetAsync()
        {
            var p = new MeetingattendancereportGetParameter();
            return await this.SendAsync<MeetingattendancereportGetParameter, MeetingattendancereportGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/meetingattendancereport-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MeetingattendancereportGetResponse> MeetingattendancereportGetAsync(CancellationToken cancellationToken)
        {
            var p = new MeetingattendancereportGetParameter();
            return await this.SendAsync<MeetingattendancereportGetParameter, MeetingattendancereportGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/meetingattendancereport-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MeetingattendancereportGetResponse> MeetingattendancereportGetAsync(MeetingattendancereportGetParameter parameter)
        {
            return await this.SendAsync<MeetingattendancereportGetParameter, MeetingattendancereportGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/meetingattendancereport-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MeetingattendancereportGetResponse> MeetingattendancereportGetAsync(MeetingattendancereportGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MeetingattendancereportGetParameter, MeetingattendancereportGetResponse>(parameter, cancellationToken);
        }
    }
}
