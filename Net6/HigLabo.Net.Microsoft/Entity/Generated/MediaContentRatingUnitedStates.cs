using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingunitedstates?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingUnitedStates
    {
        public MediaContentRatingUnitedStatesRatingUnitedStatesMoviesType MovieRating { get; set; }
        public MediaContentRatingUnitedStatesRatingUnitedStatesTelevisionType TvRating { get; set; }
    }
}
