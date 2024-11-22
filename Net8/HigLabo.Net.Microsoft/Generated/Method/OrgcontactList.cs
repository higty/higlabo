using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
/// </summary>
public partial class OrgcontactListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Contacts: return $"/contacts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Contacts,
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
public partial class OrgcontactListResponse : RestApiResponse<OrgContact>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrgcontactListResponse> OrgcontactListAsync()
    {
        var p = new OrgcontactListParameter();
        return await this.SendAsync<OrgcontactListParameter, OrgcontactListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrgcontactListResponse> OrgcontactListAsync(CancellationToken cancellationToken)
    {
        var p = new OrgcontactListParameter();
        return await this.SendAsync<OrgcontactListParameter, OrgcontactListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrgcontactListResponse> OrgcontactListAsync(OrgcontactListParameter parameter)
    {
        return await this.SendAsync<OrgcontactListParameter, OrgcontactListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrgcontactListResponse> OrgcontactListAsync(OrgcontactListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OrgcontactListParameter, OrgcontactListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<OrgContact> OrgcontactListEnumerateAsync(OrgcontactListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<OrgcontactListParameter, OrgcontactListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<OrgContact>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
