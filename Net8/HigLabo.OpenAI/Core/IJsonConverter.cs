namespace HigLabo.OpenAI
{
    public interface IJsonConverter
    {
        string SerializeObject(object obj);
        T DeserializeObject<T>(String json);
    }
}
