using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class SwapShiftsChangeRequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

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
    public partial class SwapShiftsChangeRequestGetResponse : RestApiResponse
    {
        public string? RecipientShiftId { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SwapShiftsChangeRequestGetResponse> SwapShiftsChangeRequestGetAsync()
        {
            var p = new SwapShiftsChangeRequestGetParameter();
            return await this.SendAsync<SwapShiftsChangeRequestGetParameter, SwapShiftsChangeRequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SwapShiftsChangeRequestGetResponse> SwapShiftsChangeRequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new SwapShiftsChangeRequestGetParameter();
            return await this.SendAsync<SwapShiftsChangeRequestGetParameter, SwapShiftsChangeRequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SwapShiftsChangeRequestGetResponse> SwapShiftsChangeRequestGetAsync(SwapShiftsChangeRequestGetParameter parameter)
        {
            return await this.SendAsync<SwapShiftsChangeRequestGetParameter, SwapShiftsChangeRequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SwapShiftsChangeRequestGetResponse> SwapShiftsChangeRequestGetAsync(SwapShiftsChangeRequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SwapShiftsChangeRequestGetParameter, SwapShiftsChangeRequestGetResponse>(parameter, cancellationToken);
        }
    }
}
