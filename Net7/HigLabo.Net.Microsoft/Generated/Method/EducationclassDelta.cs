using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
    /// </summary>
    public partial class EducationclassDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Delta: return $"/education/classes/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ClassCode,
            CreatedBy,
            Description,
            DisplayName,
            ExternalId,
            ExternalSource,
            ExternalSourceDetail,
            ExternalName,
            Grade,
            Id,
            MailNickname,
            Term,
            Assignments,
            AssignmentCategories,
            AssignmentDefaults,
            AssignmentSettings,
            Group,
            Members,
            Schools,
            Teachers,
        }
        public enum ApiPath
        {
            Education_Classes_Delta,
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
    public partial class EducationclassDeltaResponse : RestApiResponse
    {
        public EducationClass[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassDeltaResponse> EducationclassDeltaAsync()
        {
            var p = new EducationclassDeltaParameter();
            return await this.SendAsync<EducationclassDeltaParameter, EducationclassDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassDeltaResponse> EducationclassDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassDeltaParameter();
            return await this.SendAsync<EducationclassDeltaParameter, EducationclassDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassDeltaResponse> EducationclassDeltaAsync(EducationclassDeltaParameter parameter)
        {
            return await this.SendAsync<EducationclassDeltaParameter, EducationclassDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassDeltaResponse> EducationclassDeltaAsync(EducationclassDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassDeltaParameter, EducationclassDeltaResponse>(parameter, cancellationToken);
        }
    }
}
