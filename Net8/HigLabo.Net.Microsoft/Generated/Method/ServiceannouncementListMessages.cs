using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-messages?view=graph-rest-1.0
/// </summary>
public partial class ServiceannouncementListMessagesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Admin_ServiceAnnouncement_Messages: return $"/admin/serviceAnnouncement/messages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Admin_ServiceAnnouncement_Messages,
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
public partial class ServiceannouncementListMessagesResponse : RestApiResponse<ServiceUpdateMessage>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-messages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceannouncementListMessagesResponse> ServiceannouncementListMessagesAsync()
    {
        var p = new ServiceannouncementListMessagesParameter();
        return await this.SendAsync<ServiceannouncementListMessagesParameter, ServiceannouncementListMessagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceannouncementListMessagesResponse> ServiceannouncementListMessagesAsync(CancellationToken cancellationToken)
    {
        var p = new ServiceannouncementListMessagesParameter();
        return await this.SendAsync<ServiceannouncementListMessagesParameter, ServiceannouncementListMessagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceannouncementListMessagesResponse> ServiceannouncementListMessagesAsync(ServiceannouncementListMessagesParameter parameter)
    {
        return await this.SendAsync<ServiceannouncementListMessagesParameter, ServiceannouncementListMessagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-messages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceannouncementListMessagesResponse> ServiceannouncementListMessagesAsync(ServiceannouncementListMessagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServiceannouncementListMessagesParameter, ServiceannouncementListMessagesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-messages?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ServiceUpdateMessage> ServiceannouncementListMessagesEnumerateAsync(ServiceannouncementListMessagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ServiceannouncementListMessagesParameter, ServiceannouncementListMessagesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ServiceUpdateMessage>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
