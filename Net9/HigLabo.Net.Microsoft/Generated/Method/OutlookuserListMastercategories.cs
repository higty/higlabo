using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
/// </summary>
public partial class OutlookUserListMasterCategoriesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Outlook_MasterCategories: return $"/me/outlook/masterCategories";
                case ApiPath.Users_IdOruserPrincipalName_Outlook_MasterCategories: return $"/users/{IdOrUserPrincipalName}/outlook/masterCategories";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Outlook_MasterCategories,
        Users_IdOruserPrincipalName_Outlook_MasterCategories,
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
public partial class OutlookUserListMasterCategoriesResponse : RestApiResponse<OutlookCategory>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OutlookUserListMasterCategoriesResponse> OutlookUserListMasterCategoriesAsync()
    {
        var p = new OutlookUserListMasterCategoriesParameter();
        return await this.SendAsync<OutlookUserListMasterCategoriesParameter, OutlookUserListMasterCategoriesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OutlookUserListMasterCategoriesResponse> OutlookUserListMasterCategoriesAsync(CancellationToken cancellationToken)
    {
        var p = new OutlookUserListMasterCategoriesParameter();
        return await this.SendAsync<OutlookUserListMasterCategoriesParameter, OutlookUserListMasterCategoriesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OutlookUserListMasterCategoriesResponse> OutlookUserListMasterCategoriesAsync(OutlookUserListMasterCategoriesParameter parameter)
    {
        return await this.SendAsync<OutlookUserListMasterCategoriesParameter, OutlookUserListMasterCategoriesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OutlookUserListMasterCategoriesResponse> OutlookUserListMasterCategoriesAsync(OutlookUserListMasterCategoriesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OutlookUserListMasterCategoriesParameter, OutlookUserListMasterCategoriesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<OutlookCategory> OutlookUserListMasterCategoriesEnumerateAsync(OutlookUserListMasterCategoriesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<OutlookUserListMasterCategoriesParameter, OutlookUserListMasterCategoriesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<OutlookCategory>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
