using System.Text;

namespace HigLabo.OpenAI;

public class ResponseDeltaObject
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Content_Index { get; set; }
    public int Summary_Index { get; set; }
    public string? Delta { get; set; }
    public int Sequence_Number { get; set; }

    public override string ToString()
    {
        return this.Delta ?? "";
    }
}
