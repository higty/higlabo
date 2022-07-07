using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContactDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_ContactFolders_Id_Contacts_Delta,
            Users_Id_ContactFolders_Id_Contacts_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_ContactFolders_Id_Contacts_Delta: return $"/me/contactFolders/{Id}/contacts/delta";
                    case ApiPath.Users_Id_ContactFolders_Id_Contacts_Delta: return $"/users/{UsersId}/contactFolders/{ContactFoldersId}/contacts/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
        public string UsersId { get; set; }
        public string ContactFoldersId { get; set; }
    }
    public partial class ContactDeltaResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/contact?view=graph-rest-1.0
        /// </summary>
        public partial class Contact
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

        public Contact[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contact-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactDeltaResponse> ContactDeltaAsync()
        {
            var p = new ContactDeltaParameter();
            return await this.SendAsync<ContactDeltaParameter, ContactDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contact-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactDeltaResponse> ContactDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new ContactDeltaParameter();
            return await this.SendAsync<ContactDeltaParameter, ContactDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contact-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactDeltaResponse> ContactDeltaAsync(ContactDeltaParameter parameter)
        {
            return await this.SendAsync<ContactDeltaParameter, ContactDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contact-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactDeltaResponse> ContactDeltaAsync(ContactDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContactDeltaParameter, ContactDeltaResponse>(parameter, cancellationToken);
        }
    }
}
