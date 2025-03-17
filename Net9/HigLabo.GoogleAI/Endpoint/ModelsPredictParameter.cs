using HigLabo.Core;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace HigLabo.GoogleAI;

public partial class ModelsPredictParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Model { get; set; } = "";
    public List<PredictInstance> Instances { get; set; } = new();
    public PredictParameter? Parameters { get; set; }

    string IRestApiParameter.GetApiPath()
    {
        return $"models/{this.Model}:predict";
    }
    public override object GetRequestBody()
    {
        return new
        {
            model = this.Model,
            instances = this.Instances,
            parameters = this.Parameters,
        };
    }
}
public class ModelsPredictObject
{
    public List<Prediction> Predictions { get; set; } = new();
}
public class ModelsPredictResponse : RestApiResponse
{
    public List<Prediction> Predictions { get; set; } = new();
}

public partial class GoogleAIClient
{
    public async ValueTask<ModelsPredictResponse> PredictAsync(ModelsPredictParameter parameter)
    {
        return await this.PredictAsync(parameter, CancellationToken.None);
    }
    public async ValueTask<ModelsPredictResponse> PredictAsync(ModelsPredictParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ModelsPredictParameter, ModelsPredictResponse>(parameter, cancellationToken);
    }
}
