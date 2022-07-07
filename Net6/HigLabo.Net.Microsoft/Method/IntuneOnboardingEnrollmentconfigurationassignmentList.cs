using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingEnrollmentconfigurationassignmentListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string DeviceEnrollmentConfigurationId { get; set; }
    }
    public partial class IntuneOnboardingEnrollmentconfigurationassignmentListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-enrollmentconfigurationassignment?view=graph-rest-1.0
        /// </summary>
        public partial class EnrollmentConfigurationAssignment
        {
            public string? Id { get; set; }
            public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        }

        public EnrollmentConfigurationAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentListResponse> IntuneOnboardingEnrollmentconfigurationassignmentListAsync()
        {
            var p = new IntuneOnboardingEnrollmentconfigurationassignmentListParameter();
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentListParameter, IntuneOnboardingEnrollmentconfigurationassignmentListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentListResponse> IntuneOnboardingEnrollmentconfigurationassignmentListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingEnrollmentconfigurationassignmentListParameter();
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentListParameter, IntuneOnboardingEnrollmentconfigurationassignmentListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentListResponse> IntuneOnboardingEnrollmentconfigurationassignmentListAsync(IntuneOnboardingEnrollmentconfigurationassignmentListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentListParameter, IntuneOnboardingEnrollmentconfigurationassignmentListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentListResponse> IntuneOnboardingEnrollmentconfigurationassignmentListAsync(IntuneOnboardingEnrollmentconfigurationassignmentListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentListParameter, IntuneOnboardingEnrollmentconfigurationassignmentListResponse>(parameter, cancellationToken);
        }
    }
}
