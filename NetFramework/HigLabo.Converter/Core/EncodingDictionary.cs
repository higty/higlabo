using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Converter
{
    public class EncodingDictionary 
    {
        private Dictionary<String, Encoding> _Encodings = new Dictionary<string, Encoding>();
        public static EncodingDictionary Current { get; private set; }

        public Encoding this[String key]
        {
            get { return _Encodings[key]; }
            set { _Encodings[key] = value; }
        }

        static EncodingDictionary()
        {
            Current = new EncodingDictionary();
            var d = Current._Encodings;
            d["UTF7"] = Encoding.GetEncoding("UTF-7");
            d["UTF8"] = Encoding.UTF8;
            d["UTF32"] = Encoding.GetEncoding("utf-32");
            d["CP1252"] = Encoding.GetEncoding("windows-1252");
        }

        public Encoding GetEncoding(String encoding)
        {
            return GetEncoding(encoding, null);
        }
        public Encoding GetEncoding(String encoding, Encoding defaultEncoding)
        {
            var d = _Encodings;
            if (d.ContainsKey(encoding.ToUpper()) == true)
            {
                return d[encoding.ToUpper()];
            }
            try
            {
                return Encoding.GetEncoding(encoding);
            }
            catch { return defaultEncoding; }
        }
        public void Add(String key, Encoding encoding)
        {
            _Encodings.Add(key, encoding);
        }
        public void Remove(String key)
        {
            _Encodings.Remove(key);
        }
    }
}
