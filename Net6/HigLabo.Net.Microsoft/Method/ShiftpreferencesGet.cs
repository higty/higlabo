using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ShiftpreferencesGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_UserId_Settings_ShiftPreferences,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UserId_Settings_ShiftPreferences: return $"/users/{UserId}/settings/shiftPreferences";
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
        public string UserId { get; set; }
    }
    public partial class ShiftpreferencesGetResponse : RestApiResponse
    {
        public String? Id { get; set; }
        public ShiftAvailability[]? Availability { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/shiftpreferences-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ShiftpreferencesGetResponse> ShiftpreferencesGetAsync()
        {
            var p = new ShiftpreferencesGetParameter();
            return await this.SendAsync<ShiftpreferencesGetParameter, ShiftpreferencesGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/shiftpreferences-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ShiftpreferencesGetResponse> ShiftpreferencesGetAsync(CancellationToken cancellationToken)
        {
            var p = new ShiftpreferencesGetParameter();
            return await this.SendAsync<ShiftpreferencesGetParameter, ShiftpreferencesGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/shiftpreferences-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ShiftpreferencesGetResponse> ShiftpreferencesGetAsync(ShiftpreferencesGetParameter parameter)
        {
            return await this.SendAsync<ShiftpreferencesGetParameter, ShiftpreferencesGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/shiftpreferences-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ShiftpreferencesGetResponse> ShiftpreferencesGetAsync(ShiftpreferencesGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ShiftpreferencesGetParameter, ShiftpreferencesGetResponse>(parameter, cancellationToken);
        }
    }
}
