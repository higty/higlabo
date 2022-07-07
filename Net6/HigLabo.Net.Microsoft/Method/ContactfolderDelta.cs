using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContactfolderDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_ContactFolders_Delta,
            Users_Id_ContactFolders_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_ContactFolders_Delta: return $"/me/contactFolders/delta";
                    case ApiPath.Users_Id_ContactFolders_Delta: return $"/users/{Id}/contactFolders/delta";
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
    public partial class ContactfolderDeltaResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/contactfolder?view=graph-rest-1.0
        /// </summary>
        public partial class ContactFolder
        {
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public string? ParentFolderId { get; set; }
        }

        public ContactFolder[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderDeltaResponse> ContactfolderDeltaAsync()
        {
            var p = new ContactfolderDeltaParameter();
            return await this.SendAsync<ContactfolderDeltaParameter, ContactfolderDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderDeltaResponse> ContactfolderDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new ContactfolderDeltaParameter();
            return await this.SendAsync<ContactfolderDeltaParameter, ContactfolderDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderDeltaResponse> ContactfolderDeltaAsync(ContactfolderDeltaParameter parameter)
        {
            return await this.SendAsync<ContactfolderDeltaParameter, ContactfolderDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderDeltaResponse> ContactfolderDeltaAsync(ContactfolderDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContactfolderDeltaParameter, ContactfolderDeltaResponse>(parameter, cancellationToken);
        }
    }
}
