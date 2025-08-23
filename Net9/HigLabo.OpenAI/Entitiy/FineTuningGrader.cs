namespace HigLabo.OpenAI;
public class FineTuningGrader
{
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";

    public string? Input { get; set; } 
    public string? Operation { get; set; }
    public string? Reference { get; set; }
    public string? Evaluation_Metric { get; set; }
    public string? Source { get; set; }
    public string? Image_Tag { get; set; } 
    public string? Model { get; set; }
    public List<double>? Range { get; set; }
    public object? Sampling_Params { get; set; }
    public string? Calculate_Output { get; set; }
    public FineTuningGrader? Graders { get; set; }
}
