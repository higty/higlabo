using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupResetunseencountParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_ResetUnseenCount,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_ResetUnseenCount: return $"/groups/{Id}/resetUnseenCount";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class GroupResetunseencountResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-resetunseencount?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupResetunseencountResponse> GroupResetunseencountAsync()
        {
            var p = new GroupResetunseencountParameter();
            return await this.SendAsync<GroupResetunseencountParameter, GroupResetunseencountResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-resetunseencount?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupResetunseencountResponse> GroupResetunseencountAsync(CancellationToken cancellationToken)
        {
            var p = new GroupResetunseencountParameter();
            return await this.SendAsync<GroupResetunseencountParameter, GroupResetunseencountResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-resetunseencount?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupResetunseencountResponse> GroupResetunseencountAsync(GroupResetunseencountParameter parameter)
        {
            return await this.SendAsync<GroupResetunseencountParameter, GroupResetunseencountResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-resetunseencount?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupResetunseencountResponse> GroupResetunseencountAsync(GroupResetunseencountParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupResetunseencountParameter, GroupResetunseencountResponse>(parameter, cancellationToken);
        }
    }
}
