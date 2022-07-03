using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingjapan?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingJapan
    {
        public MediaContentRatingJapanRatingJapanMoviesType MovieRating { get; set; }
        public MediaContentRatingJapanRatingJapanTelevisionType TvRating { get; set; }
    }
}
