using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public partial class AudioTranscriptionsParameter
    {
        public void SetResponseFormat(TranslationResponseFormat responseFormat)
        {
            this.Response_Format = responseFormat.ToStringFromEnum().ToLower();
        }
    }
}
