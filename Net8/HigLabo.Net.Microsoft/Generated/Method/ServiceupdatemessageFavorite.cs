using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-favorite?view=graph-rest-1.0
/// </summary>
public partial class ServiceupdatemessageFavoriteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Admin_ServiceAnnouncement_Messages_Favorite: return $"/admin/serviceAnnouncement/messages/favorite";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Admin_ServiceAnnouncement_Messages_Favorite,
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
    public String[]? MessageIds { get; set; }
}
public partial class ServiceupdatemessageFavoriteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-favorite?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-favorite?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceupdatemessageFavoriteResponse> ServiceupdatemessageFavoriteAsync()
    {
        var p = new ServiceupdatemessageFavoriteParameter();
        return await this.SendAsync<ServiceupdatemessageFavoriteParameter, ServiceupdatemessageFavoriteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-favorite?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceupdatemessageFavoriteResponse> ServiceupdatemessageFavoriteAsync(CancellationToken cancellationToken)
    {
        var p = new ServiceupdatemessageFavoriteParameter();
        return await this.SendAsync<ServiceupdatemessageFavoriteParameter, ServiceupdatemessageFavoriteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-favorite?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceupdatemessageFavoriteResponse> ServiceupdatemessageFavoriteAsync(ServiceupdatemessageFavoriteParameter parameter)
    {
        return await this.SendAsync<ServiceupdatemessageFavoriteParameter, ServiceupdatemessageFavoriteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-favorite?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceupdatemessageFavoriteResponse> ServiceupdatemessageFavoriteAsync(ServiceupdatemessageFavoriteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServiceupdatemessageFavoriteParameter, ServiceupdatemessageFavoriteResponse>(parameter, cancellationToken);
    }
}
