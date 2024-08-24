using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
    /// </summary>
    public partial class MailFolderListMessagerulesParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class MailFolderListMessagerulesResponse : RestApiResponse<MessageRule>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderListMessagerulesResponse> MailFolderListMessagerulesAsync()
        {
            var p = new MailFolderListMessagerulesParameter();
            return await this.SendAsync<MailFolderListMessagerulesParameter, MailFolderListMessagerulesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderListMessagerulesResponse> MailFolderListMessagerulesAsync(CancellationToken cancellationToken)
        {
            var p = new MailFolderListMessagerulesParameter();
            return await this.SendAsync<MailFolderListMessagerulesParameter, MailFolderListMessagerulesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderListMessagerulesResponse> MailFolderListMessagerulesAsync(MailFolderListMessagerulesParameter parameter)
        {
            return await this.SendAsync<MailFolderListMessagerulesParameter, MailFolderListMessagerulesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderListMessagerulesResponse> MailFolderListMessagerulesAsync(MailFolderListMessagerulesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailFolderListMessagerulesParameter, MailFolderListMessagerulesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-messagerules?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<MessageRule> MailFolderListMessagerulesEnumerateAsync(MailFolderListMessagerulesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<MailFolderListMessagerulesParameter, MailFolderListMessagerulesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<MessageRule>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
