using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
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
        public OrganizationProjectRateLimitsQueryParameter QueryParameter { get; set; } = new OrganizationProjectRateLimitsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/rate_limits";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class OrganizationProjectRateLimitsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, beginning with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list.
        /// </summary>
        public string? Before { get; set; }
        /// <summary>
        /// A limit on the number of objects to be returned. The default is 100.
        /// </summary>
        public int? Limit { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Before != null)
            {
                sb.Append($"before={WebUtility.UrlEncode(this.Before)}&");
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class OrganizationProjectRateLimitsResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectRateLimitsResponse> OrganizationProjectRateLimitsAsync(string project_Id)
        {
            var p = new OrganizationProjectRateLimitsParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectRateLimitsParameter, OrganizationProjectRateLimitsResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectRateLimitsResponse> OrganizationProjectRateLimitsAsync(string project_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectRateLimitsParameter();
            p.Project_Id = project_Id;
            return await this.SendJsonAsync<OrganizationProjectRateLimitsParameter, OrganizationProjectRateLimitsResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectRateLimitsResponse> OrganizationProjectRateLimitsAsync(OrganizationProjectRateLimitsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectRateLimitsParameter, OrganizationProjectRateLimitsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectRateLimitsResponse> OrganizationProjectRateLimitsAsync(OrganizationProjectRateLimitsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectRateLimitsParameter, OrganizationProjectRateLimitsResponse>(parameter, cancellationToken);
        }
    }
}
