using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

	public partial class AudioSpeechResponse
{
		public Stream? Stream
		{
			get { return ((IRestApiResponse)this).Stream; }
		}
	}
