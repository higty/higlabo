using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingireland?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingIreland
    {
        public enum MediaContentRatingIrelandRatingIrelandMoviesType
        {
            AllAllowed,
            AllBlocked,
            General,
            ParentalGuidance,
            AgesAbove12,
            AgesAbove15,
            AgesAbove16,
            Adults,
        }
        public enum MediaContentRatingIrelandRatingIrelandTelevisionType
        {
            AllAllowed,
            AllBlocked,
            General,
            Children,
            YoungAdults,
            ParentalSupervision,
            Mature,
        }

        public RatingIrelandMoviesType? MovieRating { get; set; }
        public RatingIrelandTelevisionType? TvRating { get; set; }
    }
}
