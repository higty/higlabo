using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsTermsandconditionsListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_TermsAndConditions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TermsAndConditions: return $"/deviceManagement/termsAndConditions";
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
    public partial class IntuneCompanytermsTermsandconditionsListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-companyterms-termsandconditions?view=graph-rest-1.0
        /// </summary>
        public partial class TermsAndConditions
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

        public TermsAndConditions[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsListResponse> IntuneCompanytermsTermsandconditionsListAsync()
        {
            var p = new IntuneCompanytermsTermsandconditionsListParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsListParameter, IntuneCompanytermsTermsandconditionsListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsListResponse> IntuneCompanytermsTermsandconditionsListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsTermsandconditionsListParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsListParameter, IntuneCompanytermsTermsandconditionsListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsListResponse> IntuneCompanytermsTermsandconditionsListAsync(IntuneCompanytermsTermsandconditionsListParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsListParameter, IntuneCompanytermsTermsandconditionsListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsListResponse> IntuneCompanytermsTermsandconditionsListAsync(IntuneCompanytermsTermsandconditionsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsListParameter, IntuneCompanytermsTermsandconditionsListResponse>(parameter, cancellationToken);
        }
    }
}
