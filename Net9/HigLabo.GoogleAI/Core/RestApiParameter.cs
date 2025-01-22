using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.GoogleAI;

public abstract class RestApiParameter
{
    public static readonly object EmptyParameter = new object();
    public abstract object GetRequestBody();
}
