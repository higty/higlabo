using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingnewzealand?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingNewZealand
    {
        public enum MediaContentRatingNewZealandRatingNewZealandMoviesType
        {
            AllAllowed,
            AllBlocked,
            General,
            ParentalGuidance,
            Mature,
            AgesAbove13,
            AgesAbove15,
            AgesAbove16,
            AgesAbove18,
            Restricted,
            AgesAbove16Restricted,
        }
        public enum MediaContentRatingNewZealandRatingNewZealandTelevisionType
        {
            AllAllowed,
            AllBlocked,
            General,
            ParentalGuidance,
            Adults,
        }

        public RatingNewZealandMoviesType? MovieRating { get; set; }
        public RatingNewZealandTelevisionType? TvRating { get; set; }
    }
}
