using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/titlearea?view=graph-rest-1.0
    /// </summary>
    public partial class TitleArea
    {
        public enum TitleAreaTitleAreaLayoutType
        {
            ImageAndTitle,
            Plain,
            ColorBlock,
            Overlap,
            UnknownFutureValue,
        }
        public enum TitleAreaTitleAreaTextAlignmentType
        {
            Left,
            Center,
            UnknownFutureValue,
        }

        public string? AlternativeText { get; set; }
        public bool? EnableGradientEffect { get; set; }
        public string? ImageWebUrl { get; set; }
        public TitleArea? Layout { get; set; }
        public ServerProcessedContent? ServerProcessedContent { get; set; }
        public bool? ShowAuthor { get; set; }
        public bool? ShowPublishedDate { get; set; }
        public bool? ShowTextBlockAboveTitle { get; set; }
        public string? TextAboveTitle { get; set; }
        public TitleAreaTitleAreaTextAlignmentType TextAlignment { get; set; }
    }
}
