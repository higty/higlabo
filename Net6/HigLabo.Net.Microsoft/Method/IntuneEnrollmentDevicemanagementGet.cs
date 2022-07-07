using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneEnrollmentDevicemanagementGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement: return $"/deviceManagement";
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
    public partial class IntuneEnrollmentDevicemanagementGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentDevicemanagementGetResponse> IntuneEnrollmentDevicemanagementGetAsync()
        {
            var p = new IntuneEnrollmentDevicemanagementGetParameter();
            return await this.SendAsync<IntuneEnrollmentDevicemanagementGetParameter, IntuneEnrollmentDevicemanagementGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentDevicemanagementGetResponse> IntuneEnrollmentDevicemanagementGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneEnrollmentDevicemanagementGetParameter();
            return await this.SendAsync<IntuneEnrollmentDevicemanagementGetParameter, IntuneEnrollmentDevicemanagementGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentDevicemanagementGetResponse> IntuneEnrollmentDevicemanagementGetAsync(IntuneEnrollmentDevicemanagementGetParameter parameter)
        {
            return await this.SendAsync<IntuneEnrollmentDevicemanagementGetParameter, IntuneEnrollmentDevicemanagementGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentDevicemanagementGetResponse> IntuneEnrollmentDevicemanagementGetAsync(IntuneEnrollmentDevicemanagementGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneEnrollmentDevicemanagementGetParameter, IntuneEnrollmentDevicemanagementGetResponse>(parameter, cancellationToken);
        }
    }
}
