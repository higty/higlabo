using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationuserstatusListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_UserStatuses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_UserStatuses: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/userStatuses";
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
        public string DeviceConfigurationId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationuserstatusListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-deviceconfigurationuserstatus?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceConfigurationUserStatus
        {
            public enum DeviceConfigurationUserStatusComplianceStatus
            {
                Unknown,
                NotApplicable,
                Compliant,
                Remediated,
                NonCompliant,
                Error,
                Conflict,
                NotAssigned,
            }

            public string? Id { get; set; }
            public string? UserDisplayName { get; set; }
            public Int32? DevicesCount { get; set; }
            public ComplianceStatus? Status { get; set; }
            public DateTimeOffset? LastReportedDateTime { get; set; }
            public string? UserPrincipalName { get; set; }
        }

        public DeviceConfigurationUserStatus[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusListResponse> IntuneDeviceconfigDeviceconfigurationuserstatusListAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationuserstatusListParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusListParameter, IntuneDeviceconfigDeviceconfigurationuserstatusListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusListResponse> IntuneDeviceconfigDeviceconfigurationuserstatusListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationuserstatusListParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusListParameter, IntuneDeviceconfigDeviceconfigurationuserstatusListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusListResponse> IntuneDeviceconfigDeviceconfigurationuserstatusListAsync(IntuneDeviceconfigDeviceconfigurationuserstatusListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusListParameter, IntuneDeviceconfigDeviceconfigurationuserstatusListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusListResponse> IntuneDeviceconfigDeviceconfigurationuserstatusListAsync(IntuneDeviceconfigDeviceconfigurationuserstatusListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusListParameter, IntuneDeviceconfigDeviceconfigurationuserstatusListResponse>(parameter, cancellationToken);
        }
    }
}
