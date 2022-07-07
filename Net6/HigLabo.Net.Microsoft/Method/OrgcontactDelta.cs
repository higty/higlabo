using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrgcontactDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Contacts_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Contacts_Delta: return $"/contacts/delta";
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
    }
    public partial class OrgcontactDeltaResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/orgcontact?view=graph-rest-1.0
        /// </summary>
        public partial class OrgContact
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

        public OrgContact[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactDeltaResponse> OrgcontactDeltaAsync()
        {
            var p = new OrgcontactDeltaParameter();
            return await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactDeltaResponse> OrgcontactDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new OrgcontactDeltaParameter();
            return await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactDeltaResponse> OrgcontactDeltaAsync(OrgcontactDeltaParameter parameter)
        {
            return await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactDeltaResponse> OrgcontactDeltaAsync(OrgcontactDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(parameter, cancellationToken);
        }
    }
}
