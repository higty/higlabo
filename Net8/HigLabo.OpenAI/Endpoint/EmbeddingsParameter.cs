using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public partial class EmbeddingsParameter
{
    public void SetEncodingFormat(EmbeddingsEncodingFormat format)
    {
        this.Encoding_Format = format.ToStringFromEnum().ToLower();
    }

}
