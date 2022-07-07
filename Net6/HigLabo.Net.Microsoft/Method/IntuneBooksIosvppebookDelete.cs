using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksIosvppebookDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_ManagedEBooks_ManagedEBookId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedEBooks_ManagedEBookId: return $"/deviceAppManagement/managedEBooks/{ManagedEBookId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ManagedEBookId { get; set; }
    }
    public partial class IntuneBooksIosvppebookDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebook-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookDeleteResponse> IntuneBooksIosvppebookDeleteAsync()
        {
            var p = new IntuneBooksIosvppebookDeleteParameter();
            return await this.SendAsync<IntuneBooksIosvppebookDeleteParameter, IntuneBooksIosvppebookDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebook-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookDeleteResponse> IntuneBooksIosvppebookDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksIosvppebookDeleteParameter();
            return await this.SendAsync<IntuneBooksIosvppebookDeleteParameter, IntuneBooksIosvppebookDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebook-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookDeleteResponse> IntuneBooksIosvppebookDeleteAsync(IntuneBooksIosvppebookDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneBooksIosvppebookDeleteParameter, IntuneBooksIosvppebookDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-iosvppebook-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksIosvppebookDeleteResponse> IntuneBooksIosvppebookDeleteAsync(IntuneBooksIosvppebookDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksIosvppebookDeleteParameter, IntuneBooksIosvppebookDeleteResponse>(parameter, cancellationToken);
        }
    }
}
