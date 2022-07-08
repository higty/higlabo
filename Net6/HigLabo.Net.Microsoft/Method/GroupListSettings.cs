using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListSettingsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string GroupId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.GroupSettings: return $"/groupSettings";
                    case ApiPath.Groups_GroupId_Settings: return $"/groups/{GroupId}/settings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
            TemplateId,
            Values,
        }
        public enum ApiPath
        {
            GroupSettings,
            Groups_GroupId_Settings,
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
    public partial class GroupListSettingsResponse : RestApiResponse
    {
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
