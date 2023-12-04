using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of files that belong to the user's organization.
    /// <seealso href="https://api.openai.com/v1/files">https://api.openai.com/v1/files</seealso>
    /// </summary>
    public partial class FilesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly FilesParameter Empty = new FilesParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public FileListQueryParameter QueryParameter { get; set; } = new FileListQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/files";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class FilesResponse : RestApiDataResponse<List<FileObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FilesResponse> FilesAsync()
        {
            return await this.SendJsonAsync<FilesParameter, FilesResponse>(FilesParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<FilesResponse> FilesAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FilesParameter, FilesResponse>(FilesParameter.Empty, cancellationToken);
        }
        public async ValueTask<FilesResponse> FilesAsync(FilesParameter parameter)
        {
            return await this.SendJsonAsync<FilesParameter, FilesResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<FilesResponse> FilesAsync(FilesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FilesParameter, FilesResponse>(parameter, cancellationToken);
        }
    }
}
