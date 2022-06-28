using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class PagingContext<T>
        where T: RestApiResponse
    {
        public static readonly PagingContext<T> Empty = new PagingContext<T>();
        public event EventHandler<ResponseReceivedEventArgs<T>>? ResponseReceived;

        public Boolean Break { get; set; } = false;

        internal void InvokeResponseReceived(ResponseReceivedEventArgs<T> e)
        {
            this.ResponseReceived?.Invoke(this, e);
        }
    }
}
