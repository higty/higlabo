using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-customtaskextensioncalloutdata?view=graph-rest-1.0
    /// </summary>
    public partial class CustomTaskExtensionCalloutData
    {
        public User? Subject { get; set; }
        public Task? Task { get; set; }
        public TaskProcessingResult? TaskProcessingResult { get; set; }
        public Workflow? Workflow { get; set; }
    }
}
