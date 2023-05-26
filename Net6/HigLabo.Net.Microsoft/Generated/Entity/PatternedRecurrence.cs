using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/patternedrecurrence?view=graph-rest-1.0
    /// </summary>
    public partial class PatternedRecurrence
    {
        public RecurrencePattern? Pattern { get; set; }
        public RecurrenceRange? Range { get; set; }
    }
}
