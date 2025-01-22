using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get code interpreter sessions usage details for the organization.
    /// <seealso href="https://api.openai.com/v1/organization/usage/code_interpreter_sessions">https://api.openai.com/v1/organization/usage/code_interpreter_sessions</seealso>
    /// </summary>
    public partial class OrganizationUsageCodeInterpreterSessionsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationUsageCodeInterpreterSessionsParameter Empty = new OrganizationUsageCodeInterpreterSessionsParameter();

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
            return $"/organization/usage/code_interpreter_sessions";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationUsageCodeInterpreterSessionsResponse : RestApiDataResponse<List<OrganizationUsageCodeInterpreterSessionObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUsageCodeInterpreterSessionsResponse> OrganizationUsageCodeInterpreterSessionsAsync()
        {
            return await this.SendJsonAsync<OrganizationUsageCodeInterpreterSessionsParameter, OrganizationUsageCodeInterpreterSessionsResponse>(OrganizationUsageCodeInterpreterSessionsParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageCodeInterpreterSessionsResponse> OrganizationUsageCodeInterpreterSessionsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageCodeInterpreterSessionsParameter, OrganizationUsageCodeInterpreterSessionsResponse>(OrganizationUsageCodeInterpreterSessionsParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationUsageCodeInterpreterSessionsResponse> OrganizationUsageCodeInterpreterSessionsAsync(OrganizationUsageCodeInterpreterSessionsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUsageCodeInterpreterSessionsParameter, OrganizationUsageCodeInterpreterSessionsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageCodeInterpreterSessionsResponse> OrganizationUsageCodeInterpreterSessionsAsync(OrganizationUsageCodeInterpreterSessionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageCodeInterpreterSessionsParameter, OrganizationUsageCodeInterpreterSessionsResponse>(parameter, cancellationToken);
        }
    }
}
