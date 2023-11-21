using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
    /// </summary>
    public partial class ContactfolderListContactsParameter : IRestApiParameter, IQueryParameterProperty
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
            AssistantName,
            Birthday,
            BusinessAddress,
            BusinessHomePage,
            BusinessPhones,
            Categories,
            ChangeKey,
            Children,
            CompanyName,
            CreatedDateTime,
            Department,
            DisplayName,
            EmailAddresses,
            FileAs,
            Generation,
            GivenName,
            HomeAddress,
            HomePhones,
            Id,
            ImAddresses,
            Initials,
            JobTitle,
            LastModifiedDateTime,
            Manager,
            MiddleName,
            MobilePhone,
            NickName,
            OfficeLocation,
            OtherAddress,
            ParentFolderId,
            PersonalNotes,
            Profession,
            SpouseName,
            Surname,
            Title,
            YomiCompanyName,
            YomiGivenName,
            YomiSurname,
            Extensions,
            MultiValueExtendedProperties,
            Photo,
            SingleValueExtendedProperties,
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
    public partial class ContactfolderListContactsResponse : RestApiResponse
    {
        public Contact[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContactfolderListContactsResponse> ContactfolderListContactsAsync()
        {
            var p = new ContactfolderListContactsParameter();
            return await this.SendAsync<ContactfolderListContactsParameter, ContactfolderListContactsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContactfolderListContactsResponse> ContactfolderListContactsAsync(CancellationToken cancellationToken)
        {
            var p = new ContactfolderListContactsParameter();
            return await this.SendAsync<ContactfolderListContactsParameter, ContactfolderListContactsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContactfolderListContactsResponse> ContactfolderListContactsAsync(ContactfolderListContactsParameter parameter)
        {
            return await this.SendAsync<ContactfolderListContactsParameter, ContactfolderListContactsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contactfolder-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContactfolderListContactsResponse> ContactfolderListContactsAsync(ContactfolderListContactsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContactfolderListContactsParameter, ContactfolderListContactsResponse>(parameter, cancellationToken);
        }
    }
}
