using System.Net;
using System.Text;

namespace HigLabo.Web;

public class WebApiResult<T>
{
    public int HttpStatusCode
    {
        get { return (int)this.HttpStatus; }
    }
    public HttpStatusCode HttpStatus { get; set; }
    public string DataType { get; set; } = "";
    public T? Data { get; set; }

}
public class WebApiResult : WebApiResult<object>
{
}