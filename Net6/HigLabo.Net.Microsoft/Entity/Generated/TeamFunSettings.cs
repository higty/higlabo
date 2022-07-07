using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/teamfunsettings?view=graph-rest-1.0
    /// </summary>
    public partial class TeamFunSettings
    {
        public enum TeamFunSettingsGiphyContentRating
        {
            Moderate,
            Strict,
        }

        public bool? AllowGiphy { get; set; }
        public TeamFunSettingsGiphyContentRating GiphyContentRating { get; set; }
        public bool? AllowStickersAndMemes { get; set; }
        public bool? AllowCustomMemes { get; set; }
    }
}
