using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SwapshiftschangerequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_SwapShiftsChangeRequests: return $"/teams/{TeamId}/schedule/swapShiftsChangeRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_SwapShiftsChangeRequests,
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
