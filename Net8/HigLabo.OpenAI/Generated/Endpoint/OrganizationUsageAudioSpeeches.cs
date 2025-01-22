using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get audio speeches usage details for the organization.
    /// <seealso href="https://api.openai.com/v1/organization/usage/audio_speeches">https://api.openai.com/v1/organization/usage/audio_speeches</seealso>
    /// </summary>
    public partial class OrganizationUsageAudioSpeechesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationUsageAudioSpeechesParameter Empty = new OrganizationUsageAudioSpeechesParameter();

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
            return $"/organization/usage/audio_speeches";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationUsageAudioSpeechesResponse : RestApiDataResponse<List<OrganizationUsageAudioSpeechObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUsageAudioSpeechesResponse> OrganizationUsageAudioSpeechesAsync()
        {
            return await this.SendJsonAsync<OrganizationUsageAudioSpeechesParameter, OrganizationUsageAudioSpeechesResponse>(OrganizationUsageAudioSpeechesParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageAudioSpeechesResponse> OrganizationUsageAudioSpeechesAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageAudioSpeechesParameter, OrganizationUsageAudioSpeechesResponse>(OrganizationUsageAudioSpeechesParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationUsageAudioSpeechesResponse> OrganizationUsageAudioSpeechesAsync(OrganizationUsageAudioSpeechesParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUsageAudioSpeechesParameter, OrganizationUsageAudioSpeechesResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageAudioSpeechesResponse> OrganizationUsageAudioSpeechesAsync(OrganizationUsageAudioSpeechesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageAudioSpeechesParameter, OrganizationUsageAudioSpeechesResponse>(parameter, cancellationToken);
        }
    }
}
