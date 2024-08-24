using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-events?view=graph-rest-1.0
    /// </summary>
    public partial class GroupListEventsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Events: return $"/groups/{Id}/events";
                    case ApiPath.Groups_Id_Calendar_Events: return $"/groups/{Id}/calendar/events";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_Events,
            Groups_Id_Calendar_Events,
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
    public partial class GroupListEventsResponse : RestApiResponse<Event>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-events?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-events?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListEventsResponse> GroupListEventsAsync()
        {
            var p = new GroupListEventsParameter();
            return await this.SendAsync<GroupListEventsParameter, GroupListEventsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-events?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListEventsResponse> GroupListEventsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListEventsParameter();
            return await this.SendAsync<GroupListEventsParameter, GroupListEventsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-events?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListEventsResponse> GroupListEventsAsync(GroupListEventsParameter parameter)
        {
            return await this.SendAsync<GroupListEventsParameter, GroupListEventsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-events?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListEventsResponse> GroupListEventsAsync(GroupListEventsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListEventsParameter, GroupListEventsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-events?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Event> GroupListEventsEnumerateAsync(GroupListEventsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<GroupListEventsParameter, GroupListEventsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Event>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
