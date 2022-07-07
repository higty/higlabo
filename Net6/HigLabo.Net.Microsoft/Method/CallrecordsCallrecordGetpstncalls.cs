using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallrecordsCallrecordGetpstncallsParameter : IRestApiParameter, IQueryParameterProperty
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
            Communications_CallRecords_GetPstnCalls,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_CallRecords_GetPstnCalls: return $"/communications/callRecords/getPstnCalls";
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
    public partial class CallrecordsCallrecordGetpstncallsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-pstncalllogrow?view=graph-rest-1.0
        /// </summary>
        public partial class CallrecordsPstncalllogrow
        {
            public PstnCallDurationSource? CallDurationSource { get; set; }
            public string? CalleeNumber { get; set; }
            public string? CallerNumber { get; set; }
            public string? CallId { get; set; }
            public string? CallType { get; set; }
            public Double? Charge { get; set; }
            public string? ConferenceId { get; set; }
            public Double? ConnectionCharge { get; set; }
            public string? Currency { get; set; }
            public string? DestinationContext { get; set; }
            public string? DestinationName { get; set; }
            public Int32? Duration { get; set; }
            public DateTimeOffset? EndDateTime { get; set; }
            public string? Id { get; set; }
            public string? InventoryType { get; set; }
            public string? LicenseCapability { get; set; }
            public string? Operator { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
            public string? TenantCountryCode { get; set; }
            public string? UsageCountryCode { get; set; }
            public string? UserDisplayName { get; set; }
            public string? UserId { get; set; }
            public string? UserPrincipalName { get; set; }
        }

        public CallrecordsPstncalllogrow[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-callrecord-getpstncalls?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsCallrecordGetpstncallsResponse> CallrecordsCallrecordGetpstncallsAsync()
        {
            var p = new CallrecordsCallrecordGetpstncallsParameter();
            return await this.SendAsync<CallrecordsCallrecordGetpstncallsParameter, CallrecordsCallrecordGetpstncallsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-callrecord-getpstncalls?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsCallrecordGetpstncallsResponse> CallrecordsCallrecordGetpstncallsAsync(CancellationToken cancellationToken)
        {
            var p = new CallrecordsCallrecordGetpstncallsParameter();
            return await this.SendAsync<CallrecordsCallrecordGetpstncallsParameter, CallrecordsCallrecordGetpstncallsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-callrecord-getpstncalls?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsCallrecordGetpstncallsResponse> CallrecordsCallrecordGetpstncallsAsync(CallrecordsCallrecordGetpstncallsParameter parameter)
        {
            return await this.SendAsync<CallrecordsCallrecordGetpstncallsParameter, CallrecordsCallrecordGetpstncallsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-callrecord-getpstncalls?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsCallrecordGetpstncallsResponse> CallrecordsCallrecordGetpstncallsAsync(CallrecordsCallrecordGetpstncallsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallrecordsCallrecordGetpstncallsParameter, CallrecordsCallrecordGetpstncallsResponse>(parameter, cancellationToken);
        }
    }
}
