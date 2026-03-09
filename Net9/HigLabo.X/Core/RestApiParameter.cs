namespace HigLabo.X;

public abstract class RestApiParameter
{
    public static readonly object EmptyParameter = new object();
    public abstract object GetRequestBody();
}
