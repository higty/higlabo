using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class AppconsentRequestFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_AppConsent_AppConsentRequests_FilterByCurrentUser: return $"/identityGovernance/appConsent/appConsentRequests/filterByCurrentUser";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_AppConsent_AppConsentRequests_FilterByCurrentUser,
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
public partial class AppconsentRequestFilterbycurrentUserResponse : RestApiResponse<AppConsentRequest>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AppconsentRequestFilterbycurrentUserResponse> AppconsentRequestFilterbycurrentUserAsync()
    {
        var p = new AppconsentRequestFilterbycurrentUserParameter();
        return await this.SendAsync<AppconsentRequestFilterbycurrentUserParameter, AppconsentRequestFilterbycurrentUserResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AppconsentRequestFilterbycurrentUserResponse> AppconsentRequestFilterbycurrentUserAsync(CancellationToken cancellationToken)
    {
        var p = new AppconsentRequestFilterbycurrentUserParameter();
        return await this.SendAsync<AppconsentRequestFilterbycurrentUserParameter, AppconsentRequestFilterbycurrentUserResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AppconsentRequestFilterbycurrentUserResponse> AppconsentRequestFilterbycurrentUserAsync(AppconsentRequestFilterbycurrentUserParameter parameter)
    {
        return await this.SendAsync<AppconsentRequestFilterbycurrentUserParameter, AppconsentRequestFilterbycurrentUserResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AppconsentRequestFilterbycurrentUserResponse> AppconsentRequestFilterbycurrentUserAsync(AppconsentRequestFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AppconsentRequestFilterbycurrentUserParameter, AppconsentRequestFilterbycurrentUserResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AppConsentRequest> AppconsentRequestFilterbycurrentUserEnumerateAsync(AppconsentRequestFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AppconsentRequestFilterbycurrentUserParameter, AppconsentRequestFilterbycurrentUserResponse>(parameter, cancellationToken);
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
