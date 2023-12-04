using System;
using System.Collections.Generic;

namespace HigLabo.OpenAI
{
    public class EmbeddingObject
    {
        public int Index { get; set; }
        public List<double> Embedding { get; set; } = new List<double>();
    }
}
