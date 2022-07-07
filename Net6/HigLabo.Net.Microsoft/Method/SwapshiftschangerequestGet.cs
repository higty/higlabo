using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SwapshiftschangerequestGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class SwapshiftschangerequestGetResponse : RestApiResponse
    {
        public string? RecipientShiftId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestGetResponse> SwapshiftschangerequestGetAsync()
        {
            var p = new SwapshiftschangerequestGetParameter();
            return await this.SendAsync<SwapshiftschangerequestGetParameter, SwapshiftschangerequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestGetResponse> SwapshiftschangerequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new SwapshiftschangerequestGetParameter();
            return await this.SendAsync<SwapshiftschangerequestGetParameter, SwapshiftschangerequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestGetResponse> SwapshiftschangerequestGetAsync(SwapshiftschangerequestGetParameter parameter)
        {
            return await this.SendAsync<SwapshiftschangerequestGetParameter, SwapshiftschangerequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestGetResponse> SwapshiftschangerequestGetAsync(SwapshiftschangerequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SwapshiftschangerequestGetParameter, SwapshiftschangerequestGetResponse>(parameter, cancellationToken);
        }
    }
}
