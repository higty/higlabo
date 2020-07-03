using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.CodeGenerator
{
    public class CodeBlock
    {
        private Dictionary<SourceCodeLanguage, String> _Codes = new Dictionary<SourceCodeLanguage, String>();
        public Int32 IndentLevel { get; set; }
        public Boolean CurlyBracket { get; set; }
        public List<CodeBlock> CodeBlocks { get; private set; }
        
        public CodeBlock() { }
        public CodeBlock(SourceCodeLanguage language, String code)
            : this(language, 0, code)
        {
        }
        public CodeBlock(SourceCodeLanguage language, String code, params object[] args)
            : this(language, 0, String.Format(code, args))
        {
        }
        public CodeBlock(SourceCodeLanguage language, Int32 indentLevel, String code)
        {
            this._Codes.Add(language, code);
            this.IndentLevel = indentLevel;
            this.CurlyBracket = false;
            this.CodeBlocks = new List<CodeBlock>();
        }
        public CodeBlock(params CodeBlockWithLanguage[] codes)
        {
            foreach (var code in codes)
            {
                _Codes[code.Language] = code.Code;
            }
        }

        public void SetCodeBlock(SourceCodeLanguage language, String code)
        {
            _Codes[language] = code;
        }
        public String GetCodeBlock(SourceCodeLanguage language)
        {
            if (_Codes.ContainsKey(language) == false)
            {
                throw new InvalidOperationException();
            }
            return _Codes[language];
        }
    }
}
