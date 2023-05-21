using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageassignmentrequestorsettings?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignmentRequestorSettings
    {
        public bool? AllowCustomAssignmentSchedule { get; set; }
        public bool? EnableOnBehalfRequestorsToAddAccess { get; set; }
        public bool? EnableOnBehalfRequestorsToRemoveAccess { get; set; }
        public bool? EnableOnBehalfRequestorsToUpdateAccess { get; set; }
        public bool? EnableTargetsToSelfAddAccess { get; set; }
        public bool? EnableTargetsToSelfRemoveAccess { get; set; }
        public bool? EnableTargetsToSelfUpdateAccess { get; set; }
        public SubjectSet[]? OnBehalfRequestors { get; set; }
    }
}
