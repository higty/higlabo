using System;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class XmlAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public XmlAttribute(string key, string value)
        {
            Key = key;
            Value = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("{0}=\"{1}\"", Key, Value);
        }
    }
}