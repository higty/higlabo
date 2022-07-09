using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/rangeborder?view=graph-rest-1.0
    /// </summary>
    public partial class RangeBorder
    {
        public enum RangeBorderstring
        {
            EdgeTop,
            EdgeBottom,
            EdgeLeft,
            EdgeRight,
            InsideVertical,
            InsideHorizontal,
            DiagonalDown,
            DiagonalUp,
        }

        public string? Color { get; set; }
        public RangeBorderstring Id { get; set; }
        public RangeBorderstring SideIndex { get; set; }
        public RangeBorderstring Style { get; set; }
        public RangeBorderstring Weight { get; set; }
    }
}
