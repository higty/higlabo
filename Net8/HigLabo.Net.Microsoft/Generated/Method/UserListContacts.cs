using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-contacts?view=graph-rest-1.0
    /// </summary>
    public partial class UserListContactsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? Id { get; set; }
            public string? ContactFoldersId { get; set; }
            public string? ChildFoldersId { get; set; }
            public string? UsersIdOrUserPrincipalName { get; set; }

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
            Me_Contactfolders_Id_Contacts,
            Users_IdOrUserPrincipalName_Contactfolders_Id_Contacts,
            Me_ContactFolders_Id_ChildFolders_Id__Contacts,
            Users_IdOrUserPrincipalName_ContactFolders_Id_ChildFolders_Id_Contacts,
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
    public partial class UserListContactsResponse : RestApiResponse<Contact>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-contacts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListContactsResponse> UserListContactsAsync()
        {
            var p = new UserListContactsParameter();
            return await this.SendAsync<UserListContactsParameter, UserListContactsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListContactsResponse> UserListContactsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListContactsParameter();
            return await this.SendAsync<UserListContactsParameter, UserListContactsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListContactsResponse> UserListContactsAsync(UserListContactsParameter parameter)
        {
            return await this.SendAsync<UserListContactsParameter, UserListContactsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListContactsResponse> UserListContactsAsync(UserListContactsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListContactsParameter, UserListContactsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contacts?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Contact> UserListContactsEnumerateAsync(UserListContactsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserListContactsParameter, UserListContactsResponse>(parameter, cancellationToken);
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
}
