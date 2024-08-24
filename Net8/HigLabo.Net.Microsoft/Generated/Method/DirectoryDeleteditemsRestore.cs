using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryDeletedItemsReStoreParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_DeletedItems_Id_Restore: return $"/directory/deletedItems/{Id}/restore";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Directory_DeletedItems_Id_Restore,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    public partial class DirectoryDeletedItemsReStoreResponse : RestApiResponse
    {
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryDeletedItemsReStoreResponse> DirectoryDeletedItemsReStoreAsync()
        {
            var p = new DirectoryDeletedItemsReStoreParameter();
            return await this.SendAsync<DirectoryDeletedItemsReStoreParameter, DirectoryDeletedItemsReStoreResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryDeletedItemsReStoreResponse> DirectoryDeletedItemsReStoreAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryDeletedItemsReStoreParameter();
            return await this.SendAsync<DirectoryDeletedItemsReStoreParameter, DirectoryDeletedItemsReStoreResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryDeletedItemsReStoreResponse> DirectoryDeletedItemsReStoreAsync(DirectoryDeletedItemsReStoreParameter parameter)
        {
            return await this.SendAsync<DirectoryDeletedItemsReStoreParameter, DirectoryDeletedItemsReStoreResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryDeletedItemsReStoreResponse> DirectoryDeletedItemsReStoreAsync(DirectoryDeletedItemsReStoreParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryDeletedItemsReStoreParameter, DirectoryDeletedItemsReStoreResponse>(parameter, cancellationToken);
        }
    }
}
