using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListSettingsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            GroupSettings,
            Groups_GroupId_Settings,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.GroupSettings: return $"/groupSettings";
                    case ApiPath.Groups_GroupId_Settings: return $"/groups/{GroupId}/settings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string GroupId { get; set; }
    }
    public partial class GroupListSettingsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/groupsetting?view=graph-rest-1.0
        /// </summary>
        public partial class GroupSetting
        {
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public string? TemplateId { get; set; }
            public SettingValue[]? Values { get; set; }
        }

        public GroupSetting[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListSettingsResponse> GroupListSettingsAsync()
        {
            var p = new GroupListSettingsParameter();
            return await this.SendAsync<GroupListSettingsParameter, GroupListSettingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListSettingsResponse> GroupListSettingsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListSettingsParameter();
            return await this.SendAsync<GroupListSettingsParameter, GroupListSettingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListSettingsResponse> GroupListSettingsAsync(GroupListSettingsParameter parameter)
        {
            return await this.SendAsync<GroupListSettingsParameter, GroupListSettingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListSettingsResponse> GroupListSettingsAsync(GroupListSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListSettingsParameter, GroupListSettingsResponse>(parameter, cancellationToken);
        }
    }
}
