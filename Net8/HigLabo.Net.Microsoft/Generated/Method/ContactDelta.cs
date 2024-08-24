using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contact-delta?view=graph-rest-1.0
    /// </summary>
    public partial class ContactDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? UsersId { get; set; }
            public string? ContactFoldersId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_ContactFolders_Id_Contacts_Delta: return $"/me/contactFolders/{Id}/contacts/delta";
                    case ApiPath.Users_Id_ContactFolders_Id_Contacts_Delta: return $"/users/{UsersId}/contactFolders/{ContactFoldersId}/contacts/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_ContactFolders_Id_Contacts_Delta,
            Users_Id_ContactFolders_Id_Contacts_Delta,
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
    public partial class ContactDeltaResponse : RestApiResponse<Contact>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contact-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contact-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContactDeltaResponse> ContactDeltaAsync()
        {
            var p = new ContactDeltaParameter();
            return await this.SendAsync<ContactDeltaParameter, ContactDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contact-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContactDeltaResponse> ContactDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new ContactDeltaParameter();
            return await this.SendAsync<ContactDeltaParameter, ContactDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contact-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContactDeltaResponse> ContactDeltaAsync(ContactDeltaParameter parameter)
        {
            return await this.SendAsync<ContactDeltaParameter, ContactDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contact-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContactDeltaResponse> ContactDeltaAsync(ContactDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContactDeltaParameter, ContactDeltaResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contact-delta?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Contact> ContactDeltaEnumerateAsync(ContactDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ContactDeltaParameter, ContactDeltaResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Contact>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
