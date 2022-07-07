using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinessparticipantactivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessParticipantActivityCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessParticipantActivityCounts: return $"/reports/getSkypeForBusinessParticipantActivityCounts";
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
    public partial class ReportrootGetskypeforbusinessparticipantactivitycountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessparticipantactivitycountsResponse> ReportrootGetskypeforbusinessparticipantactivitycountsAsync()
        {
            var p = new ReportrootGetskypeforbusinessparticipantactivitycountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessparticipantactivitycountsParameter, ReportrootGetskypeforbusinessparticipantactivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessparticipantactivitycountsResponse> ReportrootGetskypeforbusinessparticipantactivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinessparticipantactivitycountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessparticipantactivitycountsParameter, ReportrootGetskypeforbusinessparticipantactivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessparticipantactivitycountsResponse> ReportrootGetskypeforbusinessparticipantactivitycountsAsync(ReportrootGetskypeforbusinessparticipantactivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessparticipantactivitycountsParameter, ReportrootGetskypeforbusinessparticipantactivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessparticipantactivitycountsResponse> ReportrootGetskypeforbusinessparticipantactivitycountsAsync(ReportrootGetskypeforbusinessparticipantactivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessparticipantactivitycountsParameter, ReportrootGetskypeforbusinessparticipantactivitycountsResponse>(parameter, cancellationToken);
        }
    }
}
