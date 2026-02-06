namespace HigLabo.X;

public class XApiResult<T> : RestApiResponse
{
    public T? Data { get; set; }
    public XIncludes? Includes { get; set; }
    public XApiMeta? Meta { get; set; }
    public List<XApiError> Errors { get; set; } = new();
}
