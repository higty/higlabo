using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/textcolumn?view=graph-rest-1.0
    /// </summary>
    public partial class TextColumn
    {
        public Boolean? AllowMultipleLines { get; set; }
        public Boolean? AppendChangesToExistingText { get; set; }
        public Int32? LinesForEditing { get; set; }
        public Int32? MaxLength { get; set; }
        public String? TextType { get; set; }
    }
}
