using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
    /// </summary>
    public partial class ScheduleListTimeoffReasonsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimeOffReasons: return $"/teams/{TeamId}/schedule/timeOffReasons";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimeOffReasons,
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
    public partial class ScheduleListTimeoffReasonsResponse : RestApiResponse<TimeOffReason>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ScheduleListTimeoffReasonsResponse> ScheduleListTimeoffReasonsAsync()
        {
            var p = new ScheduleListTimeoffReasonsParameter();
            return await this.SendAsync<ScheduleListTimeoffReasonsParameter, ScheduleListTimeoffReasonsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ScheduleListTimeoffReasonsResponse> ScheduleListTimeoffReasonsAsync(CancellationToken cancellationToken)
        {
            var p = new ScheduleListTimeoffReasonsParameter();
            return await this.SendAsync<ScheduleListTimeoffReasonsParameter, ScheduleListTimeoffReasonsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ScheduleListTimeoffReasonsResponse> ScheduleListTimeoffReasonsAsync(ScheduleListTimeoffReasonsParameter parameter)
        {
            return await this.SendAsync<ScheduleListTimeoffReasonsParameter, ScheduleListTimeoffReasonsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ScheduleListTimeoffReasonsResponse> ScheduleListTimeoffReasonsAsync(ScheduleListTimeoffReasonsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ScheduleListTimeoffReasonsParameter, ScheduleListTimeoffReasonsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<TimeOffReason> ScheduleListTimeoffReasonsEnumerateAsync(ScheduleListTimeoffReasonsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ScheduleListTimeoffReasonsParameter, ScheduleListTimeoffReasonsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<TimeOffReason>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
