using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksManagedebookAssignParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_ManagedEBooks_ManagedEBookId_Assign,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedEBooks_ManagedEBookId_Assign: return $"/deviceAppManagement/managedEBooks/{ManagedEBookId}/assign";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public ManagedEBookAssignment[]? ManagedEBookAssignments { get; set; }
        public string ManagedEBookId { get; set; }
    }
    public partial class IntuneBooksManagedebookAssignResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebook-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookAssignResponse> IntuneBooksManagedebookAssignAsync()
        {
            var p = new IntuneBooksManagedebookAssignParameter();
            return await this.SendAsync<IntuneBooksManagedebookAssignParameter, IntuneBooksManagedebookAssignResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebook-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookAssignResponse> IntuneBooksManagedebookAssignAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksManagedebookAssignParameter();
            return await this.SendAsync<IntuneBooksManagedebookAssignParameter, IntuneBooksManagedebookAssignResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebook-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookAssignResponse> IntuneBooksManagedebookAssignAsync(IntuneBooksManagedebookAssignParameter parameter)
        {
            return await this.SendAsync<IntuneBooksManagedebookAssignParameter, IntuneBooksManagedebookAssignResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-managedebook-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksManagedebookAssignResponse> IntuneBooksManagedebookAssignAsync(IntuneBooksManagedebookAssignParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksManagedebookAssignParameter, IntuneBooksManagedebookAssignResponse>(parameter, cancellationToken);
        }
    }
}
