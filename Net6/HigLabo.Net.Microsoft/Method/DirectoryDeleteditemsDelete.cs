using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryDeleteditemsDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Directory_DeletedItems_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_DeletedItems_Id: return $"/directory/deletedItems/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class DirectoryDeleteditemsDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsDeleteResponse> DirectoryDeleteditemsDeleteAsync()
        {
            var p = new DirectoryDeleteditemsDeleteParameter();
            return await this.SendAsync<DirectoryDeleteditemsDeleteParameter, DirectoryDeleteditemsDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsDeleteResponse> DirectoryDeleteditemsDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryDeleteditemsDeleteParameter();
            return await this.SendAsync<DirectoryDeleteditemsDeleteParameter, DirectoryDeleteditemsDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsDeleteResponse> DirectoryDeleteditemsDeleteAsync(DirectoryDeleteditemsDeleteParameter parameter)
        {
            return await this.SendAsync<DirectoryDeleteditemsDeleteParameter, DirectoryDeleteditemsDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsDeleteResponse> DirectoryDeleteditemsDeleteAsync(DirectoryDeleteditemsDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryDeleteditemsDeleteParameter, DirectoryDeleteditemsDeleteResponse>(parameter, cancellationToken);
        }
    }
}
