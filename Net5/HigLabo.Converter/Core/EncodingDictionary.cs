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
            d["UTF8"] = Encoding.UTF8;
            AddEncoding("UTF7", "UTF-7");
            AddEncoding("UTF32", "utf-32");
            AddEncoding("CP1252", "windows-1252");
        }
        private static void AddEncoding(String key, String codepage)
        {
            try
            {
                var en = Encoding.GetEncoding(codepage);
                if (en == null) { return; }
                Current._Encodings[key] = en;
            }
            catch { }
        }
        public Encoding GetEncoding(String encoding)
        {
            var en = TryGetEncoding(encoding);
            if (en == null) { throw new EncodingNotFoundException(encoding); }
            return en;
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
        public Encoding TryGetEncoding(String encoding)
        {
            var en = GetEncoding(encoding, null);
            if (en == null)
            {
                en = GetEncoding(encoding.TrimStart('"').TrimEnd('"'), null);
            }
            if (en == null)
            {
                en = GetEncoding(encoding.TrimStart('\'').TrimEnd('\''), null);
            }
            return en;
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
