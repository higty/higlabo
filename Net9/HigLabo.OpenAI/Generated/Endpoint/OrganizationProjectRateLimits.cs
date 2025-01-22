using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns the rate limits per model for a project.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/rate_limits">https://api.openai.com/v1/organization/projects/{project_id}/rate_limits</seealso>
    /// </summary>
    public partial class OrganizationProjectRateLimitsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";
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
            return $"/organization/projects/{Project_Id}/rate_limits";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationProjectRateLimitsResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectRateLimitsResponse> OrganizationProjectRateLimitsAsync(string project_Id)
        {
            var p = new OrganizationProjectRateLimitsParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectRateLimitsParameter, OrganizationProjectRateLimitsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectRateLimitsResponse> OrganizationProjectRateLimitsAsync(string project_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectRateLimitsParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectRateLimitsParameter, OrganizationProjectRateLimitsResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectRateLimitsResponse> OrganizationProjectRateLimitsAsync(OrganizationProjectRateLimitsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectRateLimitsParameter, OrganizationProjectRateLimitsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectRateLimitsResponse> OrganizationProjectRateLimitsAsync(OrganizationProjectRateLimitsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectRateLimitsParameter, OrganizationProjectRateLimitsResponse>(parameter, cancellationToken);
        }
    }
}
