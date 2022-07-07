using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupsettingtemplateGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            GroupSettingTemplates_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.GroupSettingTemplates_Id: return $"/groupSettingTemplates/{Id}";
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
        public string Id { get; set; }
    }
    public partial class GroupsettingtemplateGetResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public SettingTemplateValue[]? Values { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsettingtemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingtemplateGetResponse> GroupsettingtemplateGetAsync()
        {
            var p = new GroupsettingtemplateGetParameter();
            return await this.SendAsync<GroupsettingtemplateGetParameter, GroupsettingtemplateGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsettingtemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingtemplateGetResponse> GroupsettingtemplateGetAsync(CancellationToken cancellationToken)
        {
            var p = new GroupsettingtemplateGetParameter();
            return await this.SendAsync<GroupsettingtemplateGetParameter, GroupsettingtemplateGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsettingtemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingtemplateGetResponse> GroupsettingtemplateGetAsync(GroupsettingtemplateGetParameter parameter)
        {
            return await this.SendAsync<GroupsettingtemplateGetParameter, GroupsettingtemplateGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsettingtemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingtemplateGetResponse> GroupsettingtemplateGetAsync(GroupsettingtemplateGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupsettingtemplateGetParameter, GroupsettingtemplateGetResponse>(parameter, cancellationToken);
        }
    }
}
