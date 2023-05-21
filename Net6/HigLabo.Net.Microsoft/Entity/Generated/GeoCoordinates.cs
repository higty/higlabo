using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/geocoordinates?view=graph-rest-1.0
    /// </summary>
    public partial class GeoCoordinates
    {
        public Double? Altitude { get; set; }
        public Double? Latitude { get; set; }
        public Double? Longitude { get; set; }
    }
}
