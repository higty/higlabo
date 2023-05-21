using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
    /// </summary>
    public partial class OrgcontactDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Contacts_Delta: return $"/contacts/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Addresses,
            CompanyName,
            Department,
            DisplayName,
            GivenName,
            Id,
            JobTitle,
            Mail,
            MailNickname,
            OnPremisesLastSyncDateTime,
            OnPremisesProvisioningErrors,
            OnPremisesSyncEnabled,
            Phones,
            ProxyAddresses,
            Surname,
            DirectReports,
            Manager,
            MemberOf,
            TransitiveMemberOf,
        }
        public enum ApiPath
        {
            Contacts_Delta,
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
    public partial class OrgcontactDeltaResponse : RestApiResponse
    {
        public OrgContact[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactDeltaResponse> OrgcontactDeltaAsync()
        {
            var p = new OrgcontactDeltaParameter();
            return await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactDeltaResponse> OrgcontactDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new OrgcontactDeltaParameter();
            return await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactDeltaResponse> OrgcontactDeltaAsync(OrgcontactDeltaParameter parameter)
        {
            return await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactDeltaResponse> OrgcontactDeltaAsync(OrgcontactDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(parameter, cancellationToken);
        }
    }
}
