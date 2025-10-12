using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public interface IQueryParameter
{
    string GetQueryString();
}
public interface IQueryParameterProperty
{
    IQueryParameter QueryParameter { get; }
}

