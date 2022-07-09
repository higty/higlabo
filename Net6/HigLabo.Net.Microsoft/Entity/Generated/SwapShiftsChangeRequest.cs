using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/swapshiftschangerequest?view=graph-rest-1.0
    /// </summary>
    public partial class SwapShiftsChangeRequest
    {
        public string? RecipientShiftId { get; set; }
    }
}
