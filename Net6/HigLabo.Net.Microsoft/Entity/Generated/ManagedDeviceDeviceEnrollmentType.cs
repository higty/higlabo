
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-manageddevice?view=graph-rest-1.0
    /// </summary>
    public enum ManagedDeviceDeviceEnrollmentType
    {
        Unknown,
        UserEnrollment,
        DeviceEnrollmentManager,
        AppleBulkWithUser,
        AppleBulkWithoutUser,
        WindowsAzureADJoin,
        WindowsBulkUserless,
        WindowsAutoEnrollment,
        WindowsBulkAzureDomainJoin,
        WindowsCoManagement,
        WindowsAzureADJoinUsingDeviceAuth,
        AppleUserEnrollment,
        AppleUserEnrollmentWithServiceAccount,
    }
}
