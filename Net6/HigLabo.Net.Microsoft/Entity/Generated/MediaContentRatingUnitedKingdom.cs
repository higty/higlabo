using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingunitedkingdom?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingUnitedKingdom
    {
        public enum MediaContentRatingUnitedKingdomRatingUnitedKingdomMoviesType
        {
            AllAllowed,
            AllBlocked,
            General,
            UniversalChildren,
            ParentalGuidance,
            AgesAbove12Video,
            AgesAbove12Cinema,
            AgesAbove15,
            Adults,
        }
        public enum MediaContentRatingUnitedKingdomRatingUnitedKingdomTelevisionType
        {
            AllAllowed,
            AllBlocked,
            Caution,
        }

        public RatingUnitedKingdomMoviesType? MovieRating { get; set; }
        public RatingUnitedKingdomTelevisionType? TvRating { get; set; }
    }
}
