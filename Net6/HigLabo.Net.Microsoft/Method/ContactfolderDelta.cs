using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContactfolderDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_ContactFolders_Delta: return $"/me/contactFolders/delta";
                    case ApiPath.Users_Id_ContactFolders_Delta: return $"/users/{Id}/contactFolders/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
            ParentFolderId,
            ChildFolders,
            Contacts,
            MultiValueExtendedProperties,
            SingleValueExtendedProperties,
        }
        public enum ApiPath
        {
            Me_ContactFolders_Delta,
            Users_Id_ContactFolders_Delta,
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
    public partial class ContactfolderDeltaResponse : RestApiResponse
    {
        public ContactFolder[]? Value { get; set; }
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
