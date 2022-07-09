using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MailfolderDeleteParameter : IRestApiParameter
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
