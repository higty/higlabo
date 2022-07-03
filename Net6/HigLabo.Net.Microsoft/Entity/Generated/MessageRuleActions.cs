using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/messageruleactions?view=graph-rest-1.0
    /// </summary>
    public partial class MessageRuleActions
    {
        public String[] AssignCategories { get; set; }
        public string CopyToFolder { get; set; }
        public bool Delete { get; set; }
        public Recipient[] ForwardAsAttachmentTo { get; set; }
        public Recipient[] ForwardTo { get; set; }
        public bool MarkAsRead { get; set; }
        public MessageRuleActionsImportance MarkImportance { get; set; }
        public string MoveToFolder { get; set; }
        public bool PermanentDelete { get; set; }
        public Recipient[] RedirectTo { get; set; }
        public bool StopProcessingRules { get; set; }
    }
}
