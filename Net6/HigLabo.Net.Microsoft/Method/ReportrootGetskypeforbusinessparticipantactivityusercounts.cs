using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinessparticipantactivityusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessParticipantActivityUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessParticipantActivityUserCounts: return $"/reports/getSkypeForBusinessParticipantActivityUserCounts";
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
    public partial class ReportrootGetskypeforbusinessparticipantactivityusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessparticipantactivityusercountsResponse> ReportrootGetskypeforbusinessparticipantactivityusercountsAsync()
        {
            var p = new ReportrootGetskypeforbusinessparticipantactivityusercountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessparticipantactivityusercountsParameter, ReportrootGetskypeforbusinessparticipantactivityusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessparticipantactivityusercountsResponse> ReportrootGetskypeforbusinessparticipantactivityusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinessparticipantactivityusercountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessparticipantactivityusercountsParameter, ReportrootGetskypeforbusinessparticipantactivityusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessparticipantactivityusercountsResponse> ReportrootGetskypeforbusinessparticipantactivityusercountsAsync(ReportrootGetskypeforbusinessparticipantactivityusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessparticipantactivityusercountsParameter, ReportrootGetskypeforbusinessparticipantactivityusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessparticipantactivityusercountsResponse> ReportrootGetskypeforbusinessparticipantactivityusercountsAsync(ReportrootGetskypeforbusinessparticipantactivityusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessparticipantactivityusercountsParameter, ReportrootGetskypeforbusinessparticipantactivityusercountsResponse>(parameter, cancellationToken);
        }
    }
}
