using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroledefinition-delete?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedroledefinitionDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleDefinitions_Id: return $"/roleManagement/directory/roleDefinitions/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            RoleManagement_Directory_RoleDefinitions_Id,
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
    public partial class UnifiedroledefinitionDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroledefinition-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroledefinitionDeleteResponse> UnifiedroledefinitionDeleteAsync()
        {
            var p = new UnifiedroledefinitionDeleteParameter();
            return await this.SendAsync<UnifiedroledefinitionDeleteParameter, UnifiedroledefinitionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroledefinitionDeleteResponse> UnifiedroledefinitionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroledefinitionDeleteParameter();
            return await this.SendAsync<UnifiedroledefinitionDeleteParameter, UnifiedroledefinitionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroledefinitionDeleteResponse> UnifiedroledefinitionDeleteAsync(UnifiedroledefinitionDeleteParameter parameter)
        {
            return await this.SendAsync<UnifiedroledefinitionDeleteParameter, UnifiedroledefinitionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroledefinitionDeleteResponse> UnifiedroledefinitionDeleteAsync(UnifiedroledefinitionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroledefinitionDeleteParameter, UnifiedroledefinitionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
