using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/requestsignatureverification?view=graph-rest-1.0
    /// </summary>
    public partial class RequestSignatureVerification
    {
        public enum RequestSignatureVerificationWeakAlgorithms
        {
            RsaSha1,
            UnknownFutureValue,
        }

        public RequestSignatureVerificationWeakAlgorithms AllowedWeakAlgorithms { get; set; }
        public bool? IsSignedRequestRequired { get; set; }
    }
}
