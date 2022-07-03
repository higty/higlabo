using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/choicecolumn?view=graph-rest-1.0
    /// </summary>
    public partial class ChoiceColumn
    {
        public Boolean? AllowTextEntry { get; set; }
        public string[] Choices { get; set; }
        public String? DisplayAs { get; set; }
    }
}
