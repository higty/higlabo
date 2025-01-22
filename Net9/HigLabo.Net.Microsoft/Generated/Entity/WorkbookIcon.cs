using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/workbookicon?view=graph-rest-1.0
/// </summary>
public partial class WorkbookIcon
{
    public enum WorkbookIconstring
    {
        Invalid,
        ThreeArrows,
        ThreeArrowsGray,
        ThreeFlags,
        ThreeTrafficLights1,
        ThreeTrafficLights2,
        ThreeSigns,
        ThreeSymbols,
        ThreeSymbols2,
        FourArrows,
        FourArrowsGray,
        FourRedToBlack,
        FourRating,
        FourTrafficLights,
        FiveArrows,
        FiveArrowsGray,
        FiveRating,
        FiveQuarters,
        ThreeStars,
        ThreeTriangles,
        FiveBoxes,
    }

    public int? Index { get; set; }
    public WorkbookIconstring Set { get; set; }
}
