using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-mediacontentratingunitedstates?view=graph-rest-1.0
    /// </summary>
    public partial class MediaContentRatingUnitedStates
    {
        public enum MediaContentRatingUnitedStatesRatingUnitedStatesMoviesType
        {
            AllAllowed,
            AllBlocked,
            General,
            ParentalGuidance,
            ParentalGuidance13,
            Restricted,
            Adults,
        }
        public enum MediaContentRatingUnitedStatesRatingUnitedStatesTelevisionType
        {
            AllAllowed,
            AllBlocked,
            ChildrenAll,
            ChildrenAbove7,
            General,
            ParentalGuidance,
            ChildrenAbove14,
            Adults,
        }

        public RatingUnitedStatesMoviesType? MovieRating { get; set; }
        public RatingUnitedStatesTelevisionType? TvRating { get; set; }
    }
}
