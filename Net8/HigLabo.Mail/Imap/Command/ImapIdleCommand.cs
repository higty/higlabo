using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Net.Internal;
using HigLabo.Core;

namespace HigLabo.Net.Imap
{
    public class ImapIdleCommand : ImapDataReceiveContext
    {
        public event EventHandler<ImapIdleCommandMessageReceivedEventArgs>? MessageReceived;
        public IAsyncResult? IAsyncResult { get; set; }
        internal new Byte[] Buffer
        {
            get { return base.Buffer; }
        }

        internal ImapIdleCommand(String tag, Encoding encoding)
            : base(tag, encoding)
        {
        }
        private void OnMessageReceived(ImapIdleCommandMessageReceivedEventArgs e)
        {
            var eh = this.MessageReceived;
            if (eh != null)
            {
                eh(this, e);
            }
        }
        protected override bool ParseBuffer(int size)
        {
            var position = this.Stream.Position;
            var bl = base.ParseBuffer(size);
            this.Stream.Position = position;

            var text = this.Encoding.GetString(this.Stream.ToByteArray());
            var e = new ImapIdleCommandMessageReceivedEventArgs(text);
            this.OnMessageReceived(e);
            return e.Done == false;
        }
    }
}
