using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/microsoftmanageddesktop?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftManagedDesktop
{
    public enum MicrosoftManagedDesktopMicrosoftManagedDesktopType
    {
        NotManaged,
        PremiumManaged,
        StandardManaged,
        StarterManaged,
        UnknownFutureValue,
    }

    public MicrosoftManagedDesktop? ManagedType { get; set; }
    public string? Profile { get; set; }
}
