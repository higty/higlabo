using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Converter;

namespace HigLabo.Mime
{
    public class MailHeaderCollection : MimeHeaderCollection
    {
        public static readonly Rfc2822Converter Rfc2822Converter = new Rfc2822Converter();

        private DateTimeOffset? _Date = null;
        private String _Subject = null;
        private String _MessageID = null;

        private MailAddress _From = null;
        private MailAddress _Sender = null;
        private MailAddress _ReturnPath = null;

        private MailAddressCollection _ReplyTo = null;
        private MailAddressCollection _To = null;
        private MailAddressCollection _Cc = null;

        public DateTimeOffset Date
        {
            get
            {
                if (_Date == null)
                {
                    var date = this["Date"];
                    _Date = MailHeaderCollection.Rfc2822Converter.Parse(date);
                }
                return _Date.Value;
            }
        }
        public String Subject
        {
            get
            {
                if (_Subject == null)
                {
                    _Subject = this["Subject"];
                }
                return _Subject;
            }
        }
        public String MessageID
        {
            get
            {
                if (_MessageID == null)
                {
                    _MessageID = this["Message-ID"];
                }
                return _MessageID;
            }
        }
        public MailAddress From
        {
            get
            {
                if (_From == null)
                {
                    _From = MailAddress.TryCreate(this["From"]);
                }
                return _From;
            }
        }
        public MailAddress Sender
        {
            get
            {
                if (_Sender == null)
                {
                    _Sender = MailAddress.TryCreate(this["Sender"]);
                }
                return _Sender;
            }
        }
        public MailAddress ReturnPath
        {
            get
            {
                if (_ReturnPath == null)
                {
                    _ReturnPath = MailAddress.TryCreate(this["Return-Path"]);
                }
                return _ReturnPath;
            }
        }
        public MailAddressCollection ReplyTo
        {
            get
            {
                if (_ReplyTo == null)
                {
                    _ReplyTo = new MailAddressCollection(this["Reply-To"]);
                }
                return _ReplyTo;
            }
        }
        public MailAddressCollection To
        {
            get
            {
                if (_To == null)
                {
                    _To = new MailAddressCollection(this["To"]);
                }
                return _To;
            }
        }
        public MailAddressCollection Cc
        {
            get
            {
                if (_Cc == null)
                {
                    _Cc = new MailAddressCollection(this["Cc"]);
                }
                return _Cc;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.Date.ToString(), this.From, this.Subject);
        }
    }
}
