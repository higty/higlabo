namespace HigLabo.Bing
{
    public class TimeZone
    {
        public string Date { get; set; } = "";
        public string Description { get; set; } = "";
        public TimeZoneInformation[]? OtherCityTimes { get; set; } 
        public TimeZoneInformation? PrimaryCityTime { get; set; } 
        public string PrimaryResponse { get; set; } = "";
        public TimeZoneInformation? PrimaryTimeZone { get; set; } 
        public TimeZoneDifference? TimeZoneDifference { get; set; } 
    }
}
