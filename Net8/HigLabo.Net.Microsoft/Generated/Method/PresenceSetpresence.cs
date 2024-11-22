using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/presence-setpresence?view=graph-rest-1.0
/// </summary>
public partial class PresenceSetpresenceParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? UserId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Users_UserId_Presence_SetPresence: return $"/users/{UserId}/presence/setPresence";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Users_UserId_Presence_SetPresence,
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
    public string? SessionId { get; set; }
    public string? Availability { get; set; }
    public string? Activity { get; set; }
    public string? ExpirationDuration { get; set; }
}
public partial class PresenceSetpresenceResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/presence-setpresence?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/presence-setpresence?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PresenceSetpresenceResponse> PresenceSetpresenceAsync()
    {
        var p = new PresenceSetpresenceParameter();
        return await this.SendAsync<PresenceSetpresenceParameter, PresenceSetpresenceResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/presence-setpresence?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PresenceSetpresenceResponse> PresenceSetpresenceAsync(CancellationToken cancellationToken)
    {
        var p = new PresenceSetpresenceParameter();
        return await this.SendAsync<PresenceSetpresenceParameter, PresenceSetpresenceResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/presence-setpresence?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PresenceSetpresenceResponse> PresenceSetpresenceAsync(PresenceSetpresenceParameter parameter)
    {
        return await this.SendAsync<PresenceSetpresenceParameter, PresenceSetpresenceResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/presence-setpresence?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PresenceSetpresenceResponse> PresenceSetpresenceAsync(PresenceSetpresenceParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PresenceSetpresenceParameter, PresenceSetpresenceResponse>(parameter, cancellationToken);
    }
}
