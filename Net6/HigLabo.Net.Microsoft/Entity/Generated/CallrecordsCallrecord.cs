using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-callrecord?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsCallrecord
    {
        public DateTimeOffset EndDateTime { get; set; }
        public string Id { get; set; }
        public string JoinWebUrl { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public CallrecordsCallrecordModality Modalities { get; set; }
        public IdentitySet? Organizer { get; set; }
        public IdentitySet[] Participants { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public CallrecordsCallrecordCallType Type { get; set; }
        public Int64? Version { get; set; }
    }
}
