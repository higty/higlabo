namespace HigLabo.GoogleAI;

public class FunctionResponse
{
    public string Name { get; set; } = "";
    public object? Response { get; set; }
    public List<ContentPart>? Parts { get; set; }

    public override string ToString()
    {
        if (this.Response != null)
        {
            return $"{this.Name}({this.Response})";
        }
        return this.Name;
    }
}
