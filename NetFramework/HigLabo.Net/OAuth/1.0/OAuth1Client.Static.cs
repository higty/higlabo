using System;
#if NETFX_CORE
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Security.Cryptography.Certificates;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;
#else
using System.Security.Cryptography;
#endif
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.Net
{
    public partial class OAuth1Client
    {
#if SILVERLIGHT || NETFX_CORE
        private static readonly Encoding GenerateSignatureEncoding = Encoding.UTF8;
#else
        private static readonly Encoding GenerateSignatureEncoding = Encoding.GetEncoding("us-ascii");
#endif
        /// <summary>
        /// 
        /// </summary>
        public class Key
        {
            /// <summary>
            /// 
            /// </summary>
            public static readonly String OAuthVersionNo = "1.0";
            /// <summary>
            /// 
            /// </summary>
            public static readonly String OAuthParameterPrefix = "oauth_";
            /// <summary>
            /// List of know and used oauth parameters' names 
            /// </summary>
            public static readonly String OAuthConsumerKey = "oauth_consumer_key";
            /// <summary>
            /// 
            /// </summary>
            public static readonly String OAuthCallback = "oauth_callback";
            /// <summary>
            /// 
            /// </summary>
            public static readonly String OAuthVersion = "oauth_version";
            /// <summary>
            /// 
            /// </summary>
            public static readonly String OAuthSignatureMethod = "oauth_signature_method";
            /// <summary>
            /// 
            /// </summary>
            public static readonly String OAuthSignature = "oauth_signature";
            /// <summary>
            /// 
            /// </summary>
            public static readonly String OAuthTimestamp = "oauth_timestamp";
            /// <summary>
            /// 
            /// </summary>
            public static readonly String OAuthNonce = "oauth_nonce";
            /// <summary>
            /// 
            /// </summary>
            public static readonly String OAuthToken = "oauth_token";
            /// <summary>
            /// 
            /// </summary>
            public static readonly String OAuthTokenSecret = "oauth_token_secret";
            /// <summary>
            /// 
            /// </summary>
            public static readonly String HMACSHA1SignatureType = "HMAC-SHA1";
            /// <summary>
            /// 
            /// </summary>
            public static readonly String PlainTextSignatureType = "PLAINTEXT";
            /// <summary>
            /// 
            /// </summary>
            public static readonly String RSASHA1SignatureType = "RSA-SHA1";
        }
        private static readonly Random Random = new Random();
        /// <summary>
        /// Internal function to cut out all non oauth query String parameters (all parameters not begining with "oauth_")
        /// </summary>
        /// <param name="parameters">The query String part of the Url</param>
        /// <returns>A list of QueryParameter each containing the parameter name and value</returns>
        protected static List<KeyValuePair<String, String>> GetQueryParameters(String parameters)
        {
            if (parameters.StartsWith("?"))
            {
                parameters = parameters.Remove(0, 1);
            }

            List<KeyValuePair<String, String>> result = new List<KeyValuePair<String, String>>();

            if (!String.IsNullOrEmpty(parameters))
            {
                String[] p = parameters.Split('&');
                foreach (String s in p)
                {
                    if (!String.IsNullOrEmpty(s) && !s.StartsWith(Key.OAuthParameterPrefix))
                    {
                        if (s.IndexOf('=') > -1)
                        {
                            String[] temp = s.Split('=');
                            result.Add(new KeyValuePair<String, String>(temp[0], temp[1]));
                        }
                        else
                        {
                            result.Add(new KeyValuePair<String, String>(s, String.Empty));
                        }
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// Normalizes the request parameters according to the spec
        /// </summary>
        /// <param name="parameters">The list of parameters already sorted</param>
        /// <returns>a String representing the normalized parameters</returns>
        protected static String NormalizeRequestParameters(IList<KeyValuePair<String, String>> parameters)
        {
            StringBuilder sb = new StringBuilder(256);
            KeyValuePair<String, String> p;
            for (int i = 0; i < parameters.Count; i++)
            {
                p = parameters[i];
                sb.AppendFormat("{0}={1}", p.Key, p.Value);

                if (i < parameters.Count - 1)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="command"></param>
        /// <param name="signatureType"></param>
        /// <returns></returns>
        public static SignatureInfo GenerateSignature(Uri url, GetRequestTokenCommand command, OAuthSignatureTypes signatureType)
        {
            var cm = command;
            SignatureInfo si = new SignatureInfo();

            switch (signatureType)
            {
                case OAuthSignatureTypes.PLAINTEXT:
                    si.Signature = OAuth1Client.UrlEncode(String.Format("{0}&{1}", cm.ConsumerKeySecret, cm.TokenSecret));
                    return si;
                case OAuthSignatureTypes.HMACSHA1:
                    si = GenerateSignatureBase(url, cm, Key.HMACSHA1SignatureType);
                    String key = String.Format("{0}&{1}"
                        , OAuth1Client.UrlEncode(cm.ConsumerKeySecret), String.IsNullOrEmpty(cm.TokenSecret) ? "" : OAuth1Client.UrlEncode(cm.TokenSecret));
                    si.Signature = GenerateSignatureUsingHash(key, si.Signature);
                    return si;
                case OAuthSignatureTypes.RSASHA1: throw new NotImplementedException();
            }
            throw new ArgumentException("Unknown signature type", "signatureType");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="command"></param>
        /// <param name="signatureType"></param>
        /// <returns></returns>
        public static SignatureInfo GenerateSignatureBase(Uri url, GetRequestTokenCommand command, String signatureType)
        {
            SignatureInfo si = new SignatureInfo();
            var cm = command;

            if (String.IsNullOrEmpty(signatureType))
            {
                throw new ArgumentNullException("signatureType");
            }

            List<KeyValuePair<String, String>> parameters = OAuth1Client.GetQueryParameters(url.Query);
            parameters.Add(new KeyValuePair<String, String>(Key.OAuthVersion, Key.OAuthVersionNo));
            parameters.Add(new KeyValuePair<String, String>(Key.OAuthNonce, cm.Nonce));
            parameters.Add(new KeyValuePair<String, String>(Key.OAuthTimestamp, cm.TimeStamp));
            parameters.Add(new KeyValuePair<String, String>(Key.OAuthSignatureMethod, signatureType));
            parameters.Add(new KeyValuePair<String, String>(Key.OAuthConsumerKey, cm.ConsumerKey));

            if (!String.IsNullOrEmpty(cm.Token))
            {
                parameters.Add(new KeyValuePair<String, String>(Key.OAuthToken, cm.Token));
            }

            parameters.Sort(CompareQueryString);

            si.NormalizedUrl = String.Format("{0}://{1}", url.Scheme, url.Host);
            if (!((url.Scheme == "http" && url.Port == 80) || (url.Scheme == "https" && url.Port == 443)))
            {
                si.NormalizedUrl += ":" + url.Port;
            }
            si.NormalizedUrl += url.AbsolutePath;
            si.NormalizedRequestParameters = NormalizeRequestParameters(parameters);

            StringBuilder sb = new StringBuilder(1000);
            sb.AppendFormat("{0}&", cm.MethodName.ToString().ToUpper());
            sb.AppendFormat("{0}&", OAuth1Client.UrlEncode(si.NormalizedUrl));
            sb.AppendFormat("{0}", OAuth1Client.UrlEncode(si.NormalizedRequestParameters));
            si.Signature = sb.ToString();
            return si;
        }
        private static int CompareQueryString(KeyValuePair<String, String> x, KeyValuePair<String, String> y)
        {
            if (x.Key == y.Key)
            {
                return String.Compare(x.Value, y.Value);
            }
            return String.Compare(x.Key, y.Key);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
#if NETFX_CORE
        public static String GenerateSignatureUsingHash(String key, String data)
        {
            MacAlgorithmProvider hash = MacAlgorithmProvider.OpenAlgorithm(MacAlgorithmNames.HmacSha1);
            BinaryStringEncoding encoding = BinaryStringEncoding.Utf8;
            var dataBuffer = CryptographicBuffer.ConvertStringToBinary(data, encoding);
            IBuffer buffKeyMaterial = CryptographicBuffer.GenerateRandom(hash.MacLength);
            var hmacKey = hash.CreateKey(OAuth1Client.GenerateSignatureEncoding.GetBytes(key).AsBuffer());
            var hashBytes = CryptographicEngine.Sign(hmacKey, dataBuffer);
            // Verify that the HMAC length is correct for the selected algorithm
            if (hashBytes.Length != hash.MacLength)
            {
                throw new Exception("Error computing digest");
            }
            return Convert.ToBase64String(hashBytes.ToArray());
        }
#else
        public static String GenerateSignatureUsingHash(String key, String data)
        {
            if (String.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException("data");
            }
            HMACSHA1 hash = new HMACSHA1(OAuth1Client.GenerateSignatureEncoding.GetBytes(key));

            byte[] dataBuffer = OAuth1Client.GenerateSignatureEncoding.GetBytes(data);
            byte[] hashBytes = hash.ComputeHash(dataBuffer);

            return Convert.ToBase64String(hashBytes);
        }
#endif
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static SignatureInfo GenerateSignature(Uri url, GetRequestTokenCommand command)
        {
            return GenerateSignature(url, command, OAuthSignatureTypes.HMACSHA1);
        }
        /// <summary>
        /// Generate the timestamp for the signature        
        /// </summary>
        /// <returns></returns>
        internal static String GenerateTimeStamp()
        {
            // Default implementation of UNIX time of the current UTC time
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static String GenerateNonce()
        {
            return GenerateNonce1();
        }
        /// <summary>
        /// Generate a nonce
        /// </summary>
        /// <returns></returns>
        private static String GenerateNonce0()
        {
            // Just a simple implementation of a random number between 123400 and 9999999
            return Random.Next(123400, 9999999).ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static String GenerateNonce1()
        {
            String letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder result = new StringBuilder(8);
            Random random = new Random();
            for (int i = 0; i < 8; ++i)
            {
                result.Append(letters[random.Next(letters.Length)]);
            }
            return result.ToString();
        }
    }
}

