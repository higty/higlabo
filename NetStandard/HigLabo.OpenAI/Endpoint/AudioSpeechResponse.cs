using System.IO;

namespace HigLabo.OpenAI
{
	public partial class AudioSpeechResponse
    {
		public Stream? Stream
		{
			get { return ((IRestApiResponse)this).Stream; }
		}
	}
}
