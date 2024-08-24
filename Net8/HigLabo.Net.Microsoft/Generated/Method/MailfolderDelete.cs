using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MailFolderDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_MailFolders_Id: return $"/me/mailFolders/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id: return $"/users/{IdOrUserPrincipalName}/mailFolders/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_MailFolders_Id,
            Users_IdOrUserPrincipalName_MailFolders_Id,
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
    public partial class MailFolderDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderDeleteResponse> MailFolderDeleteAsync()
        {
            var p = new MailFolderDeleteParameter();
            return await this.SendAsync<MailFolderDeleteParameter, MailFolderDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderDeleteResponse> MailFolderDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new MailFolderDeleteParameter();
            return await this.SendAsync<MailFolderDeleteParameter, MailFolderDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderDeleteResponse> MailFolderDeleteAsync(MailFolderDeleteParameter parameter)
        {
            return await this.SendAsync<MailFolderDeleteParameter, MailFolderDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderDeleteResponse> MailFolderDeleteAsync(MailFolderDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailFolderDeleteParameter, MailFolderDeleteResponse>(parameter, cancellationToken);
        }
    }
}
