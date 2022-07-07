using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksManagedebookassignmentListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string ManagedEBookId { get; set; }
    }
    public partial class IntuneBooksManagedebookassignmentListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-books-managedebookassignment?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedEBookAssignment
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

        public ManagedEBookAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentListResponse> IntuneBooksManagedebookassignmentListAsync()
        {
            var p = new IntuneBooksManagedebookassignmentListParameter();
            return await this.SendAsync<IntuneBooksManagedebookassignmentListParameter, IntuneBooksManagedebookassignmentListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentListResponse> IntuneBooksManagedebookassignmentListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksManagedebookassignmentListParameter();
            return await this.SendAsync<IntuneBooksManagedebookassignmentListParameter, IntuneBooksManagedebookassignmentListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentListResponse> IntuneBooksManagedebookassignmentListAsync(IntuneBooksManagedebookassignmentListParameter parameter)
        {
            return await this.SendAsync<IntuneBooksManagedebookassignmentListParameter, IntuneBooksManagedebookassignmentListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentListResponse> IntuneBooksManagedebookassignmentListAsync(IntuneBooksManagedebookassignmentListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksManagedebookassignmentListParameter, IntuneBooksManagedebookassignmentListResponse>(parameter, cancellationToken);
        }
    }
}
