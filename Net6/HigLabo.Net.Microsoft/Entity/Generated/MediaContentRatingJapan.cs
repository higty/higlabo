using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingjapan?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingJapan
    {
        public enum MediaContentRatingJapanRatingJapanMoviesType
        {
            AllAllowed,
            AllBlocked,
            General,
            ParentalGuidance,
            AgesAbove15,
            AgesAbove18,
        }
        public enum MediaContentRatingJapanRatingJapanTelevisionType
        {
            AllAllowed,
            AllBlocked,
            ExplicitAllowed,
        }

        public RatingJapanMoviesType? MovieRating { get; set; }
        public RatingJapanTelevisionType? TvRating { get; set; }
    }
}
