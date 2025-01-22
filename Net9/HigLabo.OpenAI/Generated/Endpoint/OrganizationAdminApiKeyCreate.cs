using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create an organization admin API key
    /// <seealso href="https://api.openai.com/v1/organization/admin_api_keys">https://api.openai.com/v1/organization/admin_api_keys</seealso>
    /// </summary>
    public partial class OrganizationAdminApiKeyCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Name { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/admin_api_keys";
        }
        public override object GetRequestBody()
        {
            return new {
            	name = this.Name,
            };
        }
    }
    public partial class OrganizationAdminApiKeyCreateResponse : AdminApiKeyObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationAdminApiKeyCreateResponse> OrganizationAdminApiKeyCreateAsync(string name)
        {
            var p = new OrganizationAdminApiKeyCreateParameter();
            p.Name = name;
            return await this.SendJsonAsync<OrganizationAdminApiKeyCreateParameter, OrganizationAdminApiKeyCreateResponse>(p, CancellationToken.None);
        }
        public async ValueTask<OrganizationAdminApiKeyCreateResponse> OrganizationAdminApiKeyCreateAsync(string name, CancellationToken cancellationToken)
        {
            var p = new OrganizationAdminApiKeyCreateParameter();
            p.Name = name;
            return await this.SendJsonAsync<OrganizationAdminApiKeyCreateParameter, OrganizationAdminApiKeyCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationAdminApiKeyCreateResponse> OrganizationAdminApiKeyCreateAsync(OrganizationAdminApiKeyCreateParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationAdminApiKeyCreateParameter, OrganizationAdminApiKeyCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationAdminApiKeyCreateResponse> OrganizationAdminApiKeyCreateAsync(OrganizationAdminApiKeyCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationAdminApiKeyCreateParameter, OrganizationAdminApiKeyCreateResponse>(parameter, cancellationToken);
        }
    }
}
