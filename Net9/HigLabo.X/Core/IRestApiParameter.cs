namespace HigLabo.X;

public interface IRestApiParameter
{
    string GetApiPath();
    string HttpMethod { get; }
}
