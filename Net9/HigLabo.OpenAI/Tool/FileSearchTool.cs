namespace HigLabo.OpenAI;
public class FileSearchTool : Tool
{
    public List<string>? Vector_Store_Ids { get; set; }
    public int? Max_Num_Results { get; set; }

    public FileSearchTool()
        : base("file_search")
    {

    }
}
