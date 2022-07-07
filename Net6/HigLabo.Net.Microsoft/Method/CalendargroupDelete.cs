using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CalendargroupDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_CalendarGroups_Id,
            Users_IdOrUserPrincipalName_CalendarGroups_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_CalendarGroups_Id: return $"/me/calendarGroups/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id: return $"/users/{IdOrUserPrincipalName}/calendarGroups/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class CalendargroupDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendargroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendargroupDeleteResponse> CalendargroupDeleteAsync()
        {
            var p = new CalendargroupDeleteParameter();
            return await this.SendAsync<CalendargroupDeleteParameter, CalendargroupDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendargroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendargroupDeleteResponse> CalendargroupDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new CalendargroupDeleteParameter();
            return await this.SendAsync<CalendargroupDeleteParameter, CalendargroupDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendargroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendargroupDeleteResponse> CalendargroupDeleteAsync(CalendargroupDeleteParameter parameter)
        {
            return await this.SendAsync<CalendargroupDeleteParameter, CalendargroupDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendargroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendargroupDeleteResponse> CalendargroupDeleteAsync(CalendargroupDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendargroupDeleteParameter, CalendargroupDeleteResponse>(parameter, cancellationToken);
        }
    }
}
