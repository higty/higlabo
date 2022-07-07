using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MailfolderDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_MailFolders_Id,
            Users_IdOrUserPrincipalName_MailFolders_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_MailFolders_Id: return $"/me/mailFolders/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id: return $"/users/{IdOrUserPrincipalName}/mailFolders/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class MailfolderDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderDeleteResponse> MailfolderDeleteAsync()
        {
            var p = new MailfolderDeleteParameter();
            return await this.SendAsync<MailfolderDeleteParameter, MailfolderDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderDeleteResponse> MailfolderDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new MailfolderDeleteParameter();
            return await this.SendAsync<MailfolderDeleteParameter, MailfolderDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderDeleteResponse> MailfolderDeleteAsync(MailfolderDeleteParameter parameter)
        {
            return await this.SendAsync<MailfolderDeleteParameter, MailfolderDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderDeleteResponse> MailfolderDeleteAsync(MailfolderDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailfolderDeleteParameter, MailfolderDeleteResponse>(parameter, cancellationToken);
        }
    }
}
