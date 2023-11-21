using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
    public class WebServerException : Exception
    {
        public HttpRequest Request { get; init; }

        public WebServerException(HttpRequest request, String message)
            : this(request, message, null)
        {
        }
        public WebServerException(HttpRequest request, String message, Exception? exception)
          : base(message, exception)
        {
            if (request == null) { throw new ArgumentNullException(nameof(request), $"{nameof(request)} must not be null."); }
            this.Request = request;
        }
        public override String ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine(this.Request.GetPathAndQuery());
            sb.AppendLine();
            sb.AppendLine(this.Request.GetRequestHeaderText());
            sb.AppendLine();
            sb.AppendLine(this.Request.GetRequestBodyTextAsync().GetAwaiter().GetResult());
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
