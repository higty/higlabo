using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class CodeBlockCollection : List<CodeBlock>
    {
        public CodeBlock Add(SourceCodeLanguage language, String code)
        {
            var cb = new CodeBlock(language, 1, code);
            this.Add(cb);
            return cb;
        }
        public CodeBlock Add(SourceCodeLanguage language, String code, params Object[] args)
        {
            var cb = new CodeBlock(language, code, args);
            cb.IndentLevel = 1;
            this.Add(cb);
            return cb;
        }
    }
}
