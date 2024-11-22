using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
/// </summary>
public partial class SwapShiftsChangeRequestPostParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? RecipientShiftId { get; set; }
}
public partial class SwapShiftsChangeRequestPostResponse : RestApiResponse
{
    public string? RecipientShiftId { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SwapShiftsChangeRequestPostResponse> SwapShiftsChangeRequestPostAsync()
    {
        var p = new SwapShiftsChangeRequestPostParameter();
        return await this.SendAsync<SwapShiftsChangeRequestPostParameter, SwapShiftsChangeRequestPostResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SwapShiftsChangeRequestPostResponse> SwapShiftsChangeRequestPostAsync(CancellationToken cancellationToken)
    {
        var p = new SwapShiftsChangeRequestPostParameter();
        return await this.SendAsync<SwapShiftsChangeRequestPostParameter, SwapShiftsChangeRequestPostResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SwapShiftsChangeRequestPostResponse> SwapShiftsChangeRequestPostAsync(SwapShiftsChangeRequestPostParameter parameter)
    {
        return await this.SendAsync<SwapShiftsChangeRequestPostParameter, SwapShiftsChangeRequestPostResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SwapShiftsChangeRequestPostResponse> SwapShiftsChangeRequestPostAsync(SwapShiftsChangeRequestPostParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SwapShiftsChangeRequestPostParameter, SwapShiftsChangeRequestPostResponse>(parameter, cancellationToken);
    }
}
