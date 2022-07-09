using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupsettingtemplateListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.GroupSettingTemplates: return $"/groupSettingTemplates";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Description,
            DisplayName,
            Id,
            Values,
        }
        public enum ApiPath
        {
            GroupSettingTemplates,
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
    public partial class GroupsettingtemplateListResponse : RestApiResponse
    {
        public GroupSettingTemplate[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsettingtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingtemplateListResponse> GroupsettingtemplateListAsync()
        {
            var p = new GroupsettingtemplateListParameter();
            return await this.SendAsync<GroupsettingtemplateListParameter, GroupsettingtemplateListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsettingtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingtemplateListResponse> GroupsettingtemplateListAsync(CancellationToken cancellationToken)
        {
            var p = new GroupsettingtemplateListParameter();
            return await this.SendAsync<GroupsettingtemplateListParameter, GroupsettingtemplateListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsettingtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingtemplateListResponse> GroupsettingtemplateListAsync(GroupsettingtemplateListParameter parameter)
        {
            return await this.SendAsync<GroupsettingtemplateListParameter, GroupsettingtemplateListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsettingtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingtemplateListResponse> GroupsettingtemplateListAsync(GroupsettingtemplateListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupsettingtemplateListParameter, GroupsettingtemplateListResponse>(parameter, cancellationToken);
        }
    }
}
