using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponseObject
    {
        /// <summary>
        /// 
        /// </summary>
        public String JsonText { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public XElement XElement { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<String, Object> _Data = new Dictionary<string,object>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Object this[String name]
        {
            get
            {
                if (_Data.ContainsKey(name) == false) { return null; }
                return _Data[name];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<String, Object>.KeyCollection Keys
        {
            get { return _Data.Keys; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonText"></param>
        public virtual void SetProperty(String jsonText)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public virtual void SetProperty(XElement element)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        protected Dictionary<String, Object> SetData(String jsonText)
        {
            if (String.IsNullOrEmpty(jsonText) == true)
            {
                this.JsonText = "";
                _Data = new Dictionary<string, object>();
            }
            else
            {
                this.JsonText = jsonText;
                _Data = JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonText);
            }
            return _Data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected Dictionary<String, Object> SetElements(XElement element)
        {
            this.XElement = element;
            foreach (var d in element.Elements())
            {
                if (d.Name == null) { continue; }
                _Data[d.Name.LocalName] = d.Value;
            }
            foreach (var d in element.Attributes())
            {
                if (d.Name == null) { continue; }
                _Data[d.Name.LocalName] = d.Value;
            }
            return _Data;
        }
    }
}
