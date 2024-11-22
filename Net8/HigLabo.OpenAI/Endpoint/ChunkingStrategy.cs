using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class ChunkingStrategy
{
    public string Type { get; set; } = "";
    public ChunkingStrategyStatic? Static { get; set; } 
}
public class ChunkingStrategyStatic
{
    public int Max_Chunk_Size_Tokens { get; set; }
    public int Chunk_Overlap_Tokens { get; set; }
}
