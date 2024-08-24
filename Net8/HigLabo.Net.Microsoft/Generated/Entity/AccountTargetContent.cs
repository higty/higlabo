using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accounttargetcontent?view=graph-rest-1.0
    /// </summary>
    public partial class AccountTargetContent
    {
        public enum AccountTargetContentAccountTargetContentType
        {
            Unknown,
            IncludeAll,
            AddressBook,
            UnknownFutureValue,
        }

        public AccountTargetContentAccountTargetContentType Type { get; set; }
    }
}
