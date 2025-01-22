using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/contact-delete?view=graph-rest-1.0
/// </summary>
public partial class ContactDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? ContactFoldersId { get; set; }
        public string? ContactsId { get; set; }
        public string? UsersIdOrUserPrincipalName { get; set; }
        public string? ChildFoldersId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Contacts_Id: return $"/me/contacts/{Id}";
                case ApiPath.Users_IdOrUserPrincipalName_Contacts_Id: return $"/users/{IdOrUserPrincipalName}/contacts/{Id}";
                case ApiPath.Me_ContactFolders_Id_Contacts_Id: return $"/me/contactFolders/{ContactFoldersId}/contacts/{ContactsId}";
                case ApiPath.Users_IdOrUserPrincipalName_ContactFolders_Id_Contacts_Id: return $"/users/{UsersIdOrUserPrincipalName}/contactFolders/{ContactFoldersId}/contacts/{ContactsId}";
                case ApiPath.Me_ContactFolders_Id_ChildFolders_Id__Contacts_Id: return $"/me/contactFolders/{ContactFoldersId}/childFolders/{ChildFoldersId}/.../contacts/{ContactsId}";
                case ApiPath.Users_IdOrUserPrincipalName_ContactFolders_Id_ChildFolders_Id_Contacts_Id: return $"/users/{UsersIdOrUserPrincipalName}/contactFolders/{ContactFoldersId}/childFolders/{ChildFoldersId}/contacts/{ContactsId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Contacts_Id,
        Users_IdOrUserPrincipalName_Contacts_Id,
        Me_ContactFolders_Id_Contacts_Id,
        Users_IdOrUserPrincipalName_ContactFolders_Id_Contacts_Id,
        Me_ContactFolders_Id_ChildFolders_Id__Contacts_Id,
        Users_IdOrUserPrincipalName_ContactFolders_Id_ChildFolders_Id_Contacts_Id,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class ContactDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/contact-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contact-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContactDeleteResponse> ContactDeleteAsync()
    {
        var p = new ContactDeleteParameter();
        return await this.SendAsync<ContactDeleteParameter, ContactDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contact-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContactDeleteResponse> ContactDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new ContactDeleteParameter();
        return await this.SendAsync<ContactDeleteParameter, ContactDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contact-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContactDeleteResponse> ContactDeleteAsync(ContactDeleteParameter parameter)
    {
        return await this.SendAsync<ContactDeleteParameter, ContactDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contact-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContactDeleteResponse> ContactDeleteAsync(ContactDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ContactDeleteParameter, ContactDeleteResponse>(parameter, cancellationToken);
    }
}
