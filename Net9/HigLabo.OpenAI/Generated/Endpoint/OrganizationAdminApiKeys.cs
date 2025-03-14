using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// List organization API keys
    /// <seealso href="https://api.openai.com/v1/organization/admin_api_keys">https://api.openai.com/v1/organization/admin_api_keys</seealso>
    /// </summary>
    public partial class OrganizationAdminApiKeysParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationAdminApiKeysParameter Empty = new OrganizationAdminApiKeysParameter();

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
            return $"/organization/admin_api_keys";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationAdminApiKeysResponse : RestApiDataResponse<List<AdminApiKeyObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationAdminApiKeysResponse> OrganizationAdminApiKeysAsync()
        {
            return await this.SendJsonAsync<OrganizationAdminApiKeysParameter, OrganizationAdminApiKeysResponse>(OrganizationAdminApiKeysParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationAdminApiKeysResponse> OrganizationAdminApiKeysAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationAdminApiKeysParameter, OrganizationAdminApiKeysResponse>(OrganizationAdminApiKeysParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationAdminApiKeysResponse> OrganizationAdminApiKeysAsync(OrganizationAdminApiKeysParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationAdminApiKeysParameter, OrganizationAdminApiKeysResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationAdminApiKeysResponse> OrganizationAdminApiKeysAsync(OrganizationAdminApiKeysParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationAdminApiKeysParameter, OrganizationAdminApiKeysResponse>(parameter, cancellationToken);
        }
    }
}
