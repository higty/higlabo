using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timesoff?view=graph-rest-1.0
    /// </summary>
    public partial class ScheduleListTimesoffParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimesOff: return $"/teams/{TeamId}/schedule/timesOff";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimesOff,
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
    public partial class ScheduleListTimesoffResponse : RestApiResponse<TimeOff>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timesoff?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timesoff?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ScheduleListTimesoffResponse> ScheduleListTimesoffAsync()
        {
            var p = new ScheduleListTimesoffParameter();
            return await this.SendAsync<ScheduleListTimesoffParameter, ScheduleListTimesoffResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timesoff?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ScheduleListTimesoffResponse> ScheduleListTimesoffAsync(CancellationToken cancellationToken)
        {
            var p = new ScheduleListTimesoffParameter();
            return await this.SendAsync<ScheduleListTimesoffParameter, ScheduleListTimesoffResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timesoff?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ScheduleListTimesoffResponse> ScheduleListTimesoffAsync(ScheduleListTimesoffParameter parameter)
        {
            return await this.SendAsync<ScheduleListTimesoffParameter, ScheduleListTimesoffResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timesoff?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ScheduleListTimesoffResponse> ScheduleListTimesoffAsync(ScheduleListTimesoffParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ScheduleListTimesoffParameter, ScheduleListTimesoffResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timesoff?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<TimeOff> ScheduleListTimesoffEnumerateAsync(ScheduleListTimesoffParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ScheduleListTimesoffParameter, ScheduleListTimesoffResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<TimeOff>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
