using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/callmediastate?view=graph-rest-1.0
    /// </summary>
    public partial class CallMediaState
    {
        public enum CallMediaStateMediaState
        {
            Active,
            Inactive,
            UnknownFutureValue,
        }

        public CallMediaStateMediaState Audio { get; set; }
    }
}
