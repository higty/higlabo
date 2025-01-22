namespace HigLabo.RestApi;

public interface IJsonConverter
{
    string SerializeObject(object obj);
    T DeserializeObject<T>(String json);
}
