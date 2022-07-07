using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesUserListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Users,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users: return $"/users";
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
    }
    public partial class IntuneDevicesUserListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-user?view=graph-rest-1.0
        /// </summary>
        public partial class User
        {
            public string? Id { get; set; }
        }

        public User[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserListResponse> IntuneDevicesUserListAsync()
        {
            var p = new IntuneDevicesUserListParameter();
            return await this.SendAsync<IntuneDevicesUserListParameter, IntuneDevicesUserListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserListResponse> IntuneDevicesUserListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesUserListParameter();
            return await this.SendAsync<IntuneDevicesUserListParameter, IntuneDevicesUserListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserListResponse> IntuneDevicesUserListAsync(IntuneDevicesUserListParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesUserListParameter, IntuneDevicesUserListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserListResponse> IntuneDevicesUserListAsync(IntuneDevicesUserListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesUserListParameter, IntuneDevicesUserListResponse>(parameter, cancellationToken);
        }
    }
}
