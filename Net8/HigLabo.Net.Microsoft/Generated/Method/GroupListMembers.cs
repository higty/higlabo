using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-members?view=graph-rest-1.0
    /// </summary>
    public partial class GroupListMembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Members: return $"/groups/{Id}/members";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_Members,
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
    public partial class GroupListMembersResponse : RestApiResponse<DirectoryObject>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-members?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListMembersResponse> GroupListMembersAsync()
        {
            var p = new GroupListMembersParameter();
            return await this.SendAsync<GroupListMembersParameter, GroupListMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListMembersResponse> GroupListMembersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListMembersParameter();
            return await this.SendAsync<GroupListMembersParameter, GroupListMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListMembersResponse> GroupListMembersAsync(GroupListMembersParameter parameter)
        {
            return await this.SendAsync<GroupListMembersParameter, GroupListMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListMembersResponse> GroupListMembersAsync(GroupListMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListMembersParameter, GroupListMembersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-members?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryObject> GroupListMembersEnumerateAsync(GroupListMembersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<GroupListMembersParameter, GroupListMembersResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
