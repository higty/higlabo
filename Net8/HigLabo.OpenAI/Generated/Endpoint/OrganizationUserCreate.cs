using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Modifies a user's role in the organization.
    /// <seealso href="https://api.openai.com/v1/organization/users/{user_id}">https://api.openai.com/v1/organization/users/{user_id}</seealso>
    /// </summary>
    public partial class OrganizationUserCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// owner or reader
        /// </summary>
        public string Role { get; set; } = "";
        public string User_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/users/{User_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	role = this.Role,
            };
        }
    }
    public partial class OrganizationUserCreateResponse : UserObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUserCreateResponse> OrganizationUserCreateAsync(string role)
        {
            var p = new OrganizationUserCreateParameter();
            p.Role = role;
            return await this.SendJsonAsync<OrganizationUserCreateParameter, OrganizationUserCreateResponse>(p, CancellationToken.None);
        }
        public async ValueTask<OrganizationUserCreateResponse> OrganizationUserCreateAsync(string role, CancellationToken cancellationToken)
        {
            var p = new OrganizationUserCreateParameter();
            p.Role = role;
            return await this.SendJsonAsync<OrganizationUserCreateParameter, OrganizationUserCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationUserCreateResponse> OrganizationUserCreateAsync(OrganizationUserCreateParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUserCreateParameter, OrganizationUserCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationUserCreateResponse> OrganizationUserCreateAsync(OrganizationUserCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUserCreateParameter, OrganizationUserCreateResponse>(parameter, cancellationToken);
        }
    }
}
