using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationuserstatusGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_UserStatuses_DeviceConfigurationUserStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_UserStatuses_DeviceConfigurationUserStatusId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/userStatuses/{DeviceConfigurationUserStatusId}";
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
        public string DeviceConfigurationUserStatusId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationuserstatusGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusGetResponse> IntuneDeviceconfigDeviceconfigurationuserstatusGetAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationuserstatusGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusGetParameter, IntuneDeviceconfigDeviceconfigurationuserstatusGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusGetResponse> IntuneDeviceconfigDeviceconfigurationuserstatusGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationuserstatusGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusGetParameter, IntuneDeviceconfigDeviceconfigurationuserstatusGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusGetResponse> IntuneDeviceconfigDeviceconfigurationuserstatusGetAsync(IntuneDeviceconfigDeviceconfigurationuserstatusGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusGetParameter, IntuneDeviceconfigDeviceconfigurationuserstatusGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuserstatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuserstatusGetResponse> IntuneDeviceconfigDeviceconfigurationuserstatusGetAsync(IntuneDeviceconfigDeviceconfigurationuserstatusGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuserstatusGetParameter, IntuneDeviceconfigDeviceconfigurationuserstatusGetResponse>(parameter, cancellationToken);
        }
    }
}
