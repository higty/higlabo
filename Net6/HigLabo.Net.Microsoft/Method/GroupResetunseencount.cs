using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-resetunseencount?view=graph-rest-1.0
    /// </summary>
    public partial class GroupResetunseencountParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_ResetUnseenCount: return $"/groups/{Id}/resetUnseenCount";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_ResetUnseenCount,
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
    }
    public partial class GroupResetunseencountResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-resetunseencount?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-resetunseencount?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupResetunseencountResponse> GroupResetunseencountAsync()
        {
            var p = new GroupResetunseencountParameter();
            return await this.SendAsync<GroupResetunseencountParameter, GroupResetunseencountResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-resetunseencount?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupResetunseencountResponse> GroupResetunseencountAsync(CancellationToken cancellationToken)
        {
            var p = new GroupResetunseencountParameter();
            return await this.SendAsync<GroupResetunseencountParameter, GroupResetunseencountResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-resetunseencount?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupResetunseencountResponse> GroupResetunseencountAsync(GroupResetunseencountParameter parameter)
        {
            return await this.SendAsync<GroupResetunseencountParameter, GroupResetunseencountResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-resetunseencount?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupResetunseencountResponse> GroupResetunseencountAsync(GroupResetunseencountParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupResetunseencountParameter, GroupResetunseencountResponse>(parameter, cancellationToken);
        }
    }
}
