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
    /// Retrieve a single organization API key
    /// <seealso href="https://api.openai.com/v1/organization/admin_api_keys/{key_id}">https://api.openai.com/v1/organization/admin_api_keys/{key_id}</seealso>
    /// </summary>
    public partial class OrganizationAdminApiKeyRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Key_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/admin_api_keys/{Key_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationAdminApiKeyRetrieveResponse : AdminApiKeyObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationAdminApiKeyRetrieveResponse> OrganizationAdminApiKeyRetrieveAsync(string key_Id)
        {
            var p = new OrganizationAdminApiKeyRetrieveParameter();
            p.Key_Id = key_Id;
            return await this.SendJsonAsync<OrganizationAdminApiKeyRetrieveParameter, OrganizationAdminApiKeyRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationAdminApiKeyRetrieveResponse> OrganizationAdminApiKeyRetrieveAsync(string key_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationAdminApiKeyRetrieveParameter();
            p.Key_Id = key_Id;
            return await this.SendJsonAsync<OrganizationAdminApiKeyRetrieveParameter, OrganizationAdminApiKeyRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationAdminApiKeyRetrieveResponse> OrganizationAdminApiKeyRetrieveAsync(OrganizationAdminApiKeyRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationAdminApiKeyRetrieveParameter, OrganizationAdminApiKeyRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationAdminApiKeyRetrieveResponse> OrganizationAdminApiKeyRetrieveAsync(OrganizationAdminApiKeyRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationAdminApiKeyRetrieveParameter, OrganizationAdminApiKeyRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
