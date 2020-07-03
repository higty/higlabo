using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HigLabo.CodeGenerator
{
    public abstract class SourceCodeGenerator
    {
        public static String NewLine = "\r\n";
        public static readonly SourceCodeGeneratorDefaultSettings Default = new SourceCodeGeneratorDefaultSettings();

        public String Indent { get; set; }
        public Int32 CurrentIndentLevel { get; set; }
        public TextWriter TextWriter { get; private set; }
        public abstract SourceCodeLanguage Language { get; }

        protected SourceCodeGenerator(TextWriter textWriter)
        {
            this.Indent = Default.Indent;
            this.CurrentIndentLevel = 0;
            this.TextWriter = textWriter;
        }

        public abstract void Write(TypeName typeName);
        public abstract void Write(CodeBlock codeBlock);

        public abstract void Write(AccessModifier modifier);
        public abstract void Write(MethodAccessModifier modifier);
        public abstract void Write(FieldModifier modifier);
        public abstract void Write(Field field);

        public abstract void Write(ConstructorModifier modifier);
        public abstract void Write(Constructor constructor);
        
        public abstract void Write(MethodModifier modifier);
        public abstract void Write(MethodParameter parameter);
        public abstract void Write(Method method);
        
        public abstract void Write(PropertyBody propertyBody);
        public abstract void Write(Property property);

        public abstract void Write(ClassModifier modifier);
        public abstract void Write(Class @class);

        public abstract void Write(Enum @enum);
        public abstract void Write(EnumValue enumValue);

        public abstract void Write(InterfaceProperty property);
        public abstract void Write(InterfaceMethod method);
        public abstract void Write(Interface @interface);
        
        public abstract void Write(Namespace @namespace);
        public abstract void Write(SourceCode sourceCode);

        public static SourceCodeGenerator Create(SourceCodeLanguage language)
        {
            var sw = new StringWriter();
            switch (language)
            {
                case SourceCodeLanguage.CSharp: return new CSharpSourceCodeGenerator(sw);
                case SourceCodeLanguage.VB: return new VisualBasicSourceCodeGenerator(sw);
                default: throw new InvalidOperationException();
            }
        }

        public static String Write(SourceCodeLanguage language, TypeName typeName)
        {
            var sc = Create(language);
            sc.Write(typeName);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, CodeBlock codeBlock)
        {
            var sc = Create(language);
            sc.Write(codeBlock);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, AccessModifier modifier)
        {
            var sc = Create(language);
            sc.Write(modifier);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, MethodAccessModifier modifier)
        {
            var sc = Create(language);
            sc.Write(modifier);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, FieldModifier modifier)
        {
            var sc = Create(language);
            sc.Write(modifier);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, Field field)
        {
            var sc = Create(language);
            sc.Write(field);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, ConstructorModifier modifier)
        {
            var sc = Create(language);
            sc.Write(modifier);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, Constructor constructor)
        {
            var sc = Create(language);
            sc.Write(constructor);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, MethodModifier modifier)
        {
            var sc = Create(language);
            sc.Write(modifier);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, MethodParameter parameter)
        {
            var sc = Create(language);
            sc.Write(parameter);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, Method method)
        {
            var sc = Create(language);
            sc.Write(method);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, PropertyBody propertyBody)
        {
            var sc = Create(language);
            sc.Write(propertyBody);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, Property property)
        {
            var sc = Create(language);
            sc.Write(property);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, ClassModifier modifier)
        {
            var sc = Create(language);
            sc.Write(modifier);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, Class @class)
        {
            var sc = Create(language);
            sc.Write(@class);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, InterfaceProperty property)
        {
            var sc = Create(language);
            sc.Write(property);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, InterfaceMethod method)
        {
            var sc = Create(language);
            sc.Write(method);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, Interface @interface)
        {
            var sc = Create(language);
            sc.Write(@interface);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, Namespace @namespace)
        {
            var sc = Create(language);
            sc.Write(@namespace);
            return sc.TextWriter.ToString();
        }
        public static String Write(SourceCodeLanguage language, SourceCode sourceCode)
        {
            var sc = Create(language);
            sc.Write(sourceCode);
            return sc.TextWriter.ToString();
        }

        protected void WriteIndent()
        {
            for (int i = 0; i < this.CurrentIndentLevel; i++)
            {
                this.TextWriter.Write(this.Indent);
            }
        }
        protected void WriteLineAndIndent()
        {
            this.WriteLineAndIndent("");
        }
        protected void WriteLineAndIndent(String text)
        {
            this.TextWriter.WriteLine(text);
            for (int i = 0; i < this.CurrentIndentLevel; i++)
            {
                this.TextWriter.Write(this.Indent);
            }
        }

        public void Flush()
        {
            this.TextWriter.Flush();
        }

        public override string ToString()
        {
            return this.TextWriter.ToString();
        }
    }
}
