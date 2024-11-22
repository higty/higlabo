using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

/// <summary>
/// Adds a Part to an Upload object. A Part represents a chunk of bytes from the file you are trying to upload.
/// Each Part can be at most 64 MB, and you can add Parts until you hit the Upload maximum of 8 GB.
/// It is possible to add multiple Parts in parallel. You can decide the intended order of the Parts when you complete the Upload.
/// <seealso href="https://api.openai.com/v1/uploads/{upload_id}/parts">https://api.openai.com/v1/uploads/{upload_id}/parts</seealso>
/// </summary>
public partial class UploadPartAddParameter : RestApiParameter, IRestApiParameter, IFileParameter, IFormDataParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";
    /// <summary>
    /// The ID of the Upload.
    /// </summary>
    public string Upload_Id { get; set; } = "";
    /// <summary>
    /// The chunk of bytes for this Part.
    /// </summary>
    public FileParameter Data { get; private set; } = new FileParameter("data");

    string IRestApiParameter.GetApiPath()
    {
        return $"/uploads/{Upload_Id}/parts";
    }
    public override object GetRequestBody()
    {
        return new {
        	data = this.Data,
        };
    }
    IEnumerable<FileParameter> IFileParameter.GetFileParameters()
    {
        yield return this.Data;
    }
    Dictionary<string, string> IFormDataParameter.CreateFormDataParameter()
    {
        var d = new Dictionary<string, string>();
        d["upload_id"] = this.Upload_Id;
        return d;
    }
}
public partial class UploadPartAddResponse : UploadPartObjectResponse
{
}
public partial class OpenAIClient
{
    public async ValueTask<UploadPartAddResponse> UploadPartAddAsync(string upload_Id, string dataFileName, Stream dataStream)
    {
        var p = new UploadPartAddParameter();
        p.Upload_Id = upload_Id;
        p.Data.SetFile(dataFileName, dataStream);
        return await this.SendFormDataAsync<UploadPartAddParameter, UploadPartAddResponse>(p, CancellationToken.None);
    }
    public async ValueTask<UploadPartAddResponse> UploadPartAddAsync(string upload_Id, string dataFileName, Stream dataStream, CancellationToken cancellationToken)
    {
        var p = new UploadPartAddParameter();
        p.Upload_Id = upload_Id;
        p.Data.SetFile(dataFileName, dataStream);
        return await this.SendFormDataAsync<UploadPartAddParameter, UploadPartAddResponse>(p, cancellationToken);
    }
    public async ValueTask<UploadPartAddResponse> UploadPartAddAsync(UploadPartAddParameter parameter)
    {
        return await this.SendFormDataAsync<UploadPartAddParameter, UploadPartAddResponse>(parameter, CancellationToken.None);
    }
    public async ValueTask<UploadPartAddResponse> UploadPartAddAsync(UploadPartAddParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendFormDataAsync<UploadPartAddParameter, UploadPartAddResponse>(parameter, cancellationToken);
    }
}
