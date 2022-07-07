using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroledefinitionDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            RoleManagement_Directory_RoleDefinitions_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleDefinitions_Id: return $"/roleManagement/directory/roleDefinitions/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class UnifiedroledefinitionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroledefinitionDeleteResponse> UnifiedroledefinitionDeleteAsync()
        {
            var p = new UnifiedroledefinitionDeleteParameter();
            return await this.SendAsync<UnifiedroledefinitionDeleteParameter, UnifiedroledefinitionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroledefinitionDeleteResponse> UnifiedroledefinitionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroledefinitionDeleteParameter();
            return await this.SendAsync<UnifiedroledefinitionDeleteParameter, UnifiedroledefinitionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroledefinitionDeleteResponse> UnifiedroledefinitionDeleteAsync(UnifiedroledefinitionDeleteParameter parameter)
        {
            return await this.SendAsync<UnifiedroledefinitionDeleteParameter, UnifiedroledefinitionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroledefinitionDeleteResponse> UnifiedroledefinitionDeleteAsync(UnifiedroledefinitionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroledefinitionDeleteParameter, UnifiedroledefinitionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
