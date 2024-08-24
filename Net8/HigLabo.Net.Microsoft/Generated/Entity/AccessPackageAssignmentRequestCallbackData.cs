using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageassignmentrequestcallbackdata?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignmentRequestCallbackData
    {
        public enum AccessPackageAssignmentRequestCallbackDataAccessPackageCustomExtensionStage
        {
            AssignmentRequestCreated,
            AssignmentRequestApproved,
            AssignmentRequestGranted,
            AssignmentRequestRemoved,
            AssignmentFourteenDaysBeforeExpiration,
            AssignmentOneDayBeforeExpiration,
            UnknownFutureValue,
        }
        public enum AccessPackageAssignmentRequestCallbackDataAccessPackageRequestState
        {
            Denied,
            Canceled,
            AssignmentRequestCreated,
        }

        public string? CustomExtensionStageInstanceId { get; set; }
        public string? CustomExtensionStageInstanceDetail { get; set; }
        public AccessPackageAssignmentRequestCallbackDataAccessPackageCustomExtensionStage Stage { get; set; }
        public AccessPackageAssignmentRequestCallbackDataAccessPackageRequestState State { get; set; }
    }
}
