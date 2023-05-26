using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/outlookgeocoordinates?view=graph-rest-1.0
    /// </summary>
    public partial class OutlookGeoCoordinates
    {
        public Double? Accuracy { get; set; }
        public Double? Altitude { get; set; }
        public Double? AltitudeAccuracy { get; set; }
        public Double? Latitude { get; set; }
        public Double? Longitude { get; set; }
    }
}
