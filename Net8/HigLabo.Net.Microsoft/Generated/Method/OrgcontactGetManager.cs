using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/orgcontact-get-manager?view=graph-rest-1.0
/// </summary>
public partial class OrgcontactGetManagerParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Contacts_Id_Manager: return $"/contacts/{Id}/manager";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Contacts_Id_Manager,
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
public partial class OrgcontactGetManagerResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/orgcontact-get-manager?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-get-manager?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrgcontactGetManagerResponse> OrgcontactGetManagerAsync()
    {
        var p = new OrgcontactGetManagerParameter();
        return await this.SendAsync<OrgcontactGetManagerParameter, OrgcontactGetManagerResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-get-manager?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrgcontactGetManagerResponse> OrgcontactGetManagerAsync(CancellationToken cancellationToken)
    {
        var p = new OrgcontactGetManagerParameter();
        return await this.SendAsync<OrgcontactGetManagerParameter, OrgcontactGetManagerResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-get-manager?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrgcontactGetManagerResponse> OrgcontactGetManagerAsync(OrgcontactGetManagerParameter parameter)
    {
        return await this.SendAsync<OrgcontactGetManagerParameter, OrgcontactGetManagerResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-get-manager?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OrgcontactGetManagerResponse> OrgcontactGetManagerAsync(OrgcontactGetManagerParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OrgcontactGetManagerParameter, OrgcontactGetManagerResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-get-manager?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> OrgcontactGetManagerEnumerateAsync(OrgcontactGetManagerParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<OrgcontactGetManagerParameter, OrgcontactGetManagerResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
