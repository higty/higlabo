using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getdirectroutingcalls?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsCallrecordGetdirectroutingcallsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_CallRecords_GetDirectRoutingCalls: return $"/communications/callRecords/getDirectRoutingCalls";
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
            CallEndSubReason,
            CallType,
            CalleeNumber,
            CallerNumber,
            CorrelationId,
            Duration,
            FailureDateTime,
            FinalSipCodePhrase,
            FinalSipCode,
            InviteDateTime,
            MediaBypassEnabled,
            MediaPathLocation,
            SignalingLocation,
            SuccessfulCall,
            TrunkFullyQualifiedDomainName,
            UserDisplayName,
            UserId,
            UserPrincipalName,
        }
        public enum ApiPath
        {
            Communications_CallRecords_GetDirectRoutingCalls,
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
    public partial class CallrecordsCallrecordGetdirectroutingcallsResponse : RestApiResponse
    {
        public CallrecordsDirectroutinglogrow[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getdirectroutingcalls?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getdirectroutingcalls?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallrecordsCallrecordGetdirectroutingcallsResponse> CallrecordsCallrecordGetdirectroutingcallsAsync()
        {
            var p = new CallrecordsCallrecordGetdirectroutingcallsParameter();
            return await this.SendAsync<CallrecordsCallrecordGetdirectroutingcallsParameter, CallrecordsCallrecordGetdirectroutingcallsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getdirectroutingcalls?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallrecordsCallrecordGetdirectroutingcallsResponse> CallrecordsCallrecordGetdirectroutingcallsAsync(CancellationToken cancellationToken)
        {
            var p = new CallrecordsCallrecordGetdirectroutingcallsParameter();
            return await this.SendAsync<CallrecordsCallrecordGetdirectroutingcallsParameter, CallrecordsCallrecordGetdirectroutingcallsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getdirectroutingcalls?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallrecordsCallrecordGetdirectroutingcallsResponse> CallrecordsCallrecordGetdirectroutingcallsAsync(CallrecordsCallrecordGetdirectroutingcallsParameter parameter)
        {
            return await this.SendAsync<CallrecordsCallrecordGetdirectroutingcallsParameter, CallrecordsCallrecordGetdirectroutingcallsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getdirectroutingcalls?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallrecordsCallrecordGetdirectroutingcallsResponse> CallrecordsCallrecordGetdirectroutingcallsAsync(CallrecordsCallrecordGetdirectroutingcallsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallrecordsCallrecordGetdirectroutingcallsParameter, CallrecordsCallrecordGetdirectroutingcallsResponse>(parameter, cancellationToken);
        }
    }
}
