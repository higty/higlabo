using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public partial class FileUploadParameter
    {
        public void SetPurpose(FilePurpose purpose)
        {
            this.Purpose = purpose.GetValue();
        }

    }
}
