using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
    /// </summary>
    public partial class EducationUserListTaughtClassesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EducationUserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Me_TaughtClasses: return $"/education/me/taughtClasses";
                    case ApiPath.Education_Users_EducationUserId_TaughtClasses: return $"/education/users/{EducationUserId}/taughtClasses";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Me_TaughtClasses,
            Education_Users_EducationUserId_TaughtClasses,
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
    public partial class EducationUserListTaughtClassesResponse : RestApiResponse<EducationClass>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationUserListTaughtClassesResponse> EducationUserListTaughtClassesAsync()
        {
            var p = new EducationUserListTaughtClassesParameter();
            return await this.SendAsync<EducationUserListTaughtClassesParameter, EducationUserListTaughtClassesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationUserListTaughtClassesResponse> EducationUserListTaughtClassesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationUserListTaughtClassesParameter();
            return await this.SendAsync<EducationUserListTaughtClassesParameter, EducationUserListTaughtClassesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationUserListTaughtClassesResponse> EducationUserListTaughtClassesAsync(EducationUserListTaughtClassesParameter parameter)
        {
            return await this.SendAsync<EducationUserListTaughtClassesParameter, EducationUserListTaughtClassesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationUserListTaughtClassesResponse> EducationUserListTaughtClassesAsync(EducationUserListTaughtClassesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationUserListTaughtClassesParameter, EducationUserListTaughtClassesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<EducationClass> EducationUserListTaughtClassesEnumerateAsync(EducationUserListTaughtClassesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<EducationUserListTaughtClassesParameter, EducationUserListTaughtClassesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<EducationClass>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
