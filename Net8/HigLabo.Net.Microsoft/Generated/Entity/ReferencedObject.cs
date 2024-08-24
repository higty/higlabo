using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-referencedobject?view=graph-rest-1.0
    /// </summary>
    public partial class ReferencedObject
    {
        public string? ReferencedObjectName { get; set; }
        public string? ReferencedProperty { get; set; }
    }
}
