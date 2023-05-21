using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/chartfont?view=graph-rest-1.0
    /// </summary>
    public partial class ChartFont
    {
        public enum ChartFontstring
        {
            None,
            Single,
        }

        public bool? Bold { get; set; }
        public string? Color { get; set; }
        public bool? Italic { get; set; }
        public string? Name { get; set; }
        public Double? Size { get; set; }
        public ChartFontstring Underline { get; set; }
    }
}
