using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
    /// </summary>
    public partial class OrgcontactListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Contacts: return $"/contacts";
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
            Contacts,
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
    public partial class OrgcontactListResponse : RestApiResponse
    {
        public OrgContact[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListResponse> OrgcontactListAsync()
        {
            var p = new OrgcontactListParameter();
            return await this.SendAsync<OrgcontactListParameter, OrgcontactListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListResponse> OrgcontactListAsync(CancellationToken cancellationToken)
        {
            var p = new OrgcontactListParameter();
            return await this.SendAsync<OrgcontactListParameter, OrgcontactListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListResponse> OrgcontactListAsync(OrgcontactListParameter parameter)
        {
            return await this.SendAsync<OrgcontactListParameter, OrgcontactListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListResponse> OrgcontactListAsync(OrgcontactListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrgcontactListParameter, OrgcontactListResponse>(parameter, cancellationToken);
        }
    }
}
