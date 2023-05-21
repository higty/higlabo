using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/onpremisesaccidentaldeletionprevention?view=graph-rest-1.0
    /// </summary>
    public partial class OnPremisesAccidentalDeletionPrevention
    {
        public enum OnPremisesAccidentalDeletionPreventionOnPremisesDirectorySynchronizationDeletionPreventionType
        {
            Disabled,
            EnabledForCount,
            EnabledForPercentage,
            UnknownFutureValue,
        }

        public Int32? AlertThreshold { get; set; }
        public OnPremisesAccidentalDeletionPreventionOnPremisesDirectorySynchronizationDeletionPreventionType SynchronizationPreventionType { get; set; }
    }
}
