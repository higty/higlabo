using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContactfolderPostContactsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Contacts,
            Users_IdOrUserPrincipalName_Contacts,
            Me_ContactFolders_Id_Contacts,
            Users_IdOrUserPrincipalName_ContactFolders_Id_Contacts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Contacts: return $"/me/contacts";
                    case ApiPath.Users_IdOrUserPrincipalName_Contacts: return $"/users/{IdOrUserPrincipalName}/contacts";
                    case ApiPath.Me_ContactFolders_Id_Contacts: return $"/me/contactFolders/{Id}/contacts";
                    case ApiPath.Users_IdOrUserPrincipalName_ContactFolders_Id_Contacts: return $"/users/{IdOrUserPrincipalName}/contactFolders/{Id}/contacts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string IdOrUserPrincipalName { get; set; }
        public string Id { get; set; }
    }
    public partial class ContactfolderPostContactsResponse : RestApiResponse
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
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-post-contacts?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderPostContactsResponse> ContactfolderPostContactsAsync()
        {
            var p = new ContactfolderPostContactsParameter();
            return await this.SendAsync<ContactfolderPostContactsParameter, ContactfolderPostContactsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-post-contacts?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderPostContactsResponse> ContactfolderPostContactsAsync(CancellationToken cancellationToken)
        {
            var p = new ContactfolderPostContactsParameter();
            return await this.SendAsync<ContactfolderPostContactsParameter, ContactfolderPostContactsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-post-contacts?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderPostContactsResponse> ContactfolderPostContactsAsync(ContactfolderPostContactsParameter parameter)
        {
            return await this.SendAsync<ContactfolderPostContactsParameter, ContactfolderPostContactsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-post-contacts?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderPostContactsResponse> ContactfolderPostContactsAsync(ContactfolderPostContactsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContactfolderPostContactsParameter, ContactfolderPostContactsResponse>(parameter, cancellationToken);
        }
    }
}
