using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/learningprovider?view=graph-rest-1.0
    /// </summary>
    public partial class LearningProvider
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? LoginWebUrl { get; set; }
        public string? LongLogoWebUrlForDarkTheme { get; set; }
        public string? LongLogoWebUrlForLightTheme { get; set; }
        public string? SquareLogoWebUrlForDarkTheme { get; set; }
        public string? SquareLogoWebUrlForLightTheme { get; set; }
        public LearningContent[]? LearningContents { get; set; }
    }
}
