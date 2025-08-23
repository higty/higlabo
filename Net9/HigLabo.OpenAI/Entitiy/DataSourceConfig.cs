namespace HigLabo.OpenAI;
public class DataSourceConfig
{
    public object Item_Schema { get; set; } = new();
    public string Type { get; set; } = "";
    public bool? lInclude_Sample_Schema { get; set; }
    public object? Metadata { get; set; }
}
