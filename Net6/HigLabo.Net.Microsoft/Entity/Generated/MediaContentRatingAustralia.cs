using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingaustralia?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingAustralia
    {
        public enum MediaContentRatingAustraliaRatingAustraliaMoviesType
        {
            AllAllowed,
            AllBlocked,
            General,
            ParentalGuidance,
            Mature,
            AgesAbove15,
            AgesAbove18,
        }
        public enum MediaContentRatingAustraliaRatingAustraliaTelevisionType
        {
            AllAllowed,
            AllBlocked,
            Preschoolers,
            Children,
            General,
            ParentalGuidance,
            Mature,
            AgesAbove15,
            AgesAbove15AdultViolence,
        }

        public RatingAustraliaMoviesType? MovieRating { get; set; }
        public RatingAustraliaTelevisionType? TvRating { get; set; }
    }
}
