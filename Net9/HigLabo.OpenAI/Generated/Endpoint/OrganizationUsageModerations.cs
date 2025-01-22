using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get moderations usage details for the organization.
    /// <seealso href="https://api.openai.com/v1/organization/usage/moderations">https://api.openai.com/v1/organization/usage/moderations</seealso>
    /// </summary>
    public partial class OrganizationUsageModerationsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationUsageModerationsParameter Empty = new OrganizationUsageModerationsParameter();

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
            return $"/organization/usage/moderations";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationUsageModerationsResponse : RestApiDataResponse<List<OrganizationUsageModerationObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUsageModerationsResponse> OrganizationUsageModerationsAsync()
        {
            return await this.SendJsonAsync<OrganizationUsageModerationsParameter, OrganizationUsageModerationsResponse>(OrganizationUsageModerationsParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageModerationsResponse> OrganizationUsageModerationsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageModerationsParameter, OrganizationUsageModerationsResponse>(OrganizationUsageModerationsParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationUsageModerationsResponse> OrganizationUsageModerationsAsync(OrganizationUsageModerationsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUsageModerationsParameter, OrganizationUsageModerationsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageModerationsResponse> OrganizationUsageModerationsAsync(OrganizationUsageModerationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageModerationsParameter, OrganizationUsageModerationsResponse>(parameter, cancellationToken);
        }
    }
}
