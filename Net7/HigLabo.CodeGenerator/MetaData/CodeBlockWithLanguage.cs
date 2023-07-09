using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class CodeBlockWithLanguage
    {
        public SourceCodeLanguage Language { get; set; }
        public String Code { get; set; }

        public CodeBlockWithLanguage(SourceCodeLanguage language, String code)
        {
            this.Language = language;
            this.Code = code;
        }
        public CodeBlockWithLanguage(SourceCodeLanguage language, String code, params object[] args)
            : this(language, String.Format(code, args))
        {
        }
    }
}
