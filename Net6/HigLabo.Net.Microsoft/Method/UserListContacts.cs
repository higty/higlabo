using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListContactsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string IdOrUserPrincipalName { get; set; }
            public string Id { get; set; }
            public string ContactFoldersId { get; set; }
            public string ChildFoldersId { get; set; }
            public string UsersIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Contacts: return $"/me/contacts";
                    case ApiPath.Users_IdOrUserPrincipalName_Contacts: return $"/users/{IdOrUserPrincipalName}/contacts";
                    case ApiPath.Me_Contactfolders_Id_Contacts: return $"/me/contactfolders/{Id}/contacts";
                    case ApiPath.Users_IdOrUserPrincipalName_Contactfolders_Id_Contacts: return $"/users/{IdOrUserPrincipalName}/contactfolders/{Id}/contacts";
                    case ApiPath.Me_ContactFolders_Id_ChildFolders_Id__Contacts: return $"/me/contactFolders/{ContactFoldersId}/childFolders/{ChildFoldersId}/.../contacts";
                    case ApiPath.Users_IdOrUserPrincipalName_ContactFolders_Id_ChildFolders_Id_Contacts: return $"/users/{UsersIdOrUserPrincipalName}/contactFolders/{ContactFoldersId}/childFolders/{ChildFoldersId}/contacts";
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Me_Contacts: return $"/ttps://graph.microsoft.com/v1.0/me/contacts";
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
            Me_Contactfolders_Id_Contacts,
            Users_IdOrUserPrincipalName_Contactfolders_Id_Contacts,
            Me_ContactFolders_Id_ChildFolders_Id__Contacts,
            Users_IdOrUserPrincipalName_ContactFolders_Id_ChildFolders_Id_Contacts,
            Ttps__Graphmicrosoftcom_V10_Me_Contacts,
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
    public partial class UserListContactsResponse : RestApiResponse
    {
        public Contact[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListContactsResponse> UserListContactsAsync()
        {
            var p = new UserListContactsParameter();
            return await this.SendAsync<UserListContactsParameter, UserListContactsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListContactsResponse> UserListContactsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListContactsParameter();
            return await this.SendAsync<UserListContactsParameter, UserListContactsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListContactsResponse> UserListContactsAsync(UserListContactsParameter parameter)
        {
            return await this.SendAsync<UserListContactsParameter, UserListContactsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListContactsResponse> UserListContactsAsync(UserListContactsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListContactsParameter, UserListContactsResponse>(parameter, cancellationToken);
        }
    }
}
