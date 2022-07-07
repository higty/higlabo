using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupsettingtemplateListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            GroupSettingTemplates,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.GroupSettingTemplates: return $"/groupSettingTemplates";
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
    }
    public partial class GroupsettingtemplateListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/groupsettingtemplate?view=graph-rest-1.0
        /// </summary>
        public partial class GroupSettingTemplate
        {
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public SettingTemplateValue[]? Values { get; set; }
        }

        public GroupSettingTemplate[] Value { get; set; }
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
