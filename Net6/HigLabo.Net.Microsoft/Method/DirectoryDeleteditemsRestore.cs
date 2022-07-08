using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryDeleteditemsReStoreParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

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
    public partial class DirectoryDeleteditemsReStoreResponse : RestApiResponse
    {
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsReStoreResponse> DirectoryDeleteditemsReStoreAsync()
        {
            var p = new DirectoryDeleteditemsReStoreParameter();
            return await this.SendAsync<DirectoryDeleteditemsReStoreParameter, DirectoryDeleteditemsReStoreResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsReStoreResponse> DirectoryDeleteditemsReStoreAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryDeleteditemsReStoreParameter();
            return await this.SendAsync<DirectoryDeleteditemsReStoreParameter, DirectoryDeleteditemsReStoreResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsReStoreResponse> DirectoryDeleteditemsReStoreAsync(DirectoryDeleteditemsReStoreParameter parameter)
        {
            return await this.SendAsync<DirectoryDeleteditemsReStoreParameter, DirectoryDeleteditemsReStoreResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-restore?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsReStoreResponse> DirectoryDeleteditemsReStoreAsync(DirectoryDeleteditemsReStoreParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryDeleteditemsReStoreParameter, DirectoryDeleteditemsReStoreResponse>(parameter, cancellationToken);
        }
    }
}
