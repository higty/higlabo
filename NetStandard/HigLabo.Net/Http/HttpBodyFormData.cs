using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpBodyFormData
    {
        private Byte[] _Data = null;
        /// <summary>
        /// 
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ContentType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ContentTransferEncoding { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ContentDisposition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Charset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Byte[] Data
        {
            get { return _Data; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public HttpBodyFormData(String name)
        {
            if (name == null) { throw new ArgumentNullException("name must not be null"); }
            this.Name = name;
            this.ContentDisposition = "form-data";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void SetData(Byte[] data)
        {
            this._Data = data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="text"></param>
        public void SetData(Encoding encoding, String text)
        {
            this._Data = encoding.GetBytes(text);
        }
    }
}
