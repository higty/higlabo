using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsetting-get?view=graph-rest-1.0
    /// </summary>
    public partial class GroupsettingGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? GroupSettingId { get; set; }
            public string? GroupId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.GroupSettings_GroupSettingId: return $"/groupSettings/{GroupSettingId}";
                    case ApiPath.Groups_GroupId_Settings_GroupSettingId: return $"/groups/{GroupId}/settings/{GroupSettingId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            GroupSettings_GroupSettingId,
            Groups_GroupId_Settings_GroupSettingId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class GroupsettingGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? TemplateId { get; set; }
        public SettingValue[]? Values { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsetting-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/groupsetting-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingGetResponse> GroupsettingGetAsync()
        {
            var p = new GroupsettingGetParameter();
            return await this.SendAsync<GroupsettingGetParameter, GroupsettingGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/groupsetting-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingGetResponse> GroupsettingGetAsync(CancellationToken cancellationToken)
        {
            var p = new GroupsettingGetParameter();
            return await this.SendAsync<GroupsettingGetParameter, GroupsettingGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/groupsetting-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingGetResponse> GroupsettingGetAsync(GroupsettingGetParameter parameter)
        {
            return await this.SendAsync<GroupsettingGetParameter, GroupsettingGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/groupsetting-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingGetResponse> GroupsettingGetAsync(GroupsettingGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupsettingGetParameter, GroupsettingGetResponse>(parameter, cancellationToken);
        }
    }
}
