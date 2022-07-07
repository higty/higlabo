using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratinggermany?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingGermany
    {
        public enum MediaContentRatingGermanyRatingGermanyMoviesType
        {
            AllAllowed,
            AllBlocked,
            General,
            AgesAbove6,
            AgesAbove12,
            AgesAbove16,
            Adults,
        }
        public enum MediaContentRatingGermanyRatingGermanyTelevisionType
        {
            AllAllowed,
            AllBlocked,
            General,
            AgesAbove6,
            AgesAbove12,
            AgesAbove16,
            Adults,
        }

        public RatingGermanyMoviesType? MovieRating { get; set; }
        public RatingGermanyTelevisionType? TvRating { get; set; }
    }
}
