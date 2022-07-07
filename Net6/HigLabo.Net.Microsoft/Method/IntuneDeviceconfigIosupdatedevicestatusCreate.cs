using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIosupdatedevicestatusCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigIosupdatedevicestatusCreateParameterIosUpdatesInstallStatus
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
        public enum IntuneDeviceconfigIosupdatedevicestatusCreateParameterComplianceStatus
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public IntuneDeviceconfigIosupdatedevicestatusCreateParameterIosUpdatesInstallStatus InstallStatus { get; set; }
        public string? OsVersion { get; set; }
        public string? DeviceId { get; set; }
        public string? UserId { get; set; }
        public string? DeviceDisplayName { get; set; }
        public string? UserName { get; set; }
        public string? DeviceModel { get; set; }
        public DateTimeOffset? ComplianceGracePeriodExpirationDateTime { get; set; }
        public IntuneDeviceconfigIosupdatedevicestatusCreateParameterComplianceStatus Status { get; set; }
        public DateTimeOffset? LastReportedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
    }
    public partial class IntuneDeviceconfigIosupdatedevicestatusCreateResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdatedevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdatedevicestatusCreateResponse> IntuneDeviceconfigIosupdatedevicestatusCreateAsync()
        {
            var p = new IntuneDeviceconfigIosupdatedevicestatusCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigIosupdatedevicestatusCreateParameter, IntuneDeviceconfigIosupdatedevicestatusCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdatedevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdatedevicestatusCreateResponse> IntuneDeviceconfigIosupdatedevicestatusCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIosupdatedevicestatusCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigIosupdatedevicestatusCreateParameter, IntuneDeviceconfigIosupdatedevicestatusCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdatedevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdatedevicestatusCreateResponse> IntuneDeviceconfigIosupdatedevicestatusCreateAsync(IntuneDeviceconfigIosupdatedevicestatusCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIosupdatedevicestatusCreateParameter, IntuneDeviceconfigIosupdatedevicestatusCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdatedevicestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdatedevicestatusCreateResponse> IntuneDeviceconfigIosupdatedevicestatusCreateAsync(IntuneDeviceconfigIosupdatedevicestatusCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIosupdatedevicestatusCreateParameter, IntuneDeviceconfigIosupdatedevicestatusCreateResponse>(parameter, cancellationToken);
        }
    }
}
