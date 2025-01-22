using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-unarchive?view=graph-rest-1.0
/// </summary>
public partial class ServiceupdatemessageUnArchiveParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Admin_ServiceAnnouncement_Messages_Unarchive: return $"/admin/serviceAnnouncement/messages/unarchive";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Admin_ServiceAnnouncement_Messages_Unarchive,
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
public partial class ServiceupdatemessageUnArchiveResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-unarchive?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-unarchive?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceupdatemessageUnArchiveResponse> ServiceupdatemessageUnArchiveAsync()
    {
        var p = new ServiceupdatemessageUnArchiveParameter();
        return await this.SendAsync<ServiceupdatemessageUnArchiveParameter, ServiceupdatemessageUnArchiveResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-unarchive?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceupdatemessageUnArchiveResponse> ServiceupdatemessageUnArchiveAsync(CancellationToken cancellationToken)
    {
        var p = new ServiceupdatemessageUnArchiveParameter();
        return await this.SendAsync<ServiceupdatemessageUnArchiveParameter, ServiceupdatemessageUnArchiveResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-unarchive?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceupdatemessageUnArchiveResponse> ServiceupdatemessageUnArchiveAsync(ServiceupdatemessageUnArchiveParameter parameter)
    {
        return await this.SendAsync<ServiceupdatemessageUnArchiveParameter, ServiceupdatemessageUnArchiveResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-unarchive?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceupdatemessageUnArchiveResponse> ServiceupdatemessageUnArchiveAsync(ServiceupdatemessageUnArchiveParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServiceupdatemessageUnArchiveParameter, ServiceupdatemessageUnArchiveResponse>(parameter, cancellationToken);
    }
}
