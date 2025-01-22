using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of projects.
    /// <seealso href="https://api.openai.com/v1/organization/projects">https://api.openai.com/v1/organization/projects</seealso>
    /// </summary>
    public partial class OrganizationProjectsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationProjectsParameter Empty = new OrganizationProjectsParameter();

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
            return $"/organization/projects";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationProjectsResponse : RestApiDataResponse<List<ProjectObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectsResponse> OrganizationProjectsAsync()
        {
            return await this.SendJsonAsync<OrganizationProjectsParameter, OrganizationProjectsResponse>(OrganizationProjectsParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectsResponse> OrganizationProjectsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectsParameter, OrganizationProjectsResponse>(OrganizationProjectsParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationProjectsResponse> OrganizationProjectsAsync(OrganizationProjectsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectsParameter, OrganizationProjectsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectsResponse> OrganizationProjectsAsync(OrganizationProjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectsParameter, OrganizationProjectsResponse>(parameter, cancellationToken);
        }
    }
}
