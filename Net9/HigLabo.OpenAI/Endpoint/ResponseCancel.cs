namespace HigLabo.OpenAI;

/// <summary>Cancels a response created with background=true.</summary>
public class ResponseCancelParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod => "POST";
    public string Response_Id { get; set; } = "";
    string IRestApiParameter.GetApiPath() => $"/responses/{Uri.EscapeDataString(Response_Id)}/cancel";
    public override object GetRequestBody() => EmptyParameter;
}

public class ResponseCancelResponse : ResponseObjectResponse { }

public partial class OpenAIClient
{
    public ValueTask<ResponseCancelResponse> ResponseCancelAsync(string response_Id)
        => ResponseCancelAsync(response_Id, CancellationToken.None);

    public ValueTask<ResponseCancelResponse> ResponseCancelAsync(string response_Id, CancellationToken cancellationToken)
        => ResponseCancelAsync(new ResponseCancelParameter { Response_Id = response_Id }, cancellationToken);

    public ValueTask<ResponseCancelResponse> ResponseCancelAsync(ResponseCancelParameter parameter)
        => ResponseCancelAsync(parameter, CancellationToken.None);

    public ValueTask<ResponseCancelResponse> ResponseCancelAsync(ResponseCancelParameter parameter, CancellationToken cancellationToken)
        => SendJsonAsync<ResponseCancelParameter, ResponseCancelResponse>(parameter, cancellationToken);
}
