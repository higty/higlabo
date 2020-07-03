using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mime
{
    public class MimeHeaderCollection 
    {
        private List<MimeHeader> _Headers = new List<MimeHeader>();

        public String this[String key]
        {
            get
            {
                var header = _Headers.FindLast(el => String.Equals(el.Key, key, StringComparison.OrdinalIgnoreCase));
                if (header == null) { return ""; }
                return header.Value;
            }
        }
        public MimeHeader this[Int32 index]
        {
            get { return _Headers[index]; }            
        }
        public IEnumerable<MimeHeader> Values
        {
            get { return _Headers; }
        }
        public Int32 Count
        {
            get { return _Headers.Count; }
        }

        public MimeHeaderCollection()
        {
        }

        public void Add(MimeHeader header)
        {
            _Headers.Add(header);
        }
        public void AddRange(IEnumerable<MimeHeader> headers)
        {
            _Headers.AddRange(headers);
        }
        public void Remove(String key)
        {
            _Headers.RemoveAll(el => String.Equals(el.Key, key, StringComparison.OrdinalIgnoreCase));
        }
        public void Clear()
        {
            _Headers.Clear();
        }
        public Boolean TryGetValue(String key, out MimeHeader value)
        {
            var header = _Headers.Find(el => String.Equals(el.Key, key, StringComparison.OrdinalIgnoreCase));
            value = header;
            return header != null;
        }
        public MimeHeader GetValueOrNull(String key)
        {
            return _Headers.Find(el => String.Equals(el.Key, key, StringComparison.OrdinalIgnoreCase));
        }
        public Boolean ContainsKey(String key)
        {
            return _Headers.Exists(el => String.Equals(el.Key, key, StringComparison.OrdinalIgnoreCase));
        }
    }
}
