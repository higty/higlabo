using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryDeleteditemsDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_DeletedItems_Id: return $"/directory/deletedItems/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Directory_DeletedItems_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class DirectoryDeleteditemsDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsDeleteResponse> DirectoryDeleteditemsDeleteAsync()
        {
            var p = new DirectoryDeleteditemsDeleteParameter();
            return await this.SendAsync<DirectoryDeleteditemsDeleteParameter, DirectoryDeleteditemsDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsDeleteResponse> DirectoryDeleteditemsDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryDeleteditemsDeleteParameter();
            return await this.SendAsync<DirectoryDeleteditemsDeleteParameter, DirectoryDeleteditemsDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsDeleteResponse> DirectoryDeleteditemsDeleteAsync(DirectoryDeleteditemsDeleteParameter parameter)
        {
            return await this.SendAsync<DirectoryDeleteditemsDeleteParameter, DirectoryDeleteditemsDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsDeleteResponse> DirectoryDeleteditemsDeleteAsync(DirectoryDeleteditemsDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryDeleteditemsDeleteParameter, DirectoryDeleteditemsDeleteResponse>(parameter, cancellationToken);
        }
    }
}
