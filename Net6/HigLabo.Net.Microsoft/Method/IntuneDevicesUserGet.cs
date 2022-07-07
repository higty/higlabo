using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesUserGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_UsersId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId: return $"/users/{UsersId}";
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
        public string UsersId { get; set; }
    }
    public partial class IntuneDevicesUserGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserGetResponse> IntuneDevicesUserGetAsync()
        {
            var p = new IntuneDevicesUserGetParameter();
            return await this.SendAsync<IntuneDevicesUserGetParameter, IntuneDevicesUserGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserGetResponse> IntuneDevicesUserGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesUserGetParameter();
            return await this.SendAsync<IntuneDevicesUserGetParameter, IntuneDevicesUserGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserGetResponse> IntuneDevicesUserGetAsync(IntuneDevicesUserGetParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesUserGetParameter, IntuneDevicesUserGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserGetResponse> IntuneDevicesUserGetAsync(IntuneDevicesUserGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesUserGetParameter, IntuneDevicesUserGetResponse>(parameter, cancellationToken);
        }
    }
}
