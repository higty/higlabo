using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcgalleryimage?view=graph-rest-1.0
/// </summary>
public partial class CloudPcGalleryImage
{
    public enum CloudPcGalleryImageCloudPcGalleryImageStatus
    {
        Supported,
        SupportedWithWarning,
        NotSupported,
        UnknownFutureValue,
    }

    public string? DisplayName { get; set; }
    public DateOnly? EndDate { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    public string? Id { get; set; }
    public string? OfferName { get; set; }
    public string? PublisherName { get; set; }
    public Int32? SizeInGB { get; set; }
    public string? SkuName { get; set; }
    public DateOnly? StartDate { get; set; }
    public CloudPcGalleryImageCloudPcGalleryImageStatus Status { get; set; }
}
