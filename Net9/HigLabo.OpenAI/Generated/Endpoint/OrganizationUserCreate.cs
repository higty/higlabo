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
        /// The ID of the user.
        /// </summary>
        public string User_Id { get; set; } = "";
        /// <summary>
        /// owner or reader
        /// </summary>
        public string Role { get; set; } = "";

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
        public async ValueTask<OrganizationUserCreateResponse> OrganizationUserCreateAsync(string user_Id, string role)
        {
            var p = new OrganizationUserCreateParameter();
            p.User_Id = user_Id;
            p.Role = role;
            return await this.SendJsonAsync<OrganizationUserCreateParameter, OrganizationUserCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUserCreateResponse> OrganizationUserCreateAsync(string user_Id, string role, CancellationToken cancellationToken)
        {
            var p = new OrganizationUserCreateParameter();
            p.User_Id = user_Id;
            p.Role = role;
            return await this.SendJsonAsync<OrganizationUserCreateParameter, OrganizationUserCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationUserCreateResponse> OrganizationUserCreateAsync(OrganizationUserCreateParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUserCreateParameter, OrganizationUserCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUserCreateResponse> OrganizationUserCreateAsync(OrganizationUserCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUserCreateParameter, OrganizationUserCreateResponse>(parameter, cancellationToken);
        }
    }
}
