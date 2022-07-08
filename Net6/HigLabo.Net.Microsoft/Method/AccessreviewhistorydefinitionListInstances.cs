using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewhistorydefinitionListInstancesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string AccessReviewHistoryDefinitionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_HistoryDefinitions_AccessReviewHistoryDefinitionId_Instances: return $"/identityGovernance/accessReviews/historyDefinitions/{AccessReviewHistoryDefinitionId}/instances";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DownloadUri,
            ExpirationDateTime,
            FulfilledDateTime,
            Id,
            ReviewHistoryPeriodEndDateTime,
            ReviewHistoryPeriodStartDateTime,
            RunDateTime,
            Status,
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_HistoryDefinitions_AccessReviewHistoryDefinitionId_Instances,
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
    public partial class AccessreviewhistorydefinitionListInstancesResponse : RestApiResponse
    {
        public AccessReviewHistoryInstance[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewhistorydefinitionListInstancesResponse> AccessreviewhistorydefinitionListInstancesAsync()
        {
            var p = new AccessreviewhistorydefinitionListInstancesParameter();
            return await this.SendAsync<AccessreviewhistorydefinitionListInstancesParameter, AccessreviewhistorydefinitionListInstancesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewhistorydefinitionListInstancesResponse> AccessreviewhistorydefinitionListInstancesAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewhistorydefinitionListInstancesParameter();
            return await this.SendAsync<AccessreviewhistorydefinitionListInstancesParameter, AccessreviewhistorydefinitionListInstancesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewhistorydefinitionListInstancesResponse> AccessreviewhistorydefinitionListInstancesAsync(AccessreviewhistorydefinitionListInstancesParameter parameter)
        {
            return await this.SendAsync<AccessreviewhistorydefinitionListInstancesParameter, AccessreviewhistorydefinitionListInstancesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewhistorydefinitionListInstancesResponse> AccessreviewhistorydefinitionListInstancesAsync(AccessreviewhistorydefinitionListInstancesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewhistorydefinitionListInstancesParameter, AccessreviewhistorydefinitionListInstancesResponse>(parameter, cancellationToken);
        }
    }
}
