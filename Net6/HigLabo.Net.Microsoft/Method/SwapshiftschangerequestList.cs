using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SwapshiftschangerequestListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_SwapShiftsChangeRequests,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_SwapShiftsChangeRequests: return $"/teams/{TeamId}/schedule/swapShiftsChangeRequests";
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
        public string TeamId { get; set; }
    }
    public partial class SwapshiftschangerequestListResponse : RestApiResponse
    {
        public string? RecipientShiftId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestListResponse> SwapshiftschangerequestListAsync()
        {
            var p = new SwapshiftschangerequestListParameter();
            return await this.SendAsync<SwapshiftschangerequestListParameter, SwapshiftschangerequestListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestListResponse> SwapshiftschangerequestListAsync(CancellationToken cancellationToken)
        {
            var p = new SwapshiftschangerequestListParameter();
            return await this.SendAsync<SwapshiftschangerequestListParameter, SwapshiftschangerequestListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestListResponse> SwapshiftschangerequestListAsync(SwapshiftschangerequestListParameter parameter)
        {
            return await this.SendAsync<SwapshiftschangerequestListParameter, SwapshiftschangerequestListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestListResponse> SwapshiftschangerequestListAsync(SwapshiftschangerequestListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SwapshiftschangerequestListParameter, SwapshiftschangerequestListResponse>(parameter, cancellationToken);
        }
    }
}
