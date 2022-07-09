using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InferenceclassificationListOverridesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_InferenceClassification_Overrides: return $"/me/inferenceClassification/overrides";
                    case ApiPath.Users_Id_InferenceClassification_Overrides: return $"/users/{Id}/inferenceClassification/overrides";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_InferenceClassification_Overrides,
            Users_Id_InferenceClassification_Overrides,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class InferenceclassificationListOverridesResponse : RestApiResponse
    {
        public InferenceClassificationOverride[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassification-list-overrides?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationListOverridesResponse> InferenceclassificationListOverridesAsync()
        {
            var p = new InferenceclassificationListOverridesParameter();
            return await this.SendAsync<InferenceclassificationListOverridesParameter, InferenceclassificationListOverridesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassification-list-overrides?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationListOverridesResponse> InferenceclassificationListOverridesAsync(CancellationToken cancellationToken)
        {
            var p = new InferenceclassificationListOverridesParameter();
            return await this.SendAsync<InferenceclassificationListOverridesParameter, InferenceclassificationListOverridesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassification-list-overrides?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationListOverridesResponse> InferenceclassificationListOverridesAsync(InferenceclassificationListOverridesParameter parameter)
        {
            return await this.SendAsync<InferenceclassificationListOverridesParameter, InferenceclassificationListOverridesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassification-list-overrides?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationListOverridesResponse> InferenceclassificationListOverridesAsync(InferenceclassificationListOverridesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InferenceclassificationListOverridesParameter, InferenceclassificationListOverridesResponse>(parameter, cancellationToken);
        }
    }
}
