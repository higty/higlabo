using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get images usage details for the organization.
    /// <seealso href="https://api.openai.com/v1/organization/usage/images">https://api.openai.com/v1/organization/usage/images</seealso>
    /// </summary>
    public partial class OrganizationUsageImagesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationUsageImagesParameter Empty = new OrganizationUsageImagesParameter();

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
            return $"/organization/usage/images";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationUsageImagesResponse : RestApiDataResponse<List<OrganizationUsageImageObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUsageImagesResponse> OrganizationUsageImagesAsync()
        {
            return await this.SendJsonAsync<OrganizationUsageImagesParameter, OrganizationUsageImagesResponse>(OrganizationUsageImagesParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageImagesResponse> OrganizationUsageImagesAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageImagesParameter, OrganizationUsageImagesResponse>(OrganizationUsageImagesParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationUsageImagesResponse> OrganizationUsageImagesAsync(OrganizationUsageImagesParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUsageImagesParameter, OrganizationUsageImagesResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageImagesResponse> OrganizationUsageImagesAsync(OrganizationUsageImagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageImagesParameter, OrganizationUsageImagesResponse>(parameter, cancellationToken);
        }
    }
}
