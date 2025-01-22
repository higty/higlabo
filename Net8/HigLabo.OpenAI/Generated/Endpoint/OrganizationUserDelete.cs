using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Deletes a user from the organization.
    /// <seealso href="https://api.openai.com/v1/organization/users/{user_id}">https://api.openai.com/v1/organization/users/{user_id}</seealso>
    /// </summary>
    public partial class OrganizationUserDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the user.
        /// </summary>
        public string User_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/users/{User_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationUserDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUserDeleteResponse> OrganizationUserDeleteAsync(string user_Id)
        {
            var p = new OrganizationUserDeleteParameter();
            p.User_Id = user_Id;
            return await this.SendJsonAsync<OrganizationUserDeleteParameter, OrganizationUserDeleteResponse>(p, CancellationToken.None);
        }
        public async ValueTask<OrganizationUserDeleteResponse> OrganizationUserDeleteAsync(string user_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationUserDeleteParameter();
            p.User_Id = user_Id;
            return await this.SendJsonAsync<OrganizationUserDeleteParameter, OrganizationUserDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationUserDeleteResponse> OrganizationUserDeleteAsync(OrganizationUserDeleteParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUserDeleteParameter, OrganizationUserDeleteResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationUserDeleteResponse> OrganizationUserDeleteAsync(OrganizationUserDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUserDeleteParameter, OrganizationUserDeleteResponse>(parameter, cancellationToken);
        }
    }
}
