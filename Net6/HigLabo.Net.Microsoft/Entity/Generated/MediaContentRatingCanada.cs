using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingcanada?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingCanada
    {
        public enum MediaContentRatingCanadaRatingCanadaMoviesType
        {
            AllAllowed,
            AllBlocked,
            General,
            ParentalGuidance,
            AgesAbove14,
            AgesAbove18,
            Restricted,
        }
        public enum MediaContentRatingCanadaRatingCanadaTelevisionType
        {
            AllAllowed,
            AllBlocked,
            Children,
            ChildrenAbove8,
            General,
            ParentalGuidance,
            AgesAbove14,
            AgesAbove18,
        }

        public RatingCanadaMoviesType? MovieRating { get; set; }
        public RatingCanadaTelevisionType? TvRating { get; set; }
    }
}
