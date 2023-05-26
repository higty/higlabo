using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/directory?view=graph-rest-1.0
    /// </summary>
    public partial class Directory
    {
        public string? Id { get; set; }
        public AdministrativeUnit[]? AdministrativeUnits { get; set; }
        public DirectoryObject[]? DeletedItems { get; set; }
        public IdentityProviderBase[]? FederationConfigurations { get; set; }
        public OnPremisesDirectorySynchronization? OnPremisesSynchronization { get; set; }
    }
}
