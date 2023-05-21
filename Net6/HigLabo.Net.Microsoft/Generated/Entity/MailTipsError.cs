using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/mailtipserror?view=graph-rest-1.0
    /// </summary>
    public partial class MailTipsError
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
    }
}
