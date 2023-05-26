using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
    /// </summary>
    public partial class MailfolderListMessagerulesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_MailFolders_Inbox_MessageRules: return $"/me/mailFolders/inbox/messageRules";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Inbox_MessageRules: return $"/users/{IdOrUserPrincipalName}/mailFolders/inbox/messageRules";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Actions,
            Conditions,
            DisplayName,
            Exceptions,
            HasError,
            Id,
            IsEnabled,
            IsReadOnly,
            Sequence,
        }
        public enum ApiPath
        {
            Me_MailFolders_Inbox_MessageRules,
            Users_IdOrUserPrincipalName_MailFolders_Inbox_MessageRules,
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
    public partial class MailfolderListMessagerulesResponse : RestApiResponse
    {
        public MessageRule[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListMessagerulesResponse> MailfolderListMessagerulesAsync()
        {
            var p = new MailfolderListMessagerulesParameter();
            return await this.SendAsync<MailfolderListMessagerulesParameter, MailfolderListMessagerulesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListMessagerulesResponse> MailfolderListMessagerulesAsync(CancellationToken cancellationToken)
        {
            var p = new MailfolderListMessagerulesParameter();
            return await this.SendAsync<MailfolderListMessagerulesParameter, MailfolderListMessagerulesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListMessagerulesResponse> MailfolderListMessagerulesAsync(MailfolderListMessagerulesParameter parameter)
        {
            return await this.SendAsync<MailfolderListMessagerulesParameter, MailfolderListMessagerulesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListMessagerulesResponse> MailfolderListMessagerulesAsync(MailfolderListMessagerulesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailfolderListMessagerulesParameter, MailfolderListMessagerulesResponse>(parameter, cancellationToken);
        }
    }
}
