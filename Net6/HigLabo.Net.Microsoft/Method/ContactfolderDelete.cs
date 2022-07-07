using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContactfolderDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_ContactFolders_Id,
            Users_IdOrUserPrincipalName_ContactFolders_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_ContactFolders_Id: return $"/me/contactFolders/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_ContactFolders_Id: return $"/users/{IdOrUserPrincipalName}/contactFolders/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class ContactfolderDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderDeleteResponse> ContactfolderDeleteAsync()
        {
            var p = new ContactfolderDeleteParameter();
            return await this.SendAsync<ContactfolderDeleteParameter, ContactfolderDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderDeleteResponse> ContactfolderDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ContactfolderDeleteParameter();
            return await this.SendAsync<ContactfolderDeleteParameter, ContactfolderDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderDeleteResponse> ContactfolderDeleteAsync(ContactfolderDeleteParameter parameter)
        {
            return await this.SendAsync<ContactfolderDeleteParameter, ContactfolderDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderDeleteResponse> ContactfolderDeleteAsync(ContactfolderDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContactfolderDeleteParameter, ContactfolderDeleteResponse>(parameter, cancellationToken);
        }
    }
}
