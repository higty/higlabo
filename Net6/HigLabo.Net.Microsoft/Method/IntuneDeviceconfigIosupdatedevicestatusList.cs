using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIosupdatedevicestatusListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_IosUpdateStatuses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_IosUpdateStatuses: return $"/deviceManagement/iosUpdateStatuses";
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
    public partial class IntuneDeviceconfigIosupdatedevicestatusListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-iosupdatedevicestatus?view=graph-rest-1.0
        /// </summary>
        public partial class IosUpdateDeviceStatus
        {
            public enum IosUpdateDeviceStatusIosUpdatesInstallStatus
            {
                Success,
                Available,
                Idle,
                Unknown,
                Downloading,
                DownloadFailed,
                DownloadRequiresComputer,
                DownloadInsufficientSpace,
                DownloadInsufficientPower,
                DownloadInsufficientNetwork,
                Installing,
                InstallInsufficientSpace,
                InstallInsufficientPower,
                InstallPhoneCallInProgress,
                InstallFailed,
                NotSupportedOperation,
                SharedDeviceUserLoggedInError,
                DeviceOsHigherThanDesiredOsVersion,
            }
            public enum IosUpdateDeviceStatusComplianceStatus
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
            public IosUpdatesInstallStatus? InstallStatus { get; set; }
            public string? OsVersion { get; set; }
            public string? DeviceId { get; set; }
            public string? UserId { get; set; }
            public string? DeviceDisplayName { get; set; }
            public string? UserName { get; set; }
            public string? DeviceModel { get; set; }
            public DateTimeOffset? ComplianceGracePeriodExpirationDateTime { get; set; }
            public ComplianceStatus? Status { get; set; }
            public DateTimeOffset? LastReportedDateTime { get; set; }
            public string? UserPrincipalName { get; set; }
        }

        public IosUpdateDeviceStatus[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdatedevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdatedevicestatusListResponse> IntuneDeviceconfigIosupdatedevicestatusListAsync()
        {
            var p = new IntuneDeviceconfigIosupdatedevicestatusListParameter();
            return await this.SendAsync<IntuneDeviceconfigIosupdatedevicestatusListParameter, IntuneDeviceconfigIosupdatedevicestatusListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdatedevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdatedevicestatusListResponse> IntuneDeviceconfigIosupdatedevicestatusListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIosupdatedevicestatusListParameter();
            return await this.SendAsync<IntuneDeviceconfigIosupdatedevicestatusListParameter, IntuneDeviceconfigIosupdatedevicestatusListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdatedevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdatedevicestatusListResponse> IntuneDeviceconfigIosupdatedevicestatusListAsync(IntuneDeviceconfigIosupdatedevicestatusListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIosupdatedevicestatusListParameter, IntuneDeviceconfigIosupdatedevicestatusListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdatedevicestatus-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdatedevicestatusListResponse> IntuneDeviceconfigIosupdatedevicestatusListAsync(IntuneDeviceconfigIosupdatedevicestatusListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIosupdatedevicestatusListParameter, IntuneDeviceconfigIosupdatedevicestatusListResponse>(parameter, cancellationToken);
        }
    }
}
