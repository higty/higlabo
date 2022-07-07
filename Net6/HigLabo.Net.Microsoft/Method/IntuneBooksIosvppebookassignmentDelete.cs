using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksIosvppebookassignmentDeleteParameter : IRestApiParameter
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
    public partial class IntuneBooksIosvppebookassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentDeleteResponse> IntuneBooksIosvppebookassignmentDeleteAsync()
        {
            var p = new IntuneBooksIosvppebookassignmentDeleteParameter();
            return await this.SendAsync<IntuneBooksIosvppebookassignmentDeleteParameter, IntuneBooksIosvppebookassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentDeleteResponse> IntuneBooksIosvppebookassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksIosvppebookassignmentDeleteParameter();
            return await this.SendAsync<IntuneBooksIosvppebookassignmentDeleteParameter, IntuneBooksIosvppebookassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentDeleteResponse> IntuneBooksIosvppebookassignmentDeleteAsync(IntuneBooksIosvppebookassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneBooksIosvppebookassignmentDeleteParameter, IntuneBooksIosvppebookassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebookassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookassignmentDeleteResponse> IntuneBooksIosvppebookassignmentDeleteAsync(IntuneBooksIosvppebookassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksIosvppebookassignmentDeleteParameter, IntuneBooksIosvppebookassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
