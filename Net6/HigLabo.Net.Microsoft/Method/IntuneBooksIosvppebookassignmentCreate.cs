using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksIosvppebookassignmentCreateParameter : IRestApiParameter
    {
        public enum IntuneBooksIosvppebookassignmentCreateParameterInstallIntent
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
        public IntuneBooksIosvppebookassignmentCreateParameterInstallIntent InstallIntent { get; set; }
        public string ManagedEBookId { get; set; }
    }
    public partial class IntuneBooksIosvppebookassignmentCreateResponse : RestApiResponse
    {
        public enum IosVppEBookAssignmentInstallIntent
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentCreateResponse> IntuneBooksIosvppebookassignmentCreateAsync()
        {
            var p = new IntuneBooksIosvppebookassignmentCreateParameter();
            return await this.SendAsync<IntuneBooksIosvppebookassignmentCreateParameter, IntuneBooksIosvppebookassignmentCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentCreateResponse> IntuneBooksIosvppebookassignmentCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksIosvppebookassignmentCreateParameter();
            return await this.SendAsync<IntuneBooksIosvppebookassignmentCreateParameter, IntuneBooksIosvppebookassignmentCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentCreateResponse> IntuneBooksIosvppebookassignmentCreateAsync(IntuneBooksIosvppebookassignmentCreateParameter parameter)
        {
            return await this.SendAsync<IntuneBooksIosvppebookassignmentCreateParameter, IntuneBooksIosvppebookassignmentCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentCreateResponse> IntuneBooksIosvppebookassignmentCreateAsync(IntuneBooksIosvppebookassignmentCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksIosvppebookassignmentCreateParameter, IntuneBooksIosvppebookassignmentCreateResponse>(parameter, cancellationToken);
        }
    }
}
