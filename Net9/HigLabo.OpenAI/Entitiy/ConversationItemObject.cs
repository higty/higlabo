namespace HigLabo.OpenAI;
public class ConversationItemObject
{
    public List<object>? Data { get; set; }
    public string First_Id { get; set; } = "";
    public string Last_Id { get; set; } = "";
    public bool Has_More { get; set; }
    public string Object { get; set; } = "";
}
