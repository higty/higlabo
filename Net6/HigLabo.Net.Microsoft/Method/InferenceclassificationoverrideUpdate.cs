using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InferenceclassificationoverrideUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string UsersId { get; set; }
            public string OverridesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_InferenceClassification_Overrides_Id: return $"/me/inferenceClassification/overrides/{Id}";
                    case ApiPath.Users_Id_InferenceClassification_Overrides_Id: return $"/users/{UsersId}/inferenceClassification/overrides/{OverridesId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum InferenceclassificationoverrideUpdateParameterstring
        {
            Focused,
            Other,
        }
        public enum ApiPath
        {
            Me_InferenceClassification_Overrides_Id,
            Users_Id_InferenceClassification_Overrides_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public InferenceclassificationoverrideUpdateParameterstring ClassifyAs { get; set; }
    }
    public partial class InferenceclassificationoverrideUpdateResponse : RestApiResponse
    {
        public enum InferenceClassificationOverrideInferenceClassificationType
        {
            Focused,
            Other,
        }

        public InferenceClassificationOverrideInferenceClassificationType ClassifyAs { get; set; }
        public string? Id { get; set; }
        public EmailAddress? SenderEmailAddress { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassificationoverride-update?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationoverrideUpdateResponse> InferenceclassificationoverrideUpdateAsync()
        {
            var p = new InferenceclassificationoverrideUpdateParameter();
            return await this.SendAsync<InferenceclassificationoverrideUpdateParameter, InferenceclassificationoverrideUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassificationoverride-update?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationoverrideUpdateResponse> InferenceclassificationoverrideUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new InferenceclassificationoverrideUpdateParameter();
            return await this.SendAsync<InferenceclassificationoverrideUpdateParameter, InferenceclassificationoverrideUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassificationoverride-update?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationoverrideUpdateResponse> InferenceclassificationoverrideUpdateAsync(InferenceclassificationoverrideUpdateParameter parameter)
        {
            return await this.SendAsync<InferenceclassificationoverrideUpdateParameter, InferenceclassificationoverrideUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassificationoverride-update?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationoverrideUpdateResponse> InferenceclassificationoverrideUpdateAsync(InferenceclassificationoverrideUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InferenceclassificationoverrideUpdateParameter, InferenceclassificationoverrideUpdateResponse>(parameter, cancellationToken);
        }
    }
}
