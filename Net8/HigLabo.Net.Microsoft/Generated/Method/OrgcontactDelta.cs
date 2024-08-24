using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
    /// </summary>
    public partial class OrgcontactDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Contacts_Delta: return $"/contacts/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Contacts_Delta,
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
    public partial class OrgcontactDeltaResponse : RestApiResponse<OrgContact>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrgcontactDeltaResponse> OrgcontactDeltaAsync()
        {
            var p = new OrgcontactDeltaParameter();
            return await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrgcontactDeltaResponse> OrgcontactDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new OrgcontactDeltaParameter();
            return await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrgcontactDeltaResponse> OrgcontactDeltaAsync(OrgcontactDeltaParameter parameter)
        {
            return await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrgcontactDeltaResponse> OrgcontactDeltaAsync(OrgcontactDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-delta?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<OrgContact> OrgcontactDeltaEnumerateAsync(OrgcontactDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<OrgcontactDeltaParameter, OrgcontactDeltaResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<OrgContact>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
