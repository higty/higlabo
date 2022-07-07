using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsTermsandconditionsacceptancestatusListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_TermsAndConditions_TermsAndConditionsId_AcceptanceStatuses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TermsAndConditions_TermsAndConditionsId_AcceptanceStatuses: return $"/deviceManagement/termsAndConditions/{TermsAndConditionsId}/acceptanceStatuses";
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
        public string TermsAndConditionsId { get; set; }
    }
    public partial class IntuneCompanytermsTermsandconditionsacceptancestatusListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-companyterms-termsandconditionsacceptancestatus?view=graph-rest-1.0
        /// </summary>
        public partial class TermsAndConditionsAcceptanceStatus
        {
            public string? Id { get; set; }
            public string? UserDisplayName { get; set; }
            public Int32? AcceptedVersion { get; set; }
            public DateTimeOffset? AcceptedDateTime { get; set; }
            public string? UserPrincipalName { get; set; }
        }

        public TermsAndConditionsAcceptanceStatus[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusListResponse> IntuneCompanytermsTermsandconditionsacceptancestatusListAsync()
        {
            var p = new IntuneCompanytermsTermsandconditionsacceptancestatusListParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusListParameter, IntuneCompanytermsTermsandconditionsacceptancestatusListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusListResponse> IntuneCompanytermsTermsandconditionsacceptancestatusListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsTermsandconditionsacceptancestatusListParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusListParameter, IntuneCompanytermsTermsandconditionsacceptancestatusListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusListResponse> IntuneCompanytermsTermsandconditionsacceptancestatusListAsync(IntuneCompanytermsTermsandconditionsacceptancestatusListParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusListParameter, IntuneCompanytermsTermsandconditionsacceptancestatusListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusListResponse> IntuneCompanytermsTermsandconditionsacceptancestatusListAsync(IntuneCompanytermsTermsandconditionsacceptancestatusListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusListParameter, IntuneCompanytermsTermsandconditionsacceptancestatusListResponse>(parameter, cancellationToken);
        }
    }
}
