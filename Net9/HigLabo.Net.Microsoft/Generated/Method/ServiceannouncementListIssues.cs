using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-issues?view=graph-rest-1.0
/// </summary>
public partial class ServiceannouncementListIssuesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Admin_ServiceAnnouncement_Issues: return $"/admin/serviceAnnouncement/issues";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Admin_ServiceAnnouncement_Issues,
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
public partial class ServiceannouncementListIssuesResponse : RestApiResponse<ServiceHealthIssue>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-issues?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-issues?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceannouncementListIssuesResponse> ServiceannouncementListIssuesAsync()
    {
        var p = new ServiceannouncementListIssuesParameter();
        return await this.SendAsync<ServiceannouncementListIssuesParameter, ServiceannouncementListIssuesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-issues?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceannouncementListIssuesResponse> ServiceannouncementListIssuesAsync(CancellationToken cancellationToken)
    {
        var p = new ServiceannouncementListIssuesParameter();
        return await this.SendAsync<ServiceannouncementListIssuesParameter, ServiceannouncementListIssuesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-issues?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceannouncementListIssuesResponse> ServiceannouncementListIssuesAsync(ServiceannouncementListIssuesParameter parameter)
    {
        return await this.SendAsync<ServiceannouncementListIssuesParameter, ServiceannouncementListIssuesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-issues?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceannouncementListIssuesResponse> ServiceannouncementListIssuesAsync(ServiceannouncementListIssuesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServiceannouncementListIssuesParameter, ServiceannouncementListIssuesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-issues?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ServiceHealthIssue> ServiceannouncementListIssuesEnumerateAsync(ServiceannouncementListIssuesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ServiceannouncementListIssuesParameter, ServiceannouncementListIssuesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ServiceHealthIssue>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
