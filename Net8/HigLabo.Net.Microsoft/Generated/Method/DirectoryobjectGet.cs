using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-get?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryobjectGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DirectoryObjects_Id: return $"/directoryObjects/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            DirectoryObjects_Id,
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
    public partial class DirectoryobjectGetResponse : RestApiResponse
    {
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryobjectGetResponse> DirectoryobjectGetAsync()
        {
            var p = new DirectoryobjectGetParameter();
            return await this.SendAsync<DirectoryobjectGetParameter, DirectoryobjectGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryobjectGetResponse> DirectoryobjectGetAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryobjectGetParameter();
            return await this.SendAsync<DirectoryobjectGetParameter, DirectoryobjectGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryobjectGetResponse> DirectoryobjectGetAsync(DirectoryobjectGetParameter parameter)
        {
            return await this.SendAsync<DirectoryobjectGetParameter, DirectoryobjectGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryobjectGetResponse> DirectoryobjectGetAsync(DirectoryobjectGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryobjectGetParameter, DirectoryobjectGetResponse>(parameter, cancellationToken);
        }
    }
}
