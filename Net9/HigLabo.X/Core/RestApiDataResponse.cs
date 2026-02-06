namespace HigLabo.X;

public class RestApiDataResponse<T> : RestApiResponse
{
#pragma warning disable CS8618
    public T Data { get; set; }
#pragma warning restore CS8618
}
