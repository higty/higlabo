using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth;

public class AccessTokenUpdatedEventArgs<T>
    where T : RestApiResponse
{
    public T Response { get; init; }

    public AccessTokenUpdatedEventArgs(T response)
    {
        this.Response = response;
    }
}
