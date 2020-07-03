using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class GetRequestTokenCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public String ConsumerKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ConsumerKeySecret { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String TokenSecret { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public HttpMethodName MethodName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String TimeStamp { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String Nonce { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consumerKey"></param>
        /// <param name="consumerKeySecret"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        /// <param name="methodName"></param>
        public GetRequestTokenCommand(String consumerKey, String consumerKeySecret, String token, String tokenSecret
            , HttpMethodName methodName)
        {
            if (String.IsNullOrEmpty(consumerKey) == true){throw new ArgumentNullException("consumerKey");}
            this.ConsumerKey = consumerKey;
            this.ConsumerKeySecret = consumerKeySecret;
            this.Token = token;
            this.TokenSecret = tokenSecret;
            this.MethodName = methodName;
            this.Nonce = OAuth1Client.GenerateNonce();
            this.TimeStamp = OAuth1Client.GenerateTimeStamp();
            if (this.Token == null)
            {
                this.Token = String.Empty;
            }
        }
    }
}
