using System;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class SignatureInfo
    {
        ///<summary>
        /// 
        ///</summary>
        public string Signature { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public string NormalizedUrl { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public string NormalizedRequestParameters { get; set; }

        ///<summary>
        /// 
        ///</summary>
        public SignatureInfo()
        {
            NormalizedRequestParameters = String.Empty;
            NormalizedUrl = String.Empty;
            Signature = String.Empty;
        }
    }
}