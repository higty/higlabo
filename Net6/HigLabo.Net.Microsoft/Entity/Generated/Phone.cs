using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/phone?view=graph-rest-1.0
    /// </summary>
    public partial class Phone
    {
        public String? Number { get; set; }
        public PhonePhoneType Type { get; set; }
    }
}
