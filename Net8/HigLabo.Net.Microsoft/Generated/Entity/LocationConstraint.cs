using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/locationconstraint?view=graph-rest-1.0
    /// </summary>
    public partial class LocationConstraint
    {
        public bool? IsRequired { get; set; }
        public LocationConstraintItem[]? Locations { get; set; }
        public bool? SuggestLocation { get; set; }
    }
}
