using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContactDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string UsersId { get; set; }
            public string ContactFoldersId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_ContactFolders_Id_Contacts_Delta: return $"/me/contactFolders/{Id}/contacts/delta";
                    case ApiPath.Users_Id_ContactFolders_Id_Contacts_Delta: return $"/users/{UsersId}/contactFolders/{ContactFoldersId}/contacts/delta";
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
            Me_ContactFolders_Id_Contacts_Delta,
            Users_Id_ContactFolders_Id_Contacts_Delta,
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
    public partial class ContactDeltaResponse : RestApiResponse
    {
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
