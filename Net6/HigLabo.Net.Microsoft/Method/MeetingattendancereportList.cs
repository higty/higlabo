using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MeetingattendancereportListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? MeetingId { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_OnlineMeetings_MeetingId_AttendanceReports: return $"/me/onlineMeetings/{MeetingId}/attendanceReports";
                    case ApiPath.Users_UserId_OnlineMeetings_MeetingId_AttendanceReports: return $"/users/{UserId}/onlineMeetings/{MeetingId}/attendanceReports";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_OnlineMeetings_MeetingId_AttendanceReports,
            Users_UserId_OnlineMeetings_MeetingId_AttendanceReports,
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
    public partial class MeetingattendancereportListResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? MeetingEndDateTime { get; set; }
        public DateTimeOffset? MeetingStartDateTime { get; set; }
        public Int32? TotalParticipantCount { get; set; }
        public AttendanceRecord[]? AttendanceRecords { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/meetingattendancereport-list?view=graph-rest-1.0
        /// </summary>
        public async Task<MeetingattendancereportListResponse> MeetingattendancereportListAsync()
        {
            var p = new MeetingattendancereportListParameter();
            return await this.SendAsync<MeetingattendancereportListParameter, MeetingattendancereportListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/meetingattendancereport-list?view=graph-rest-1.0
        /// </summary>
        public async Task<MeetingattendancereportListResponse> MeetingattendancereportListAsync(CancellationToken cancellationToken)
        {
            var p = new MeetingattendancereportListParameter();
            return await this.SendAsync<MeetingattendancereportListParameter, MeetingattendancereportListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/meetingattendancereport-list?view=graph-rest-1.0
        /// </summary>
        public async Task<MeetingattendancereportListResponse> MeetingattendancereportListAsync(MeetingattendancereportListParameter parameter)
        {
            return await this.SendAsync<MeetingattendancereportListParameter, MeetingattendancereportListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/meetingattendancereport-list?view=graph-rest-1.0
        /// </summary>
        public async Task<MeetingattendancereportListResponse> MeetingattendancereportListAsync(MeetingattendancereportListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MeetingattendancereportListParameter, MeetingattendancereportListResponse>(parameter, cancellationToken);
        }
    }
}
