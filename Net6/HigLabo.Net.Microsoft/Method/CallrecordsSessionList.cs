using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallrecordsSessionListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Communications_CallRecords_Id_Sessions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_CallRecords_Id_Sessions: return $"/communications/callRecords/{Id}/sessions";
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
        public string Id { get; set; }
    }
    public partial class CallrecordsSessionListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-session?view=graph-rest-1.0
        /// </summary>
        public partial class CallrecordsSession
        {
            public enum CallrecordsSessionCallRecordsModality
            {
                Unknown,
                Audio,
                Video,
                VideoBasedScreenSharing,
                Data,
                ScreenSharing,
                UnknownFutureValue,
            }

            public string? Id { get; set; }
            public CallRecordsEndpoint? Caller { get; set; }
            public CallRecordsEndpoint? Callee { get; set; }
            public CallRecordsFailureInfo? FailureInfo { get; set; }
            public CallrecordsSessionCallRecordsModality Modalities { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
            public DateTimeOffset? EndDateTime { get; set; }
        }

        public enum CallrecordsSessionCallRecordsModality
        {
            Unknown,
            Audio,
            Video,
            VideoBasedScreenSharing,
            Data,
            ScreenSharing,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public CallRecordsEndpoint? Caller { get; set; }
        public CallRecordsEndpoint? Callee { get; set; }
        public CallRecordsFailureInfo? FailureInfo { get; set; }
        public CallrecordsSessionCallRecordsModality Modalities { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public CallrecordsSession[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-session-list?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsSessionListResponse> CallrecordsSessionListAsync()
        {
            var p = new CallrecordsSessionListParameter();
            return await this.SendAsync<CallrecordsSessionListParameter, CallrecordsSessionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-session-list?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsSessionListResponse> CallrecordsSessionListAsync(CancellationToken cancellationToken)
        {
            var p = new CallrecordsSessionListParameter();
            return await this.SendAsync<CallrecordsSessionListParameter, CallrecordsSessionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-session-list?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsSessionListResponse> CallrecordsSessionListAsync(CallrecordsSessionListParameter parameter)
        {
            return await this.SendAsync<CallrecordsSessionListParameter, CallrecordsSessionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-session-list?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsSessionListResponse> CallrecordsSessionListAsync(CallrecordsSessionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallrecordsSessionListParameter, CallrecordsSessionListResponse>(parameter, cancellationToken);
        }
    }
}
