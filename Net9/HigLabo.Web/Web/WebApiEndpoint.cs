using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace HigLabo.Web;

public abstract class WebApiEndpoint<T> 
    where T : AppHttpContext
{
    public T AppHttpContext { get; private set; }

    public WebApiEndpoint(T appHttpContext)
    {
        this.AppHttpContext = appHttpContext;
    }

    public abstract ValueTask<object> ExecuteAsync(CancellationToken cancellationToken);
}