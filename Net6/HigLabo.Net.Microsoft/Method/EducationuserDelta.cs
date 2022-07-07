using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationuserDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Users_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Users_Delta: return $"/education/users/delta";
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
    public partial class EducationuserDeltaResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/educationuser?view=graph-rest-1.0
        /// </summary>
        public partial class EducationUser
        {
            public enum EducationUserEducationExternalSource
            {
                Sis,
                Manual,
            }
            public enum EducationUserEducationUserRole
            {
                Student,
                Teacher,
                None,
                UnknownFutureValue,
            }

            public bool? AccountEnabled { get; set; }
            public AssignedLicense[]? AssignedLicenses { get; set; }
            public AssignedPlan[]? AssignedPlans { get; set; }
            public String[]? BusinessPhones { get; set; }
            public IdentitySet? CreatedBy { get; set; }
            public string? Department { get; set; }
            public string? DisplayName { get; set; }
            public EducationUserEducationExternalSource ExternalSource { get; set; }
            public string? ExternalSourceDetail { get; set; }
            public string? GivenName { get; set; }
            public string? Id { get; set; }
            public string? Mail { get; set; }
            public PhysicalAddress? MailingAddress { get; set; }
            public string? MailNickname { get; set; }
            public string? MiddleName { get; set; }
            public string? MobilePhone { get; set; }
            public EducationOnPremisesInfo? OnPremisesInfo { get; set; }
            public string? PasswordPolicies { get; set; }
            public PasswordProfile? PasswordProfile { get; set; }
            public string? PreferredLanguage { get; set; }
            public EducationUserEducationUserRole PrimaryRole { get; set; }
            public ProvisionedPlan[]? ProvisionedPlans { get; set; }
            public RelatedContact[]? RelatedContacts { get; set; }
            public PhysicalAddress? ResidenceAddress { get; set; }
            public bool? ShowInAddressList { get; set; }
            public EducationStudent? Student { get; set; }
            public string? Surname { get; set; }
            public Teacher? Teacher { get; set; }
            public string? UsageLocation { get; set; }
            public string? UserPrincipalName { get; set; }
            public string? UserType { get; set; }
        }

        public EducationUser[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserDeltaResponse> EducationuserDeltaAsync()
        {
            var p = new EducationuserDeltaParameter();
            return await this.SendAsync<EducationuserDeltaParameter, EducationuserDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserDeltaResponse> EducationuserDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new EducationuserDeltaParameter();
            return await this.SendAsync<EducationuserDeltaParameter, EducationuserDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserDeltaResponse> EducationuserDeltaAsync(EducationuserDeltaParameter parameter)
        {
            return await this.SendAsync<EducationuserDeltaParameter, EducationuserDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserDeltaResponse> EducationuserDeltaAsync(EducationuserDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationuserDeltaParameter, EducationuserDeltaResponse>(parameter, cancellationToken);
        }
    }
}
