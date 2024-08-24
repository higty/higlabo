using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-settings?view=graph-rest-1.0
    /// </summary>
    public partial class GroupListSettingsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? GroupId { get; set; }

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
    public partial class GroupListSettingsResponse : RestApiResponse<GroupSetting>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-settings?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-settings?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListSettingsResponse> GroupListSettingsAsync()
        {
            var p = new GroupListSettingsParameter();
            return await this.SendAsync<GroupListSettingsParameter, GroupListSettingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-settings?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListSettingsResponse> GroupListSettingsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListSettingsParameter();
            return await this.SendAsync<GroupListSettingsParameter, GroupListSettingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-settings?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListSettingsResponse> GroupListSettingsAsync(GroupListSettingsParameter parameter)
        {
            return await this.SendAsync<GroupListSettingsParameter, GroupListSettingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-settings?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListSettingsResponse> GroupListSettingsAsync(GroupListSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListSettingsParameter, GroupListSettingsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-settings?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<GroupSetting> GroupListSettingsEnumerateAsync(GroupListSettingsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<GroupListSettingsParameter, GroupListSettingsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<GroupSetting>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
