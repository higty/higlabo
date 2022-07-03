using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingfrance?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingFrance
    {
        public MediaContentRatingFranceRatingFranceMoviesType MovieRating { get; set; }
        public MediaContentRatingFranceRatingFranceTelevisionType TvRating { get; set; }
    }
}
