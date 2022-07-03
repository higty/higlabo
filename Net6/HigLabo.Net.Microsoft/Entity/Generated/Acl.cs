using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/externalconnectors-acl?view=graph-rest-1.0
    /// </summary>
    public partial class Acl
    {
        public AclExternalConnectorsAccessType AccessType { get; set; }
        public AclExternalConnectorsAclType Type { get; set; }
        public string Value { get; set; }
    }
}
