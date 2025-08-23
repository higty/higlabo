using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// List Containers
    /// <seealso href="https://api.openai.com/v1/containers">https://api.openai.com/v1/containers</seealso>
    /// </summary>
    public partial class ContainersParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly ContainersParameter Empty = new ContainersParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/containers";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ContainersResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ContainersResponse> ContainersAsync()
        {
            return await this.SendJsonAsync<ContainersParameter, ContainersResponse>(ContainersParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainersResponse> ContainersAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ContainersParameter, ContainersResponse>(ContainersParameter.Empty, cancellationToken);
        }
        public async ValueTask<ContainersResponse> ContainersAsync(ContainersParameter parameter)
        {
            return await this.SendJsonAsync<ContainersParameter, ContainersResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainersResponse> ContainersAsync(ContainersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ContainersParameter, ContainersResponse>(parameter, cancellationToken);
        }
    }
}
