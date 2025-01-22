using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public interface IFormDataParameter
{
    Dictionary<string, string> CreateFormDataParameter();
}
