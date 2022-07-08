using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallrecordsCallrecordGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_CallRecords_Id: return $"/communications/callRecords/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

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
            Sessions,
        }
        public enum ApiPath
        {
            Communications_CallRecords_Id,
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
    public partial class CallrecordsCallrecordGetResponse : RestApiResponse
    {
        public enum CallrecordsCallrecordModality
        {
            Unknown,
            Audio,
            Video,
            VideoBasedScreenSharing,
            Data,
            ScreenSharing,
            UnknownFutureValue,
        }
        public enum CallrecordsCallrecordCallType
        {
            Unknown,
            GroupCall,
            PeerToPeer,
            UnknownFutureValue,
        }

        public DateTimeOffset? EndDateTime { get; set; }
        public string? Id { get; set; }
        public string? JoinWebUrl { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public CallrecordsCallrecordModality Modalities { get; set; }
        public IdentitySet? Organizer { get; set; }
        public IdentitySet[]? Participants { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public CallrecordsCallrecordCallType Type { get; set; }
        public Int64? Version { get; set; }
        public CallrecordsSession[]? Sessions { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-callrecord-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsCallrecordGetResponse> CallrecordsCallrecordGetAsync()
        {
            var p = new CallrecordsCallrecordGetParameter();
            return await this.SendAsync<CallrecordsCallrecordGetParameter, CallrecordsCallrecordGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-callrecord-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsCallrecordGetResponse> CallrecordsCallrecordGetAsync(CancellationToken cancellationToken)
        {
            var p = new CallrecordsCallrecordGetParameter();
            return await this.SendAsync<CallrecordsCallrecordGetParameter, CallrecordsCallrecordGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-callrecord-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsCallrecordGetResponse> CallrecordsCallrecordGetAsync(CallrecordsCallrecordGetParameter parameter)
        {
            return await this.SendAsync<CallrecordsCallrecordGetParameter, CallrecordsCallrecordGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/callrecords-callrecord-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CallrecordsCallrecordGetResponse> CallrecordsCallrecordGetAsync(CallrecordsCallrecordGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallrecordsCallrecordGetParameter, CallrecordsCallrecordGetResponse>(parameter, cancellationToken);
        }
    }
}
