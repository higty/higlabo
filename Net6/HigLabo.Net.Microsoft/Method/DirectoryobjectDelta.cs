using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryobjectDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DirectoryObjects_Delta: return $"/directoryObjects/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DeletedDateTime,
            Id,
        }
        public enum ApiPath
        {
            DirectoryObjects_Delta,
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
    public partial class DirectoryobjectDeltaResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectDeltaResponse> DirectoryobjectDeltaAsync()
        {
            var p = new DirectoryobjectDeltaParameter();
            return await this.SendAsync<DirectoryobjectDeltaParameter, DirectoryobjectDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectDeltaResponse> DirectoryobjectDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryobjectDeltaParameter();
            return await this.SendAsync<DirectoryobjectDeltaParameter, DirectoryobjectDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectDeltaResponse> DirectoryobjectDeltaAsync(DirectoryobjectDeltaParameter parameter)
        {
            return await this.SendAsync<DirectoryobjectDeltaParameter, DirectoryobjectDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectDeltaResponse> DirectoryobjectDeltaAsync(DirectoryobjectDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryobjectDeltaParameter, DirectoryobjectDeltaResponse>(parameter, cancellationToken);
        }
    }
}
