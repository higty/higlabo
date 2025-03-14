using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get completions usage details for the organization.
    /// <seealso href="https://api.openai.com/v1/organization/usage/completions">https://api.openai.com/v1/organization/usage/completions</seealso>
    /// </summary>
    public partial class OrganizationUsageCompletionsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationUsageCompletionsParameter Empty = new OrganizationUsageCompletionsParameter();

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
            return $"/organization/usage/completions";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationUsageCompletionsResponse : RestApiDataResponse<List<OrganizationUsageCompletionObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUsageCompletionsResponse> OrganizationUsageCompletionsAsync()
        {
            return await this.SendJsonAsync<OrganizationUsageCompletionsParameter, OrganizationUsageCompletionsResponse>(OrganizationUsageCompletionsParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageCompletionsResponse> OrganizationUsageCompletionsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageCompletionsParameter, OrganizationUsageCompletionsResponse>(OrganizationUsageCompletionsParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationUsageCompletionsResponse> OrganizationUsageCompletionsAsync(OrganizationUsageCompletionsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUsageCompletionsParameter, OrganizationUsageCompletionsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageCompletionsResponse> OrganizationUsageCompletionsAsync(OrganizationUsageCompletionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageCompletionsParameter, OrganizationUsageCompletionsResponse>(parameter, cancellationToken);
        }
    }
}
