using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingEnrollmentconfigurationassignmentCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceEnrollmentConfigurations_DeviceEnrollmentConfigurationId_Assignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceEnrollmentConfigurations_DeviceEnrollmentConfigurationId_Assignments: return $"/deviceManagement/deviceEnrollmentConfigurations/{DeviceEnrollmentConfigurationId}/assignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        public string DeviceEnrollmentConfigurationId { get; set; }
    }
    public partial class IntuneOnboardingEnrollmentconfigurationassignmentCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentCreateResponse> IntuneOnboardingEnrollmentconfigurationassignmentCreateAsync()
        {
            var p = new IntuneOnboardingEnrollmentconfigurationassignmentCreateParameter();
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentCreateParameter, IntuneOnboardingEnrollmentconfigurationassignmentCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentCreateResponse> IntuneOnboardingEnrollmentconfigurationassignmentCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingEnrollmentconfigurationassignmentCreateParameter();
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentCreateParameter, IntuneOnboardingEnrollmentconfigurationassignmentCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentCreateResponse> IntuneOnboardingEnrollmentconfigurationassignmentCreateAsync(IntuneOnboardingEnrollmentconfigurationassignmentCreateParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentCreateParameter, IntuneOnboardingEnrollmentconfigurationassignmentCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentCreateResponse> IntuneOnboardingEnrollmentconfigurationassignmentCreateAsync(IntuneOnboardingEnrollmentconfigurationassignmentCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentCreateParameter, IntuneOnboardingEnrollmentconfigurationassignmentCreateResponse>(parameter, cancellationToken);
        }
    }
}
