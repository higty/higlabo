using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallrecordsCallrecordGetdirectroutingcallsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            EndDateTime,
            Id,
            JoinWebUrl,
            LastModifiedDateTime,
            Modalities,
            Organizer,
            Participants,
            StartDateTime,
            Type,
            Version,
        }
        public enum ApiPath
        {
            Communications_CallRecords_GetDirectRoutingCalls,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_CallRecords_GetDirectRoutingCalls: return $"/communications/callRecords/getDirectRoutingCalls";
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
    }
    public partial class CallrecordsCallrecordGetdirectroutingcallsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-directroutinglogrow?view=graph-rest-1.0
        /// </summary>
        public partial class CallrecordsDirectroutinglogrow
        {
            public Int32? CallEndSubReason { get; set; }
            public string? CallType { get; set; }
            public string? CalleeNumber { get; set; }
            public string? CallerNumber { get; set; }
            public string? CorrelationId { get; set; }
            public Int32? Duration { get; set; }
            public DateTimeOffset? EndDateTime { get; set; }
            public DateTimeOffset? FailureDateTime { get; set; }
            public string? FinalSipCodePhrase { get; set; }
            public Int32? FinalSipCode { get; set; }
            public string? Id { get; set; }
            public DateTimeOffset? InviteDateTime { get; set; }
            public bool? MediaBypassEnabled { get; set; }
            public string? MediaPathLocation { get; set; }
            public string? SignalingLocation { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
            public bool? SuccessfulCall { get; set; }
            public string? TrunkFullyQualifiedDomainName { get; set; }
            public string? UserDisplayName { get; set; }
            public string? UserId { get; set; }
            public string? UserPrincipalName { get; set; }
        }

        public CallrecordsDirectroutinglogrow[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-callrecord-getdirectroutingcalls?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsCallrecordGetdirectroutingcallsResponse> CallrecordsCallrecordGetdirectroutingcallsAsync()
        {
            var p = new CallrecordsCallrecordGetdirectroutingcallsParameter();
            return await this.SendAsync<CallrecordsCallrecordGetdirectroutingcallsParameter, CallrecordsCallrecordGetdirectroutingcallsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-callrecord-getdirectroutingcalls?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsCallrecordGetdirectroutingcallsResponse> CallrecordsCallrecordGetdirectroutingcallsAsync(CancellationToken cancellationToken)
        {
            var p = new CallrecordsCallrecordGetdirectroutingcallsParameter();
            return await this.SendAsync<CallrecordsCallrecordGetdirectroutingcallsParameter, CallrecordsCallrecordGetdirectroutingcallsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-callrecord-getdirectroutingcalls?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsCallrecordGetdirectroutingcallsResponse> CallrecordsCallrecordGetdirectroutingcallsAsync(CallrecordsCallrecordGetdirectroutingcallsParameter parameter)
        {
            return await this.SendAsync<CallrecordsCallrecordGetdirectroutingcallsParameter, CallrecordsCallrecordGetdirectroutingcallsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-callrecord-getdirectroutingcalls?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsCallrecordGetdirectroutingcallsResponse> CallrecordsCallrecordGetdirectroutingcallsAsync(CallrecordsCallrecordGetdirectroutingcallsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallrecordsCallrecordGetdirectroutingcallsParameter, CallrecordsCallrecordGetdirectroutingcallsResponse>(parameter, cancellationToken);
        }
    }
}
