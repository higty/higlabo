using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/printmargin?view=graph-rest-1.0
    /// </summary>
    public partial class PrintMargin
    {
        public Int32? Bottom { get; set; }
        public Int32? Left { get; set; }
        public Int32? Right { get; set; }
        public Int32? Top { get; set; }
    }
}
