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
        public OrganizationProjectsQueryParameter QueryParameter { get; set; } = new OrganizationProjectsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class OrganizationProjectsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// If true returns all projects including those that have been archived. Archived projects are not included by default.
        /// </summary>
        public bool? Include_Archived { get; set; }
        /// <summary>
        /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.
        /// </summary>
        public int? Limit { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Include_Archived != null)
            {
                sb.Append($"include_archived={this.Include_Archived}&");
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class OrganizationProjectsResponse : RestApiDataResponse<List<ProjectObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectsResponse> OrganizationProjectsAsync()
        {
            return await this.SendJsonAsync<OrganizationProjectsParameter, OrganizationProjectsResponse>(OrganizationProjectsParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectsResponse> OrganizationProjectsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectsParameter, OrganizationProjectsResponse>(OrganizationProjectsParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationProjectsResponse> OrganizationProjectsAsync(OrganizationProjectsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectsParameter, OrganizationProjectsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectsResponse> OrganizationProjectsAsync(OrganizationProjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectsParameter, OrganizationProjectsResponse>(parameter, cancellationToken);
        }
    }
}
