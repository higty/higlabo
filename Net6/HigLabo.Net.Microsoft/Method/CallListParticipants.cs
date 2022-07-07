using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallListParticipantsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Communications_Calls_Id_Participants,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id_Participants: return $"/communications/calls/{Id}/participants";
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
    public partial class CallListParticipantsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/participant?view=graph-rest-1.0
        /// </summary>
        public partial class Participant
        {
            public string? Id { get; set; }
            public ParticipantInfo? Info { get; set; }
            public bool? IsInLobby { get; set; }
            public bool? IsMuted { get; set; }
            public MediaStream[]? MediaStreams { get; set; }
            public string? Metadata { get; set; }
            public RecordingInfo? RecordingInfo { get; set; }
        }

        public Participant[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-list-participants?view=graph-rest-1.0
        /// </summary>
        public async Task<CallListParticipantsResponse> CallListParticipantsAsync()
        {
            var p = new CallListParticipantsParameter();
            return await this.SendAsync<CallListParticipantsParameter, CallListParticipantsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-list-participants?view=graph-rest-1.0
        /// </summary>
        public async Task<CallListParticipantsResponse> CallListParticipantsAsync(CancellationToken cancellationToken)
        {
            var p = new CallListParticipantsParameter();
            return await this.SendAsync<CallListParticipantsParameter, CallListParticipantsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-list-participants?view=graph-rest-1.0
        /// </summary>
        public async Task<CallListParticipantsResponse> CallListParticipantsAsync(CallListParticipantsParameter parameter)
        {
            return await this.SendAsync<CallListParticipantsParameter, CallListParticipantsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-list-participants?view=graph-rest-1.0
        /// </summary>
        public async Task<CallListParticipantsResponse> CallListParticipantsAsync(CallListParticipantsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallListParticipantsParameter, CallListParticipantsResponse>(parameter, cancellationToken);
        }
    }
}
