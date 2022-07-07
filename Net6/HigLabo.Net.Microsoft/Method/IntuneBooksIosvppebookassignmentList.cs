using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksIosvppebookassignmentListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneBooksIosvppebookassignmentListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-books-iosvppebookassignment?view=graph-rest-1.0
        /// </summary>
        public partial class IosVppEBookAssignment
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

        public IosVppEBookAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentListResponse> IntuneBooksIosvppebookassignmentListAsync()
        {
            var p = new IntuneBooksIosvppebookassignmentListParameter();
            return await this.SendAsync<IntuneBooksIosvppebookassignmentListParameter, IntuneBooksIosvppebookassignmentListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentListResponse> IntuneBooksIosvppebookassignmentListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksIosvppebookassignmentListParameter();
            return await this.SendAsync<IntuneBooksIosvppebookassignmentListParameter, IntuneBooksIosvppebookassignmentListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentListResponse> IntuneBooksIosvppebookassignmentListAsync(IntuneBooksIosvppebookassignmentListParameter parameter)
        {
            return await this.SendAsync<IntuneBooksIosvppebookassignmentListParameter, IntuneBooksIosvppebookassignmentListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentListResponse> IntuneBooksIosvppebookassignmentListAsync(IntuneBooksIosvppebookassignmentListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksIosvppebookassignmentListParameter, IntuneBooksIosvppebookassignmentListResponse>(parameter, cancellationToken);
        }
    }
}
