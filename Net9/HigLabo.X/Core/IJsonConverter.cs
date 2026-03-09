namespace HigLabo.X;

public interface IJsonConverter
{
    string SerializeObject(object obj);
    T DeserializeObject<T>(string json);
}
