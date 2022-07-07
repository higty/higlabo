using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingVpptokenCreateParameter : IRestApiParameter
    {
        public enum IntuneOnboardingVpptokenCreateParameterVppTokenAccountType
        {
            Business,
            Education,
        }
        public enum IntuneOnboardingVpptokenCreateParameterVppTokenState
        {
            Unknown,
            Valid,
            Expired,
            Invalid,
            AssignedToExternalMDM,
        }
        public enum IntuneOnboardingVpptokenCreateParameterVppTokenSyncStatus
        {
            None,
            InProgress,
            Completed,
            Failed,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? OrganizationName { get; set; }
        public IntuneOnboardingVpptokenCreateParameterVppTokenAccountType VppTokenAccountType { get; set; }
        public string? AppleId { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public DateTimeOffset? LastSyncDateTime { get; set; }
        public string? Token { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public IntuneOnboardingVpptokenCreateParameterVppTokenState State { get; set; }
        public IntuneOnboardingVpptokenCreateParameterVppTokenSyncStatus LastSyncStatus { get; set; }
        public bool? AutomaticallyUpdateApps { get; set; }
        public string? CountryOrRegion { get; set; }
    }
    public partial class IntuneOnboardingVpptokenCreateResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenCreateResponse> IntuneOnboardingVpptokenCreateAsync()
        {
            var p = new IntuneOnboardingVpptokenCreateParameter();
            return await this.SendAsync<IntuneOnboardingVpptokenCreateParameter, IntuneOnboardingVpptokenCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenCreateResponse> IntuneOnboardingVpptokenCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingVpptokenCreateParameter();
            return await this.SendAsync<IntuneOnboardingVpptokenCreateParameter, IntuneOnboardingVpptokenCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenCreateResponse> IntuneOnboardingVpptokenCreateAsync(IntuneOnboardingVpptokenCreateParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingVpptokenCreateParameter, IntuneOnboardingVpptokenCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenCreateResponse> IntuneOnboardingVpptokenCreateAsync(IntuneOnboardingVpptokenCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingVpptokenCreateParameter, IntuneOnboardingVpptokenCreateResponse>(parameter, cancellationToken);
        }
    }
}
