using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksIosvppebookassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedEBooks_ManagedEBookId_Assignments_ManagedEBookAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedEBooks_ManagedEBookId_Assignments_ManagedEBookAssignmentId: return $"/deviceAppManagement/managedEBooks/{ManagedEBookId}/assignments/{ManagedEBookAssignmentId}";
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
        public string ManagedEBookAssignmentId { get; set; }
    }
    public partial class IntuneBooksIosvppebookassignmentGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentGetResponse> IntuneBooksIosvppebookassignmentGetAsync()
        {
            var p = new IntuneBooksIosvppebookassignmentGetParameter();
            return await this.SendAsync<IntuneBooksIosvppebookassignmentGetParameter, IntuneBooksIosvppebookassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentGetResponse> IntuneBooksIosvppebookassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksIosvppebookassignmentGetParameter();
            return await this.SendAsync<IntuneBooksIosvppebookassignmentGetParameter, IntuneBooksIosvppebookassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentGetResponse> IntuneBooksIosvppebookassignmentGetAsync(IntuneBooksIosvppebookassignmentGetParameter parameter)
        {
            return await this.SendAsync<IntuneBooksIosvppebookassignmentGetParameter, IntuneBooksIosvppebookassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentGetResponse> IntuneBooksIosvppebookassignmentGetAsync(IntuneBooksIosvppebookassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksIosvppebookassignmentGetParameter, IntuneBooksIosvppebookassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
