using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/photo?view=graph-rest-1.0
    /// </summary>
    public partial class Photo
    {
        public DateTimeOffset? TakenDateTime { get; set; }
        public string? CameraMake { get; set; }
        public string? CameraModel { get; set; }
        public Double? FNumber { get; set; }
        public Double? ExposureDenominator { get; set; }
        public Double? ExposureNumerator { get; set; }
        public Double? FocalLength { get; set; }
        public Int32? Iso { get; set; }
        public Int16? Orientation { get; set; }
    }
}
