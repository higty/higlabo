using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallrecordsCallrecordGetpstncallsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_CallRecords_GetPstnCalls: return $"/communications/callRecords/getPstnCalls";
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
            CallDurationSource,
            CalleeNumber,
            CallerNumber,
            CallId,
            CallType,
            Charge,
            ConferenceId,
            ConnectionCharge,
            Currency,
            DestinationContext,
            DestinationName,
            Duration,
            InventoryType,
            LicenseCapability,
            Operator,
            TenantCountryCode,
            UsageCountryCode,
            UserDisplayName,
            UserId,
            UserPrincipalName,
        }
        public enum ApiPath
        {
            Communications_CallRecords_GetPstnCalls,
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
    public partial class CallrecordsCallrecordGetpstncallsResponse : RestApiResponse
    {
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
