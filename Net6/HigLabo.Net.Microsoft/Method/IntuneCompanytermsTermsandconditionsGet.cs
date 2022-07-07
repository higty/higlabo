using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsTermsandconditionsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_TermsAndConditions_TermsAndConditionsId,
            DeviceManagement_TermsAndConditions_TermsAndConditionsId_AcceptanceStatuses_TermsAndConditionsAcceptanceStatusId_TermsAndConditions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TermsAndConditions_TermsAndConditionsId: return $"/deviceManagement/termsAndConditions/{TermsAndConditionsId}";
                    case ApiPath.DeviceManagement_TermsAndConditions_TermsAndConditionsId_AcceptanceStatuses_TermsAndConditionsAcceptanceStatusId_TermsAndConditions: return $"/deviceManagement/termsAndConditions/{TermsAndConditionsId}/acceptanceStatuses/{TermsAndConditionsAcceptanceStatusId}/termsAndConditions";
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
        public string TermsAndConditionsAcceptanceStatusId { get; set; }
    }
    public partial class IntuneCompanytermsTermsandconditionsGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? BodyText { get; set; }
        public string? AcceptanceStatement { get; set; }
        public Int32? Version { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsGetResponse> IntuneCompanytermsTermsandconditionsGetAsync()
        {
            var p = new IntuneCompanytermsTermsandconditionsGetParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsGetParameter, IntuneCompanytermsTermsandconditionsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsGetResponse> IntuneCompanytermsTermsandconditionsGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsTermsandconditionsGetParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsGetParameter, IntuneCompanytermsTermsandconditionsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsGetResponse> IntuneCompanytermsTermsandconditionsGetAsync(IntuneCompanytermsTermsandconditionsGetParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsGetParameter, IntuneCompanytermsTermsandconditionsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsGetResponse> IntuneCompanytermsTermsandconditionsGetAsync(IntuneCompanytermsTermsandconditionsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsGetParameter, IntuneCompanytermsTermsandconditionsGetResponse>(parameter, cancellationToken);
        }
    }
}
