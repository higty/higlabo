using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/drive-list-following?view=graph-rest-1.0
    /// </summary>
    public partial class DriveListFollowingParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Following: return $"/me/drive/following";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Following,
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
    public partial class DriveListFollowingResponse : RestApiResponse<DriveItem>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/drive-list-following?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-list-following?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveListFollowingResponse> DriveListFollowingAsync()
        {
            var p = new DriveListFollowingParameter();
            return await this.SendAsync<DriveListFollowingParameter, DriveListFollowingResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-list-following?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveListFollowingResponse> DriveListFollowingAsync(CancellationToken cancellationToken)
        {
            var p = new DriveListFollowingParameter();
            return await this.SendAsync<DriveListFollowingParameter, DriveListFollowingResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-list-following?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveListFollowingResponse> DriveListFollowingAsync(DriveListFollowingParameter parameter)
        {
            return await this.SendAsync<DriveListFollowingParameter, DriveListFollowingResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-list-following?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveListFollowingResponse> DriveListFollowingAsync(DriveListFollowingParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveListFollowingParameter, DriveListFollowingResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/drive-list-following?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DriveItem> DriveListFollowingEnumerateAsync(DriveListFollowingParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<DriveListFollowingParameter, DriveListFollowingResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DriveItem>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
