using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-list?view=graph-rest-1.0
/// </summary>
public partial class SwapShiftsChangeRequestListParameter : IRestApiParameter, IQueryParameterProperty
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
public partial class SwapShiftsChangeRequestListResponse : RestApiResponse
{
    public string? RecipientShiftId { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SwapShiftsChangeRequestListResponse> SwapShiftsChangeRequestListAsync()
    {
        var p = new SwapShiftsChangeRequestListParameter();
        return await this.SendAsync<SwapShiftsChangeRequestListParameter, SwapShiftsChangeRequestListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SwapShiftsChangeRequestListResponse> SwapShiftsChangeRequestListAsync(CancellationToken cancellationToken)
    {
        var p = new SwapShiftsChangeRequestListParameter();
        return await this.SendAsync<SwapShiftsChangeRequestListParameter, SwapShiftsChangeRequestListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SwapShiftsChangeRequestListResponse> SwapShiftsChangeRequestListAsync(SwapShiftsChangeRequestListParameter parameter)
    {
        return await this.SendAsync<SwapShiftsChangeRequestListParameter, SwapShiftsChangeRequestListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SwapShiftsChangeRequestListResponse> SwapShiftsChangeRequestListAsync(SwapShiftsChangeRequestListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SwapShiftsChangeRequestListParameter, SwapShiftsChangeRequestListResponse>(parameter, cancellationToken);
    }
}
