using HigLabo.Core;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace HigLabo.GoogleAI
{
    public partial class ModelsListParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";

        public int? PageSize { get; set; }
        public string? PageToken { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"models";
        }
        public override object GetRequestBody()
        {
            return new
            {
                pageSize = this.PageSize,
                pageToken = this.PageToken,
            };
        }
    }
    public class ModelsListObject
    {
        public List<Model> Models { get; init; } = new();
        public string? NextPageToken { get; set; }
    }
    public class ModelsListResponse : RestApiResponse
    {
        public List<Model> Models { get; init; } = new();
        public string? NextPageToken { get; set; }
    }

    public partial class GoogleAIClient
    {
        public async ValueTask<ModelsListResponse> ListAsync(ModelsListParameter parameter)
        {
            return await this.ListAsync(parameter, CancellationToken.None);
        }
        public async ValueTask<ModelsListResponse> ListAsync(ModelsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ModelsListParameter, ModelsListResponse>(parameter, cancellationToken);
        }
    }
}
