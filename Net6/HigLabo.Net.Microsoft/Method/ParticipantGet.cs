using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ParticipantGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            Id,
            Info,
            IsInLobby,
            IsMuted,
            MediaStreams,
            Metadata,
            RecordingInfo,
        }
        public enum ApiPath
        {
            Communications_Calls_Id_Participants_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id_Participants_Id: return $"/communications/calls/{CallsId}/participants/{ParticipantsId}";
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
        public string CallsId { get; set; }
        public string ParticipantsId { get; set; }
    }
    public partial class ParticipantGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public ParticipantInfo? Info { get; set; }
        public bool? IsInLobby { get; set; }
        public bool? IsMuted { get; set; }
        public MediaStream[]? MediaStreams { get; set; }
        public string? Metadata { get; set; }
        public RecordingInfo? RecordingInfo { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantGetResponse> ParticipantGetAsync()
        {
            var p = new ParticipantGetParameter();
            return await this.SendAsync<ParticipantGetParameter, ParticipantGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantGetResponse> ParticipantGetAsync(CancellationToken cancellationToken)
        {
            var p = new ParticipantGetParameter();
            return await this.SendAsync<ParticipantGetParameter, ParticipantGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantGetResponse> ParticipantGetAsync(ParticipantGetParameter parameter)
        {
            return await this.SendAsync<ParticipantGetParameter, ParticipantGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantGetResponse> ParticipantGetAsync(ParticipantGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ParticipantGetParameter, ParticipantGetResponse>(parameter, cancellationToken);
        }
    }
}
