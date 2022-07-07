using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CalendargroupGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class CalendargroupGetResponse : RestApiResponse
    {
        public string? Name { get; set; }
        public string? ChangeKey { get; set; }
        public Guid? ClassId { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendargroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendargroupGetResponse> CalendargroupGetAsync()
        {
            var p = new CalendargroupGetParameter();
            return await this.SendAsync<CalendargroupGetParameter, CalendargroupGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendargroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendargroupGetResponse> CalendargroupGetAsync(CancellationToken cancellationToken)
        {
            var p = new CalendargroupGetParameter();
            return await this.SendAsync<CalendargroupGetParameter, CalendargroupGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendargroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendargroupGetResponse> CalendargroupGetAsync(CalendargroupGetParameter parameter)
        {
            return await this.SendAsync<CalendargroupGetParameter, CalendargroupGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendargroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendargroupGetResponse> CalendargroupGetAsync(CalendargroupGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendargroupGetParameter, CalendargroupGetResponse>(parameter, cancellationToken);
        }
    }
}
