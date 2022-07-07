using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingVpptokenListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_VppTokens,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_VppTokens: return $"/deviceAppManagement/vppTokens";
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
    public partial class IntuneOnboardingVpptokenListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-vpptoken?view=graph-rest-1.0
        /// </summary>
        public partial class VppToken
        {
            public enum VppTokenVppTokenAccountType
            {
                Business,
                Education,
            }
            public enum VppTokenVppTokenState
            {
                Unknown,
                Valid,
                Expired,
                Invalid,
                AssignedToExternalMDM,
            }
            public enum VppTokenVppTokenSyncStatus
            {
                None,
                InProgress,
                Completed,
                Failed,
            }

            public string? Id { get; set; }
            public string? OrganizationName { get; set; }
            public VppTokenAccountType? VppTokenAccountType { get; set; }
            public string? AppleId { get; set; }
            public DateTimeOffset? ExpirationDateTime { get; set; }
            public DateTimeOffset? LastSyncDateTime { get; set; }
            public string? Token { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public VppTokenState? State { get; set; }
            public VppTokenSyncStatus? LastSyncStatus { get; set; }
            public bool? AutomaticallyUpdateApps { get; set; }
            public string? CountryOrRegion { get; set; }
        }

        public VppToken[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenListResponse> IntuneOnboardingVpptokenListAsync()
        {
            var p = new IntuneOnboardingVpptokenListParameter();
            return await this.SendAsync<IntuneOnboardingVpptokenListParameter, IntuneOnboardingVpptokenListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenListResponse> IntuneOnboardingVpptokenListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingVpptokenListParameter();
            return await this.SendAsync<IntuneOnboardingVpptokenListParameter, IntuneOnboardingVpptokenListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenListResponse> IntuneOnboardingVpptokenListAsync(IntuneOnboardingVpptokenListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingVpptokenListParameter, IntuneOnboardingVpptokenListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenListResponse> IntuneOnboardingVpptokenListAsync(IntuneOnboardingVpptokenListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingVpptokenListParameter, IntuneOnboardingVpptokenListResponse>(parameter, cancellationToken);
        }
    }
}
