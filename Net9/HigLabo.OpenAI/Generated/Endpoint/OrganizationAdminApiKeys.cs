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
        public OrganizationAdminApiKeysQueryParameter QueryParameter { get; set; } = new OrganizationAdminApiKeysQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/admin_api_keys";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class OrganizationAdminApiKeysQueryParameter : IQueryParameter
    {
        public string? After { get; set; }
        public int? Limit { get; set; }
        public string? Order { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            if (this.Order != null)
            {
                sb.Append($"order={WebUtility.UrlEncode(this.Order)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class OrganizationAdminApiKeysResponse : RestApiDataResponse<List<AdminApiKeyObject>>
    {
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
