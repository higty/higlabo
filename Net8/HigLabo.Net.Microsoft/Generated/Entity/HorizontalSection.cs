using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/horizontalsection?view=graph-rest-1.0
    /// </summary>
    public partial class HorizontalSection
    {
        public enum HorizontalSectionSectionEmphasisType
        {
            None,
            Netural,
            Soft,
            Strong,
            UnknownFutureValue,
        }
        public enum HorizontalSectionHorizontalSectionLayoutType
        {
            None,
            OneColumn,
            TwoColumns,
            ThreeColumns,
            OneThirdLeftColumn,
            OneThirdRightColumn,
            FullWidth,
            UnknownFutureValue,
        }

        public HorizontalSection? Emphasis { get; set; }
        public string? Id { get; set; }
        public HorizontalSectionHorizontalSectionLayoutType Layout { get; set; }
        public HorizontalSectionColumn[]? Columns { get; set; }
    }
}
