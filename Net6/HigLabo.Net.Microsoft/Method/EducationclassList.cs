using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationclassListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes: return $"/education/classes";
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Groups: return $"/ttps://graph.microsoft.com/v1.0/groups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            DisplayName,
            MailNickname,
            Description,
            CreatedBy,
            ClassCode,
            ExternalName,
            ExternalId,
            ExternalSource,
            ExternalSourceDetail,
            Grade,
            Term,
            Assignments,
            Group,
            Members,
            Schools,
            Teachers,
            AssignmentCategories,
            AssignmentDefaults,
            AssignmentSettings,
        }
        public enum ApiPath
        {
            Education_Classes,
            Ttps__Graphmicrosoftcom_V10_Groups,
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
    public partial class EducationclassListResponse : RestApiResponse
    {
        public EducationClass[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-list?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassListResponse> EducationclassListAsync()
        {
            var p = new EducationclassListParameter();
            return await this.SendAsync<EducationclassListParameter, EducationclassListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-list?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassListResponse> EducationclassListAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassListParameter();
            return await this.SendAsync<EducationclassListParameter, EducationclassListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-list?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassListResponse> EducationclassListAsync(EducationclassListParameter parameter)
        {
            return await this.SendAsync<EducationclassListParameter, EducationclassListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-list?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassListResponse> EducationclassListAsync(EducationclassListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassListParameter, EducationclassListResponse>(parameter, cancellationToken);
        }
    }
}
