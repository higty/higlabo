using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/fido2keyrestrictions?view=graph-rest-1.0
    /// </summary>
    public partial class Fido2KeyRestrictions
    {
        public enum Fido2KeyRestrictionsFido2RestrictionEnforcementType
        {
            Allow,
            Block,
        }

        public String[]? AaGuids { get; set; }
        public Fido2KeyRestrictionsFido2RestrictionEnforcementType EnforcementType { get; set; }
        public bool? IsEnforced { get; set; }
    }
}
