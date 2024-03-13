using System.IO;

namespace HigLabo.OpenAI
{
	public partial class FileContentGetResponse
	{
		public Stream? Stream
		{
			get { return ((IRestApiResponse)this).Stream; }
		}
	}
}
