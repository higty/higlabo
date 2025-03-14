using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class ResponseStreamResult
{
    public List<ResponseDeltaObject> DeltaList { get; init; } = new();
    public string? Text { get; set; } 
    public List<ResponseOutputContent> ContentList { get; init; } = new(); 
    public ResponseObject? Response {  get; set; }
}
