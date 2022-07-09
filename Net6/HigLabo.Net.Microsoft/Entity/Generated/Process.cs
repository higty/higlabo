using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/process?view=graph-rest-1.0
    /// </summary>
    public partial class Process
    {
        public enum ProcessProcessIntegrityLevel
        {
            Unknown,
            Untrusted,
            Low,
            Medium,
            High,
            System,
        }

        public string? AccountName { get; set; }
        public string? CommandLine { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public FileHash? FileHash { get; set; }
        public ProcessProcessIntegrityLevel IntegrityLevel { get; set; }
        public bool? IsElevated { get; set; }
        public string? Name { get; set; }
        public DateTimeOffset? ParentProcessCreatedDateTime { get; set; }
        public Int32? ParentProcessId { get; set; }
        public string? ParentProcessName { get; set; }
        public string? Path { get; set; }
        public Int32? ProcessId { get; set; }
    }
}
