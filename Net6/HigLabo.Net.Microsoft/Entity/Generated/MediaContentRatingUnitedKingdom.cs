using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingunitedkingdom?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingUnitedKingdom
    {
        public MediaContentRatingUnitedKingdomRatingUnitedKingdomMoviesType MovieRating { get; set; }
        public MediaContentRatingUnitedKingdomRatingUnitedKingdomTelevisionType TvRating { get; set; }
    }
}
