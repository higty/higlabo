using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-update?view=graph-rest-1.0
    /// </summary>
    public partial class CalendarGroupUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_CalendarGroups_Id: return $"/me/calendarGroups/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id: return $"/users/{IdOrUserPrincipalName}/calendarGroups/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_CalendarGroups_Id,
            Users_IdOrUserPrincipalName_CalendarGroups_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? Name { get; set; }
    }
    public partial class CalendarGroupUpdateResponse : RestApiResponse
    {
        public string? Name { get; set; }
        public string? ChangeKey { get; set; }
        public Guid? ClassId { get; set; }
        public string? Id { get; set; }
        public Calendar[]? Calendars { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendargroup-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarGroupUpdateResponse> CalendarGroupUpdateAsync()
        {
            var p = new CalendarGroupUpdateParameter();
            return await this.SendAsync<CalendarGroupUpdateParameter, CalendarGroupUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendargroup-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarGroupUpdateResponse> CalendarGroupUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new CalendarGroupUpdateParameter();
            return await this.SendAsync<CalendarGroupUpdateParameter, CalendarGroupUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendargroup-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarGroupUpdateResponse> CalendarGroupUpdateAsync(CalendarGroupUpdateParameter parameter)
        {
            return await this.SendAsync<CalendarGroupUpdateParameter, CalendarGroupUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendargroup-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarGroupUpdateResponse> CalendarGroupUpdateAsync(CalendarGroupUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendarGroupUpdateParameter, CalendarGroupUpdateResponse>(parameter, cancellationToken);
        }
    }
}
