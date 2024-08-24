using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-whoiscontact?view=graph-rest-1.0
    /// </summary>
    public partial class WhoisContact
    {
        public PhysicalAddress? Address { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
        public string? Name { get; set; }
        public string? Organization { get; set; }
        public string? Telephone { get; set; }
    }
}
