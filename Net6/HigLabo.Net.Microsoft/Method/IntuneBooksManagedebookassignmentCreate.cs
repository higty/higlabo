using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksManagedebookassignmentCreateParameter : IRestApiParameter
    {
        public enum IntuneBooksManagedebookassignmentCreateParameterInstallIntent
        {
            Available,
            Required,
            Uninstall,
            AvailableWithoutEnrollment,
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedEBooks_ManagedEBookId_Assignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedEBooks_ManagedEBookId_Assignments: return $"/deviceAppManagement/managedEBooks/{ManagedEBookId}/assignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        public IntuneBooksManagedebookassignmentCreateParameterInstallIntent InstallIntent { get; set; }
        public string ManagedEBookId { get; set; }
    }
    public partial class IntuneBooksManagedebookassignmentCreateResponse : RestApiResponse
    {
        public enum ManagedEBookAssignmentInstallIntent
        {
            Available,
            Required,
            Uninstall,
            AvailableWithoutEnrollment,
        }

        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        public InstallIntent? InstallIntent { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentCreateResponse> IntuneBooksManagedebookassignmentCreateAsync()
        {
            var p = new IntuneBooksManagedebookassignmentCreateParameter();
            return await this.SendAsync<IntuneBooksManagedebookassignmentCreateParameter, IntuneBooksManagedebookassignmentCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentCreateResponse> IntuneBooksManagedebookassignmentCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksManagedebookassignmentCreateParameter();
            return await this.SendAsync<IntuneBooksManagedebookassignmentCreateParameter, IntuneBooksManagedebookassignmentCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentCreateResponse> IntuneBooksManagedebookassignmentCreateAsync(IntuneBooksManagedebookassignmentCreateParameter parameter)
        {
            return await this.SendAsync<IntuneBooksManagedebookassignmentCreateParameter, IntuneBooksManagedebookassignmentCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentCreateResponse> IntuneBooksManagedebookassignmentCreateAsync(IntuneBooksManagedebookassignmentCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksManagedebookassignmentCreateParameter, IntuneBooksManagedebookassignmentCreateResponse>(parameter, cancellationToken);
        }
    }
}
