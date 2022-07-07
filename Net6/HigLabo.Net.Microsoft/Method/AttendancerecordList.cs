using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AttendancerecordListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_OnlineMeetings_MeetingId_AttendanceReports_ReportId_AttendanceRecords,
            Users_UserId_OnlineMeetings_MeetingId_AttendanceReports_ReportId_AttendanceRecords,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_OnlineMeetings_MeetingId_AttendanceReports_ReportId_AttendanceRecords: return $"/me/onlineMeetings/{MeetingId}/attendanceReports/{ReportId}/attendanceRecords";
                    case ApiPath.Users_UserId_OnlineMeetings_MeetingId_AttendanceReports_ReportId_AttendanceRecords: return $"/users/{UserId}/onlineMeetings/{MeetingId}/attendanceReports/{ReportId}/attendanceRecords";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string MeetingId { get; set; }
        public string ReportId { get; set; }
        public string UserId { get; set; }
    }
    public partial class AttendancerecordListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/attendancerecord?view=graph-rest-1.0
        /// </summary>
        public partial class AttendanceRecord
        {
            public AttendanceInterval[]? AttendanceIntervals { get; set; }
            public string? EmailAddress { get; set; }
            public Identity? Identity { get; set; }
            public string? Role { get; set; }
            public Int32? TotalAttendanceInSeconds { get; set; }
        }

        public AttendanceRecord[] Value { get; set; }
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
