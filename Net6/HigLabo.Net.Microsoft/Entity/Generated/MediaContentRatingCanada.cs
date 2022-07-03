using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingcanada?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingCanada
    {
        public MediaContentRatingCanadaRatingCanadaMoviesType MovieRating { get; set; }
        public MediaContentRatingCanadaRatingCanadaTelevisionType TvRating { get; set; }
    }
}
