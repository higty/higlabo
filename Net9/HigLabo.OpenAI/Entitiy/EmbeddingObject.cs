using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class EmbeddingObject
{
    public int Index { get; set; }
    public List<float> Embedding { get; set; } = new();
}
