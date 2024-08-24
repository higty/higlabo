using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworktagMemberListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? TeamworkTagId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Tags_TeamworkTagId_Members: return $"/teams/{TeamId}/tags/{TeamworkTagId}/members";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Tags_TeamworkTagId_Members,
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
    public partial class TeamworktagMemberListResponse : RestApiResponse<TeamworkTagMember>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagMemberListResponse> TeamworktagMemberListAsync()
        {
            var p = new TeamworktagMemberListParameter();
            return await this.SendAsync<TeamworktagMemberListParameter, TeamworktagMemberListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagMemberListResponse> TeamworktagMemberListAsync(CancellationToken cancellationToken)
        {
            var p = new TeamworktagMemberListParameter();
            return await this.SendAsync<TeamworktagMemberListParameter, TeamworktagMemberListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagMemberListResponse> TeamworktagMemberListAsync(TeamworktagMemberListParameter parameter)
        {
            return await this.SendAsync<TeamworktagMemberListParameter, TeamworktagMemberListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagMemberListResponse> TeamworktagMemberListAsync(TeamworktagMemberListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamworktagMemberListParameter, TeamworktagMemberListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<TeamworkTagMember> TeamworktagMemberListEnumerateAsync(TeamworktagMemberListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<TeamworktagMemberListParameter, TeamworktagMemberListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<TeamworkTagMember>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
