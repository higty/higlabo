using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AttendancerecordListParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_OnlineMeetings_MeetingId_AttendanceReports_ReportId_AttendanceRecords: return $"/me/onlineMeetings/{MeetingId}/attendanceReports/{ReportId}/attendanceRecords";
                    case ApiPath.Users_UserId_OnlineMeetings_MeetingId_AttendanceReports_ReportId_AttendanceRecords: return $"/users/{UserId}/onlineMeetings/{MeetingId}/attendanceReports/{ReportId}/attendanceRecords";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AttendanceIntervals,
            EmailAddress,
            Identity,
            Role,
            TotalAttendanceInSeconds,
        }
        public enum ApiPath
        {
            Me_OnlineMeetings_MeetingId_AttendanceReports_ReportId_AttendanceRecords,
            Users_UserId_OnlineMeetings_MeetingId_AttendanceReports_ReportId_AttendanceRecords,
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
    public partial class AttendancerecordListResponse : RestApiResponse
    {
        public AttendanceRecord[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/attendancerecord-list?view=graph-rest-1.0
        /// </summary>
        public async Task<AttendancerecordListResponse> AttendancerecordListAsync()
        {
            var p = new AttendancerecordListParameter();
            return await this.SendAsync<AttendancerecordListParameter, AttendancerecordListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/attendancerecord-list?view=graph-rest-1.0
        /// </summary>
        public async Task<AttendancerecordListResponse> AttendancerecordListAsync(CancellationToken cancellationToken)
        {
            var p = new AttendancerecordListParameter();
            return await this.SendAsync<AttendancerecordListParameter, AttendancerecordListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/attendancerecord-list?view=graph-rest-1.0
        /// </summary>
        public async Task<AttendancerecordListResponse> AttendancerecordListAsync(AttendancerecordListParameter parameter)
        {
            return await this.SendAsync<AttendancerecordListParameter, AttendancerecordListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/attendancerecord-list?view=graph-rest-1.0
        /// </summary>
        public async Task<AttendancerecordListResponse> AttendancerecordListAsync(AttendancerecordListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AttendancerecordListParameter, AttendancerecordListResponse>(parameter, cancellationToken);
        }
    }
}
