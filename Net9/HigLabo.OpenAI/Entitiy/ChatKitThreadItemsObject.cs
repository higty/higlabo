using static HigLabo.OpenAI.ChatKitThreadObject;

namespace HigLabo.OpenAI;
public class ChatKitThreadItemsObject
{
    public string Object { get; set; } = "";
    public List<object> Data { get; set; } = new List<object>();
    public string First_Id { get; set; } = "";
    public bool Has_More { get; set; }
    public string Last_Id { get; set; } = "";
}
public class ChatKitThreadItemsObjectResponse : RestApiResponse
{
    public List<object> Data { get; set; } = new List<object>();
    public string First_Id { get; set; } = "";
    public bool Has_More { get; set; }
    public string Last_Id { get; set; } = "";

}