using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get audio transcriptions usage details for the organization.
    /// <seealso href="https://api.openai.com/v1/organization/usage/audio_transcriptions">https://api.openai.com/v1/organization/usage/audio_transcriptions</seealso>
    /// </summary>
    public partial class OrganizationUsageAudioTranscriptionsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationUsageAudioTranscriptionsParameter Empty = new OrganizationUsageAudioTranscriptionsParameter();

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
            return $"/organization/usage/audio_transcriptions";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationUsageAudioTranscriptionsResponse : RestApiDataResponse<List<OrganizationUsageAudioTranscriptionObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUsageAudioTranscriptionsResponse> OrganizationUsageAudioTranscriptionsAsync()
        {
            return await this.SendJsonAsync<OrganizationUsageAudioTranscriptionsParameter, OrganizationUsageAudioTranscriptionsResponse>(OrganizationUsageAudioTranscriptionsParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageAudioTranscriptionsResponse> OrganizationUsageAudioTranscriptionsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageAudioTranscriptionsParameter, OrganizationUsageAudioTranscriptionsResponse>(OrganizationUsageAudioTranscriptionsParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationUsageAudioTranscriptionsResponse> OrganizationUsageAudioTranscriptionsAsync(OrganizationUsageAudioTranscriptionsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUsageAudioTranscriptionsParameter, OrganizationUsageAudioTranscriptionsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageAudioTranscriptionsResponse> OrganizationUsageAudioTranscriptionsAsync(OrganizationUsageAudioTranscriptionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageAudioTranscriptionsParameter, OrganizationUsageAudioTranscriptionsResponse>(parameter, cancellationToken);
        }
    }
}
