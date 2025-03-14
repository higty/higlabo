using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete an organization admin API key
    /// <seealso href="https://api.openai.com/v1/organization/admin_api_keys/{key_id}">https://api.openai.com/v1/organization/admin_api_keys/{key_id}</seealso>
    /// </summary>
    public partial class OrganizationAdminApiKeyDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
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
    public partial class OrganizationAdminApiKeyDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationAdminApiKeyDeleteResponse> OrganizationAdminApiKeyDeleteAsync(string key_Id)
        {
            var p = new OrganizationAdminApiKeyDeleteParameter();
            p.Key_Id = key_Id;
            return await this.SendJsonAsync<OrganizationAdminApiKeyDeleteParameter, OrganizationAdminApiKeyDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationAdminApiKeyDeleteResponse> OrganizationAdminApiKeyDeleteAsync(string key_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationAdminApiKeyDeleteParameter();
            p.Key_Id = key_Id;
            return await this.SendJsonAsync<OrganizationAdminApiKeyDeleteParameter, OrganizationAdminApiKeyDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationAdminApiKeyDeleteResponse> OrganizationAdminApiKeyDeleteAsync(OrganizationAdminApiKeyDeleteParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationAdminApiKeyDeleteParameter, OrganizationAdminApiKeyDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationAdminApiKeyDeleteResponse> OrganizationAdminApiKeyDeleteAsync(OrganizationAdminApiKeyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationAdminApiKeyDeleteParameter, OrganizationAdminApiKeyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
