using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingfrance?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingFrance
    {
        public enum MediaContentRatingFranceRatingFranceMoviesType
        {
            AllAllowed,
            AllBlocked,
            AgesAbove10,
            AgesAbove12,
            AgesAbove16,
            AgesAbove18,
        }
        public enum MediaContentRatingFranceRatingFranceTelevisionType
        {
            AllAllowed,
            AllBlocked,
            AgesAbove10,
            AgesAbove12,
            AgesAbove16,
            AgesAbove18,
        }

        public RatingFranceMoviesType? MovieRating { get; set; }
        public RatingFranceTelevisionType? TvRating { get; set; }
    }
}
