using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingireland?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingIreland
    {
        public MediaContentRatingIrelandRatingIrelandMoviesType MovieRating { get; set; }
        public MediaContentRatingIrelandRatingIrelandTelevisionType TvRating { get; set; }
    }
}
