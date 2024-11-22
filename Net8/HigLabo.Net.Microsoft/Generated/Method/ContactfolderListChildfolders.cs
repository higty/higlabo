using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-childfolders?view=graph-rest-1.0
/// </summary>
public partial class ContactFolderListChildFoldersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_ContactFolders_Id_ChildFolders: return $"/me/contactFolders/{Id}/childFolders";
                case ApiPath.Users_IdOrUserPrincipalName_ContactFolders_Id_ChildFolders: return $"/users/{IdOrUserPrincipalName}/contactFolders/{Id}/childFolders";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_ContactFolders_Id_ChildFolders,
        Users_IdOrUserPrincipalName_ContactFolders_Id_ChildFolders,
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
public partial class ContactFolderListChildFoldersResponse : RestApiResponse<ContactFolder>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-childfolders?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-childfolders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContactFolderListChildFoldersResponse> ContactFolderListChildFoldersAsync()
    {
        var p = new ContactFolderListChildFoldersParameter();
        return await this.SendAsync<ContactFolderListChildFoldersParameter, ContactFolderListChildFoldersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-childfolders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContactFolderListChildFoldersResponse> ContactFolderListChildFoldersAsync(CancellationToken cancellationToken)
    {
        var p = new ContactFolderListChildFoldersParameter();
        return await this.SendAsync<ContactFolderListChildFoldersParameter, ContactFolderListChildFoldersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-childfolders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContactFolderListChildFoldersResponse> ContactFolderListChildFoldersAsync(ContactFolderListChildFoldersParameter parameter)
    {
        return await this.SendAsync<ContactFolderListChildFoldersParameter, ContactFolderListChildFoldersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-childfolders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContactFolderListChildFoldersResponse> ContactFolderListChildFoldersAsync(ContactFolderListChildFoldersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ContactFolderListChildFoldersParameter, ContactFolderListChildFoldersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-childfolders?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ContactFolder> ContactFolderListChildFoldersEnumerateAsync(ContactFolderListChildFoldersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ContactFolderListChildFoldersParameter, ContactFolderListChildFoldersResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ContactFolder>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
