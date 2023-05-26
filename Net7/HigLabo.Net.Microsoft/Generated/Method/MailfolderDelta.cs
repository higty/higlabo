using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MailfolderDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_MailFolders_Delta: return $"/me/mailFolders/delta";
                    case ApiPath.Users_Id_MailFolders_Delta: return $"/users/{Id}/mailFolders/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ChildFolderCount,
            DisplayName,
            Id,
            IsHidden,
            ParentFolderId,
            TotalItemCount,
            UnreadItemCount,
            ChildFolders,
            MessageRules,
            Messages,
            MultiValueExtendedProperties,
            SingleValueExtendedProperties,
        }
        public enum ApiPath
        {
            Me_MailFolders_Delta,
            Users_Id_MailFolders_Delta,
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
    public partial class MailfolderDeltaResponse : RestApiResponse
    {
        public MailFolder[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderDeltaResponse> MailfolderDeltaAsync()
        {
            var p = new MailfolderDeltaParameter();
            return await this.SendAsync<MailfolderDeltaParameter, MailfolderDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderDeltaResponse> MailfolderDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new MailfolderDeltaParameter();
            return await this.SendAsync<MailfolderDeltaParameter, MailfolderDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderDeltaResponse> MailfolderDeltaAsync(MailfolderDeltaParameter parameter)
        {
            return await this.SendAsync<MailfolderDeltaParameter, MailfolderDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderDeltaResponse> MailfolderDeltaAsync(MailfolderDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailfolderDeltaParameter, MailfolderDeltaResponse>(parameter, cancellationToken);
        }
    }
}
