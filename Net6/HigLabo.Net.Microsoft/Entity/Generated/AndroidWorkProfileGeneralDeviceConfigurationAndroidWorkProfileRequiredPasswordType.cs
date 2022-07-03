
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-androidworkprofilegeneraldeviceconfiguration?view=graph-rest-1.0
    /// </summary>
    public enum AndroidWorkProfileGeneralDeviceConfigurationAndroidWorkProfileRequiredPasswordType
    {
        DeviceDefault,
        LowSecurityBiometric,
        Required,
        AtLeastNumeric,
        NumericComplex,
        AtLeastAlphabetic,
        AtLeastAlphanumeric,
        AlphanumericWithSymbols,
    }
}
