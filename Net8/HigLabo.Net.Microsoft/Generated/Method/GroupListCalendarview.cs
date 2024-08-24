using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public partial class GroupListCalendarviewParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_CalendarView: return $"/groups/{Id}/calendarView";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_CalendarView,
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
    public partial class GroupListCalendarviewResponse : RestApiResponse<Event>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListCalendarviewResponse> GroupListCalendarviewAsync()
        {
            var p = new GroupListCalendarviewParameter();
            return await this.SendAsync<GroupListCalendarviewParameter, GroupListCalendarviewResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListCalendarviewResponse> GroupListCalendarviewAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListCalendarviewParameter();
            return await this.SendAsync<GroupListCalendarviewParameter, GroupListCalendarviewResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListCalendarviewResponse> GroupListCalendarviewAsync(GroupListCalendarviewParameter parameter)
        {
            return await this.SendAsync<GroupListCalendarviewParameter, GroupListCalendarviewResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListCalendarviewResponse> GroupListCalendarviewAsync(GroupListCalendarviewParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListCalendarviewParameter, GroupListCalendarviewResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Event> GroupListCalendarviewEnumerateAsync(GroupListCalendarviewParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<GroupListCalendarviewParameter, GroupListCalendarviewResponse>(parameter, cancellationToken);
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
