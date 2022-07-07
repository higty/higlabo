using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksManagedebookassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneBooksManagedebookassignmentGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentGetResponse> IntuneBooksManagedebookassignmentGetAsync()
        {
            var p = new IntuneBooksManagedebookassignmentGetParameter();
            return await this.SendAsync<IntuneBooksManagedebookassignmentGetParameter, IntuneBooksManagedebookassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentGetResponse> IntuneBooksManagedebookassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksManagedebookassignmentGetParameter();
            return await this.SendAsync<IntuneBooksManagedebookassignmentGetParameter, IntuneBooksManagedebookassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentGetResponse> IntuneBooksManagedebookassignmentGetAsync(IntuneBooksManagedebookassignmentGetParameter parameter)
        {
            return await this.SendAsync<IntuneBooksManagedebookassignmentGetParameter, IntuneBooksManagedebookassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentGetResponse> IntuneBooksManagedebookassignmentGetAsync(IntuneBooksManagedebookassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksManagedebookassignmentGetParameter, IntuneBooksManagedebookassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
