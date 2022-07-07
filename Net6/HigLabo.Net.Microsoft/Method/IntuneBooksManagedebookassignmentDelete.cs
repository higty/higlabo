using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksManagedebookassignmentDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ManagedEBookId { get; set; }
        public string ManagedEBookAssignmentId { get; set; }
    }
    public partial class IntuneBooksManagedebookassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentDeleteResponse> IntuneBooksManagedebookassignmentDeleteAsync()
        {
            var p = new IntuneBooksManagedebookassignmentDeleteParameter();
            return await this.SendAsync<IntuneBooksManagedebookassignmentDeleteParameter, IntuneBooksManagedebookassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentDeleteResponse> IntuneBooksManagedebookassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksManagedebookassignmentDeleteParameter();
            return await this.SendAsync<IntuneBooksManagedebookassignmentDeleteParameter, IntuneBooksManagedebookassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentDeleteResponse> IntuneBooksManagedebookassignmentDeleteAsync(IntuneBooksManagedebookassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneBooksManagedebookassignmentDeleteParameter, IntuneBooksManagedebookassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebookassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookassignmentDeleteResponse> IntuneBooksManagedebookassignmentDeleteAsync(IntuneBooksManagedebookassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksManagedebookassignmentDeleteParameter, IntuneBooksManagedebookassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
