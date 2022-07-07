using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrgcontactGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Contacts_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Contacts_Id: return $"/contacts/{Id}";
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
    public partial class OrgcontactGetResponse : RestApiResponse
    {
        public PhysicalOfficeAddress[]? Addresses { get; set; }
        public string? CompanyName { get; set; }
        public string? Department { get; set; }
        public string? DisplayName { get; set; }
        public string? GivenName { get; set; }
        public string? Id { get; set; }
        public string? JobTitle { get; set; }
        public string? Mail { get; set; }
        public string? MailNickname { get; set; }
        public DateTimeOffset? OnPremisesLastSyncDateTime { get; set; }
        public OnPremisesProvisioningError[]? OnPremisesProvisioningErrors { get; set; }
        public bool? OnPremisesSyncEnabled { get; set; }
        public Phone[]? Phones { get; set; }
        public String[]? ProxyAddresses { get; set; }
        public string? Surname { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactGetResponse> OrgcontactGetAsync()
        {
            var p = new OrgcontactGetParameter();
            return await this.SendAsync<OrgcontactGetParameter, OrgcontactGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactGetResponse> OrgcontactGetAsync(CancellationToken cancellationToken)
        {
            var p = new OrgcontactGetParameter();
            return await this.SendAsync<OrgcontactGetParameter, OrgcontactGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactGetResponse> OrgcontactGetAsync(OrgcontactGetParameter parameter)
        {
            return await this.SendAsync<OrgcontactGetParameter, OrgcontactGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactGetResponse> OrgcontactGetAsync(OrgcontactGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrgcontactGetParameter, OrgcontactGetResponse>(parameter, cancellationToken);
        }
    }
}
