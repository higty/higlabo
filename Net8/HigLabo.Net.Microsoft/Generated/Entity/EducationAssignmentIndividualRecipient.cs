using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/educationassignmentindividualrecipient?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentIndividualRecipient
    {
        public String[]? Recipients { get; set; }
    }
}
