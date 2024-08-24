using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getpstncalls?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsCallrecordGetpstncallsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_CallRecords_GetPstnCalls: return $"/communications/callRecords/getPstnCalls";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Communications_CallRecords_GetPstnCalls,
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
    public partial class CallrecordsCallrecordGetpstncallsResponse : RestApiResponse<CallrecordsPstncalllogrow>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getpstncalls?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getpstncalls?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallrecordsCallrecordGetpstncallsResponse> CallrecordsCallrecordGetpstncallsAsync()
        {
            var p = new CallrecordsCallrecordGetpstncallsParameter();
            return await this.SendAsync<CallrecordsCallrecordGetpstncallsParameter, CallrecordsCallrecordGetpstncallsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getpstncalls?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallrecordsCallrecordGetpstncallsResponse> CallrecordsCallrecordGetpstncallsAsync(CancellationToken cancellationToken)
        {
            var p = new CallrecordsCallrecordGetpstncallsParameter();
            return await this.SendAsync<CallrecordsCallrecordGetpstncallsParameter, CallrecordsCallrecordGetpstncallsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getpstncalls?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallrecordsCallrecordGetpstncallsResponse> CallrecordsCallrecordGetpstncallsAsync(CallrecordsCallrecordGetpstncallsParameter parameter)
        {
            return await this.SendAsync<CallrecordsCallrecordGetpstncallsParameter, CallrecordsCallrecordGetpstncallsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getpstncalls?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallrecordsCallrecordGetpstncallsResponse> CallrecordsCallrecordGetpstncallsAsync(CallrecordsCallrecordGetpstncallsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallrecordsCallrecordGetpstncallsParameter, CallrecordsCallrecordGetpstncallsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/callrecords-callrecord-getpstncalls?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<CallrecordsPstncalllogrow> CallrecordsCallrecordGetpstncallsEnumerateAsync(CallrecordsCallrecordGetpstncallsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<CallrecordsCallrecordGetpstncallsParameter, CallrecordsCallrecordGetpstncallsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<CallrecordsPstncalllogrow>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
