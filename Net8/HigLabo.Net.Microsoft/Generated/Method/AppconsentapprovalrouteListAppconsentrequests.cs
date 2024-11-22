using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
/// </summary>
public partial class AppconsentapprovalrouteListAppconsentRequestsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_AppConsent_AppConsentRequests: return $"/identityGovernance/appConsent/appConsentRequests";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_AppConsent_AppConsentRequests,
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
public partial class AppconsentapprovalrouteListAppconsentRequestsResponse : RestApiResponse<AppConsentRequest>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AppconsentapprovalrouteListAppconsentRequestsResponse> AppconsentapprovalrouteListAppconsentRequestsAsync()
    {
        var p = new AppconsentapprovalrouteListAppconsentRequestsParameter();
        return await this.SendAsync<AppconsentapprovalrouteListAppconsentRequestsParameter, AppconsentapprovalrouteListAppconsentRequestsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AppconsentapprovalrouteListAppconsentRequestsResponse> AppconsentapprovalrouteListAppconsentRequestsAsync(CancellationToken cancellationToken)
    {
        var p = new AppconsentapprovalrouteListAppconsentRequestsParameter();
        return await this.SendAsync<AppconsentapprovalrouteListAppconsentRequestsParameter, AppconsentapprovalrouteListAppconsentRequestsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AppconsentapprovalrouteListAppconsentRequestsResponse> AppconsentapprovalrouteListAppconsentRequestsAsync(AppconsentapprovalrouteListAppconsentRequestsParameter parameter)
    {
        return await this.SendAsync<AppconsentapprovalrouteListAppconsentRequestsParameter, AppconsentapprovalrouteListAppconsentRequestsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AppconsentapprovalrouteListAppconsentRequestsResponse> AppconsentapprovalrouteListAppconsentRequestsAsync(AppconsentapprovalrouteListAppconsentRequestsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AppconsentapprovalrouteListAppconsentRequestsParameter, AppconsentapprovalrouteListAppconsentRequestsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AppConsentRequest> AppconsentapprovalrouteListAppconsentRequestsEnumerateAsync(AppconsentapprovalrouteListAppconsentRequestsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AppconsentapprovalrouteListAppconsentRequestsParameter, AppconsentapprovalrouteListAppconsentRequestsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AppConsentRequest>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
