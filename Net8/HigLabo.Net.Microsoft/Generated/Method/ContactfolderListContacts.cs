using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
/// </summary>
public partial class ContactFolderListContactsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Contacts: return $"/me/contacts";
                case ApiPath.Users_IdOrUserPrincipalName_Contacts: return $"/users/{IdOrUserPrincipalName}/contacts";
                case ApiPath.Me_ContactFolders_Id_Contacts: return $"/me/contactFolders/{Id}/contacts";
                case ApiPath.Users_IdOrUserPrincipalName_ContactFolders_Id_Contacts: return $"/users/{IdOrUserPrincipalName}/contactFolders/{Id}/contacts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Contacts,
        Users_IdOrUserPrincipalName_Contacts,
        Me_ContactFolders_Id_Contacts,
        Users_IdOrUserPrincipalName_ContactFolders_Id_Contacts,
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
public partial class ContactFolderListContactsResponse : RestApiResponse<Contact>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContactFolderListContactsResponse> ContactFolderListContactsAsync()
    {
        var p = new ContactFolderListContactsParameter();
        return await this.SendAsync<ContactFolderListContactsParameter, ContactFolderListContactsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContactFolderListContactsResponse> ContactFolderListContactsAsync(CancellationToken cancellationToken)
    {
        var p = new ContactFolderListContactsParameter();
        return await this.SendAsync<ContactFolderListContactsParameter, ContactFolderListContactsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContactFolderListContactsResponse> ContactFolderListContactsAsync(ContactFolderListContactsParameter parameter)
    {
        return await this.SendAsync<ContactFolderListContactsParameter, ContactFolderListContactsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContactFolderListContactsResponse> ContactFolderListContactsAsync(ContactFolderListContactsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ContactFolderListContactsParameter, ContactFolderListContactsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Contact> ContactFolderListContactsEnumerateAsync(ContactFolderListContactsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ContactFolderListContactsParameter, ContactFolderListContactsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Contact>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
