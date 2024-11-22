using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
/// </summary>
public partial class ServiceannouncementListHealthoverviewsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Admin_ServiceAnnouncement_HealthOverviews: return $"/admin/serviceAnnouncement/healthOverviews";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Admin_ServiceAnnouncement_HealthOverviews,
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
public partial class ServiceannouncementListHealthoverviewsResponse : RestApiResponse<ServiceHealth>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceannouncementListHealthoverviewsResponse> ServiceannouncementListHealthoverviewsAsync()
    {
        var p = new ServiceannouncementListHealthoverviewsParameter();
        return await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceannouncementListHealthoverviewsResponse> ServiceannouncementListHealthoverviewsAsync(CancellationToken cancellationToken)
    {
        var p = new ServiceannouncementListHealthoverviewsParameter();
        return await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceannouncementListHealthoverviewsResponse> ServiceannouncementListHealthoverviewsAsync(ServiceannouncementListHealthoverviewsParameter parameter)
    {
        return await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServiceannouncementListHealthoverviewsResponse> ServiceannouncementListHealthoverviewsAsync(ServiceannouncementListHealthoverviewsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ServiceHealth> ServiceannouncementListHealthoverviewsEnumerateAsync(ServiceannouncementListHealthoverviewsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ServiceHealth>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
