using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves a user by their identifier.
    /// <seealso href="https://api.openai.com/v1/organization/users/{user_id}">https://api.openai.com/v1/organization/users/{user_id}</seealso>
    /// </summary>
    public partial class OrganizationUserRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
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
    public partial class OrganizationUserRetrieveResponse : UserObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUserRetrieveResponse> OrganizationUserRetrieveAsync(string user_Id)
        {
            var p = new OrganizationUserRetrieveParameter();
            p.User_Id = user_Id;
            return await this.SendJsonAsync<OrganizationUserRetrieveParameter, OrganizationUserRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUserRetrieveResponse> OrganizationUserRetrieveAsync(string user_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationUserRetrieveParameter();
            p.User_Id = user_Id;
            return await this.SendJsonAsync<OrganizationUserRetrieveParameter, OrganizationUserRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationUserRetrieveResponse> OrganizationUserRetrieveAsync(OrganizationUserRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUserRetrieveParameter, OrganizationUserRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUserRetrieveResponse> OrganizationUserRetrieveAsync(OrganizationUserRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUserRetrieveParameter, OrganizationUserRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
