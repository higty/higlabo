using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcdeviceimage?view=graph-rest-1.0
/// </summary>
public partial class CloudPcDeviceImage
{
    public enum CloudPcDeviceImageCloudPcDeviceImageErrorCode
    {
        InternalServerError,
        SourceImageNotFound,
        OsVersionNotSupported,
        SourceImageInvalid,
        SourceImageNotGeneralized,
        UnknownFutureValue,
        VmAlreadyAzureAdJoined,
        PaidSourceImageNotSupport,
        SourceImageNotSupportCustomizeVMName,
        SourceImageSizeExceedsLimitation,
    }
    public enum CloudPcDeviceImageCloudPcDeviceImageOsStatus
    {
        Supported,
        SupportedWithWarning,
        Unknown,
        UnknownFutureValue,
    }
    public enum CloudPcDeviceImageCloudPcDeviceImageStatus
    {
        Pending,
        Ready,
        Failed,
        UnknownFutureValue,
    }

    public string? DisplayName { get; set; }
    public CloudPcDeviceImageCloudPcDeviceImageErrorCode ErrorCode { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? OperatingSystem { get; set; }
    public string? OsBuildNumber { get; set; }
    public CloudPcDeviceImageCloudPcDeviceImageOsStatus OsStatus { get; set; }
    public string? SourceImageResourceId { get; set; }
    public CloudPcDeviceImageCloudPcDeviceImageStatus Status { get; set; }
    public string? Version { get; set; }
}
