using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinessparticipantactivityminutecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessParticipantActivityMinuteCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessParticipantActivityMinuteCounts: return $"/reports/getSkypeForBusinessParticipantActivityMinuteCounts";
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
    public partial class ReportrootGetskypeforbusinessparticipantactivityminutecountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessparticipantactivityminutecountsResponse> ReportrootGetskypeforbusinessparticipantactivityminutecountsAsync()
        {
            var p = new ReportrootGetskypeforbusinessparticipantactivityminutecountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessparticipantactivityminutecountsParameter, ReportrootGetskypeforbusinessparticipantactivityminutecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessparticipantactivityminutecountsResponse> ReportrootGetskypeforbusinessparticipantactivityminutecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinessparticipantactivityminutecountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessparticipantactivityminutecountsParameter, ReportrootGetskypeforbusinessparticipantactivityminutecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessparticipantactivityminutecountsResponse> ReportrootGetskypeforbusinessparticipantactivityminutecountsAsync(ReportrootGetskypeforbusinessparticipantactivityminutecountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessparticipantactivityminutecountsParameter, ReportrootGetskypeforbusinessparticipantactivityminutecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessparticipantactivityminutecountsResponse> ReportrootGetskypeforbusinessparticipantactivityminutecountsAsync(ReportrootGetskypeforbusinessparticipantactivityminutecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessparticipantactivityminutecountsParameter, ReportrootGetskypeforbusinessparticipantactivityminutecountsResponse>(parameter, cancellationToken);
        }
    }
}
