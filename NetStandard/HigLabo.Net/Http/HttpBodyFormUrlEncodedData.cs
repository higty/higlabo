using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpBodyFormUrlEncodedData
    {
        private Dictionary<String, String> _Values = null;
        /// <summary>
        /// 
        /// </summary>
        public Encoding Encoding { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<String, String> Values
        {
            get { return _Values; }
        }
        /// <summary>
        /// 
        /// </summary>
        public HttpBodyFormUrlEncodedData()
        {
            this.Encoding = HttpClient.DefaultEncoding;
            this._Values = new Dictionary<string, string>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        public HttpBodyFormUrlEncodedData(Dictionary<String, String> values)
        {
            this.Encoding = HttpClient.DefaultEncoding;
            this._Values = values;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="values"></param>
        public HttpBodyFormUrlEncodedData(Encoding encoding, Dictionary<String, String> values)
        {
            this.Encoding = encoding;
            this._Values = values;
        }
    }
}
