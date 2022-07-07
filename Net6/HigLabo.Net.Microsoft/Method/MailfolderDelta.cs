using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MailfolderDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_MailFolders_Delta,
            Users_Id_MailFolders_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_MailFolders_Delta: return $"/me/mailFolders/delta";
                    case ApiPath.Users_Id_MailFolders_Delta: return $"/users/{Id}/mailFolders/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
    }
    public partial class MailfolderDeltaResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/mailfolder?view=graph-rest-1.0
        /// </summary>
        public partial class MailFolder
        {
            public Int32? ChildFolderCount { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public bool? IsHidden { get; set; }
            public string? ParentFolderId { get; set; }
            public Int32? TotalItemCount { get; set; }
            public Int32? UnreadItemCount { get; set; }
        }

        public MailFolder[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderDeltaResponse> MailfolderDeltaAsync()
        {
            var p = new MailfolderDeltaParameter();
            return await this.SendAsync<MailfolderDeltaParameter, MailfolderDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderDeltaResponse> MailfolderDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new MailfolderDeltaParameter();
            return await this.SendAsync<MailfolderDeltaParameter, MailfolderDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderDeltaResponse> MailfolderDeltaAsync(MailfolderDeltaParameter parameter)
        {
            return await this.SendAsync<MailfolderDeltaParameter, MailfolderDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderDeltaResponse> MailfolderDeltaAsync(MailfolderDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailfolderDeltaParameter, MailfolderDeltaResponse>(parameter, cancellationToken);
        }
    }
}
