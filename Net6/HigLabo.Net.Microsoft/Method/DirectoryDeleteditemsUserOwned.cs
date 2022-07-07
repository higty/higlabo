using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryDeleteditemsUserOwnedParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Directory_DeletedItems_GetUserOwnedObjects,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_DeletedItems_GetUserOwnedObjects: return $"/directory/deletedItems/getUserOwnedObjects";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? UserId { get; set; }
        public string? Type { get; set; }
    }
    public partial class DirectoryDeleteditemsUserOwnedResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-user-owned?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsUserOwnedResponse> DirectoryDeleteditemsUserOwnedAsync()
        {
            var p = new DirectoryDeleteditemsUserOwnedParameter();
            return await this.SendAsync<DirectoryDeleteditemsUserOwnedParameter, DirectoryDeleteditemsUserOwnedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-user-owned?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsUserOwnedResponse> DirectoryDeleteditemsUserOwnedAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryDeleteditemsUserOwnedParameter();
            return await this.SendAsync<DirectoryDeleteditemsUserOwnedParameter, DirectoryDeleteditemsUserOwnedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-user-owned?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsUserOwnedResponse> DirectoryDeleteditemsUserOwnedAsync(DirectoryDeleteditemsUserOwnedParameter parameter)
        {
            return await this.SendAsync<DirectoryDeleteditemsUserOwnedParameter, DirectoryDeleteditemsUserOwnedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-user-owned?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsUserOwnedResponse> DirectoryDeleteditemsUserOwnedAsync(DirectoryDeleteditemsUserOwnedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryDeleteditemsUserOwnedParameter, DirectoryDeleteditemsUserOwnedResponse>(parameter, cancellationToken);
        }
    }
}
