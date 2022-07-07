using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupPostSettingsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            GroupSettings,
            Groups_Id_Settings,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.GroupSettings: return $"/groupSettings";
                    case ApiPath.Groups_Id_Settings: return $"/groups/{Id}/settings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? TemplateId { get; set; }
        public SettingValue[]? Values { get; set; }
        public string Id { get; set; }
    }
    public partial class GroupPostSettingsResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? TemplateId { get; set; }
        public SettingValue[]? Values { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostSettingsResponse> GroupPostSettingsAsync()
        {
            var p = new GroupPostSettingsParameter();
            return await this.SendAsync<GroupPostSettingsParameter, GroupPostSettingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostSettingsResponse> GroupPostSettingsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupPostSettingsParameter();
            return await this.SendAsync<GroupPostSettingsParameter, GroupPostSettingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostSettingsResponse> GroupPostSettingsAsync(GroupPostSettingsParameter parameter)
        {
            return await this.SendAsync<GroupPostSettingsParameter, GroupPostSettingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostSettingsResponse> GroupPostSettingsAsync(GroupPostSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupPostSettingsParameter, GroupPostSettingsResponse>(parameter, cancellationToken);
        }
    }
}
