using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/bitlockerrecoverykey?view=graph-rest-1.0
    /// </summary>
    public partial class BitlockerRecoveryKey
    {
        public enum BitlockerRecoveryKeyVolumeType
        {
            OperatingSystemVolume,
            FixedDataVolume,
            RemovableDataVolume,
            UnknownFutureValue,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DeviceId { get; set; }
        public string? Id { get; set; }
        public string? Key { get; set; }
        public BitlockerRecoveryKeyVolumeType VolumeType { get; set; }
    }
}
