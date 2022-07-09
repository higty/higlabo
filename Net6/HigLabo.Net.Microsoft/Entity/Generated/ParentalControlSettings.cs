using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/parentalcontrolsettings?view=graph-rest-1.0
    /// </summary>
    public partial class ParentalControlSettings
    {
        public String[]? CountriesBlockedForMinors { get; set; }
        public string? LegalAgeGroupRule { get; set; }
    }
}
