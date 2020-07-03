using HigLabo.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class SmtpMailHeaderCollection : IEnumerable<SmtpMailHeader>
    {
        private List<SmtpMailHeader> _Headers = new List<SmtpMailHeader>();
        public String this[String key]
        {
            get
            {
                var header = _Headers.FindLast(el => String.Equals(el.Key, key, StringComparison.OrdinalIgnoreCase));
                if (header == null) { return ""; }
                return header.Value;
            }
            set
            {
                var header = _Headers.FindLast(el => String.Equals(el.Key, key, StringComparison.OrdinalIgnoreCase));
                if (header == null)
                {
                    this.Add(key, value);
                }
                else
                {
                    header.Value = value;
                }
            }
        }
        public SmtpMailHeader this[Int32 index]
        {
            get { return _Headers[index]; }
        }
        public Int32 Count
        {
            get { return _Headers.Count; }
        }

        public DateTimeOffset Date { get; set; }
        public MailAddress From { get; set; }
        public MailAddress Sender { get; set; }
        public MailPriority Priority { get; set; }
        public TransferEncoding ContentTransferEncoding { get; set; }
        public String Subject
        {
            get { return this["Subject"]; }
            set { this["Subject"] = value; }
        }

        public SmtpMailHeaderCollection()
        {
            this.Priority = MailPriority.Normal;
            this.Subject = "";
        }
        public void Add(String key, String value)
        {
            this.Add(new SmtpMailHeader(key, value));
        }
        public void Add(SmtpMailHeader header)
        {
            _Headers.Add(header);
        }
        public void AddRange(IEnumerable<SmtpMailHeader> headers)
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
        public Boolean TryGetValue(String key, out SmtpMailHeader value)
        {
            var header = _Headers.FindLast(el => String.Equals(el.Key, key, StringComparison.OrdinalIgnoreCase));
            value = header;
            return header != null;
        }
        public SmtpMailHeader GetValueOrNull(String key)
        {
            return _Headers.FindLast(el => String.Equals(el.Key, key, StringComparison.OrdinalIgnoreCase));
        }
        public Boolean ContainsKey(String key)
        {
            return _Headers.Exists(el => String.Equals(el.Key, key, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerator<SmtpMailHeader> GetEnumerator()
        {
            yield return new SmtpMailHeader("Date", MimeWriter.DateTimeOffsetString(this.Date));
            if (this.Sender != null) yield return new SmtpMailHeader("Sender", this.Sender.RawValue);
            if (this.From != null) yield return new SmtpMailHeader("From", this.From.RawValue);
            yield return new SmtpMailHeader("X-Priority", ((byte)this.Priority).ToString());
            foreach (var item in _Headers)
            {
                yield return item;
            }
            if (this.ContentTransferEncoding != TransferEncoding.None)
            {
                yield return new SmtpMailHeader("Content-Transfer-Encoding", this.ContentTransferEncoding.ToHeaderText());
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
