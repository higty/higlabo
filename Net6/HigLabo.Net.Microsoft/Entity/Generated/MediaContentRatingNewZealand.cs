using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingnewzealand?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingNewZealand
    {
        public MediaContentRatingNewZealandRatingNewZealandMoviesType MovieRating { get; set; }
        public MediaContentRatingNewZealandRatingNewZealandTelevisionType TvRating { get; set; }
    }
}
