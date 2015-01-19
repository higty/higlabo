using System;
using System.Text.RegularExpressions;

namespace HigLabo.Net
{
    ///<summary>
    /// 
    ///</summary>
    public class OAuth1AuthorizeInfo
    {
        ///<summary>
        /// 
        ///</summary>
        public class RegexList
        {
            ///<summary>
            /// 
            ///</summary>
            public static readonly Regex OAuthToken = new Regex(@"oauth_token=([^&]*)");
            /// <summary>
            /// 
            /// </summary>
            public static readonly Regex OAuthTokenSecret = new Regex(@"oauth_token_secret=([^&]*)");
            /// <summary>
            /// 
            /// </summary>
            public static readonly Regex OAuthCallback = new Regex(@"oauth_callback=([^&]*)");
        }
        
        ///<summary>
        /// 
        ///</summary>
        public string AuthorizeUrl { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public string RequestToken { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public string RequestTokenSecret { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public OAuth1AuthorizeInfo()
        {
            this.AuthorizeUrl = String.Empty;
            this.RequestToken = String.Empty;
            this.RequestTokenSecret = String.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorizeUrl"></param>
        /// <param name="requestToken"></param>
        /// <param name="requestTokenSecret"></param>
        public OAuth1AuthorizeInfo(String authorizeUrl, String requestToken, String requestTokenSecret)
        {
            this.AuthorizeUrl = authorizeUrl;
            this.RequestToken = requestToken;
            this.RequestTokenSecret = requestTokenSecret;
        }

        public static OAuth1AuthorizeInfo Create(String authorizeUrl, String text)
        {
            OAuth1AuthorizeInfo ai = new OAuth1AuthorizeInfo();
            ai.AuthorizeUrl = String.Format("{0}?{1}", authorizeUrl, text);
            ai.RequestToken = GetMatchValue(RegexList.OAuthToken, text);
            ai.RequestTokenSecret = GetMatchValue(RegexList.OAuthTokenSecret, text);
            return ai;
        }
        private static String GetMatchValue(Regex regex, String input)
        {
            var m = regex.Match(input);
            if (m.Groups.Count > 1)
            {
                return m.Groups[1].Value;
            }
            return "";
        }
    }
}