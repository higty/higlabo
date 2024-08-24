using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
    /// </summary>
    public partial class SubjectrightsRequestListNotesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SubjectRightsRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Privacy_SubjectRightsRequests_SubjectRightsRequestId_Notes: return $"/privacy/subjectRightsRequests/{SubjectRightsRequestId}/notes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Privacy_SubjectRightsRequests_SubjectRightsRequestId_Notes,
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
    public partial class SubjectrightsRequestListNotesResponse : RestApiResponse<AuthoredNote>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsRequestListNotesResponse> SubjectrightsRequestListNotesAsync()
        {
            var p = new SubjectrightsRequestListNotesParameter();
            return await this.SendAsync<SubjectrightsRequestListNotesParameter, SubjectrightsRequestListNotesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsRequestListNotesResponse> SubjectrightsRequestListNotesAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsRequestListNotesParameter();
            return await this.SendAsync<SubjectrightsRequestListNotesParameter, SubjectrightsRequestListNotesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsRequestListNotesResponse> SubjectrightsRequestListNotesAsync(SubjectrightsRequestListNotesParameter parameter)
        {
            return await this.SendAsync<SubjectrightsRequestListNotesParameter, SubjectrightsRequestListNotesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsRequestListNotesResponse> SubjectrightsRequestListNotesAsync(SubjectrightsRequestListNotesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsRequestListNotesParameter, SubjectrightsRequestListNotesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AuthoredNote> SubjectrightsRequestListNotesEnumerateAsync(SubjectrightsRequestListNotesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SubjectrightsRequestListNotesParameter, SubjectrightsRequestListNotesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AuthoredNote>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
