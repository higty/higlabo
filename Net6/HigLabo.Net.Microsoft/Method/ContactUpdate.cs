using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContactUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrUserPrincipalName { get; set; }
            public string ContactFoldersId { get; set; }
            public string ContactsId { get; set; }
            public string UsersIdOrUserPrincipalName { get; set; }
            public string ChildFoldersId { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? AssistantName { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public PhysicalAddress? BusinessAddress { get; set; }
        public string? BusinessHomePage { get; set; }
        public string? BusinessPhones { get; set; }
        public string? Categories { get; set; }
        public string? Children { get; set; }
        public string? CompanyName { get; set; }
        public string? Department { get; set; }
        public string? DisplayName { get; set; }
        public EmailAddress[]? EmailAddresses { get; set; }
        public string? FileAs { get; set; }
        public string? Generation { get; set; }
        public string? GivenName { get; set; }
        public PhysicalAddress? HomeAddress { get; set; }
        public String[]? HomePhones { get; set; }
        public string? ImAddresses { get; set; }
        public string? Initials { get; set; }
        public string? JobTitle { get; set; }
        public string? Manager { get; set; }
        public string? MiddleName { get; set; }
        public string? MobilePhone { get; set; }
        public string? NickName { get; set; }
        public string? OfficeLocation { get; set; }
        public PhysicalAddress? OtherAddress { get; set; }
        public string? ParentFolderId { get; set; }
        public string? PersonalNotes { get; set; }
        public string? Profession { get; set; }
        public string? SpouseName { get; set; }
        public string? Surname { get; set; }
        public string? Title { get; set; }
        public string? YomiCompanyName { get; set; }
        public string? YomiGivenName { get; set; }
        public string? YomiSurname { get; set; }
    }
    public partial class ContactUpdateResponse : RestApiResponse
    {
        public string? AssistantName { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public PhysicalAddress? BusinessAddress { get; set; }
        public string? BusinessHomePage { get; set; }
        public String[]? BusinessPhones { get; set; }
        public String[]? Categories { get; set; }
        public string? ChangeKey { get; set; }
        public String[]? Children { get; set; }
        public string? CompanyName { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Department { get; set; }
        public string? DisplayName { get; set; }
        public EmailAddress[]? EmailAddresses { get; set; }
        public string? FileAs { get; set; }
        public string? Generation { get; set; }
        public string? GivenName { get; set; }
        public PhysicalAddress? HomeAddress { get; set; }
        public String[]? HomePhones { get; set; }
        public string? Id { get; set; }
        public String[]? ImAddresses { get; set; }
        public string? Initials { get; set; }
        public string? JobTitle { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Manager { get; set; }
        public string? MiddleName { get; set; }
        public string? MobilePhone { get; set; }
        public string? NickName { get; set; }
        public string? OfficeLocation { get; set; }
        public PhysicalAddress? OtherAddress { get; set; }
        public string? ParentFolderId { get; set; }
        public string? PersonalNotes { get; set; }
        public string? Profession { get; set; }
        public string? SpouseName { get; set; }
        public string? Surname { get; set; }
        public string? Title { get; set; }
        public string? YomiCompanyName { get; set; }
        public string? YomiGivenName { get; set; }
        public string? YomiSurname { get; set; }
        public Extension[]? Extensions { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public ProfilePhoto? Photo { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contact-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactUpdateResponse> ContactUpdateAsync()
        {
            var p = new ContactUpdateParameter();
            return await this.SendAsync<ContactUpdateParameter, ContactUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contact-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactUpdateResponse> ContactUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ContactUpdateParameter();
            return await this.SendAsync<ContactUpdateParameter, ContactUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contact-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactUpdateResponse> ContactUpdateAsync(ContactUpdateParameter parameter)
        {
            return await this.SendAsync<ContactUpdateParameter, ContactUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contact-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactUpdateResponse> ContactUpdateAsync(ContactUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContactUpdateParameter, ContactUpdateResponse>(parameter, cancellationToken);
        }
    }
}
