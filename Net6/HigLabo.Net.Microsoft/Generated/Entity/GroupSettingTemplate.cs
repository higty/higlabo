using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/groupsettingtemplate?view=graph-rest-1.0
    /// </summary>
    public partial class GroupSettingTemplate
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public SettingTemplateValue[]? Values { get; set; }
    }
}
