using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryDeleteditemsRestoreParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Directory_DeletedItems_Id_Restore,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_DeletedItems_Id_Restore: return $"/directory/deletedItems/{Id}/restore";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class DirectoryDeleteditemsRestoreResponse : RestApiResponse
    {
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsRestoreResponse> DirectoryDeleteditemsRestoreAsync()
        {
            var p = new DirectoryDeleteditemsRestoreParameter();
            return await this.SendAsync<DirectoryDeleteditemsRestoreParameter, DirectoryDeleteditemsRestoreResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsRestoreResponse> DirectoryDeleteditemsRestoreAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryDeleteditemsRestoreParameter();
            return await this.SendAsync<DirectoryDeleteditemsRestoreParameter, DirectoryDeleteditemsRestoreResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsRestoreResponse> DirectoryDeleteditemsRestoreAsync(DirectoryDeleteditemsRestoreParameter parameter)
        {
            return await this.SendAsync<DirectoryDeleteditemsRestoreParameter, DirectoryDeleteditemsRestoreResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsRestoreResponse> DirectoryDeleteditemsRestoreAsync(DirectoryDeleteditemsRestoreParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryDeleteditemsRestoreParameter, DirectoryDeleteditemsRestoreResponse>(parameter, cancellationToken);
        }
    }
}
