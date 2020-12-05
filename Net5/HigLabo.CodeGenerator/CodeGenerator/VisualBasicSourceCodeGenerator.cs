using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HigLabo.CodeGenerator
{
    public class VisualBasicSourceCodeGenerator: SourceCodeGenerator
    {
        public override SourceCodeLanguage Language
        {
            get { return SourceCodeLanguage.VB; }
        }

        public VisualBasicSourceCodeGenerator()
            : this(new StringWriter())
        {
        }
        public VisualBasicSourceCodeGenerator(TextWriter textWriter)
            : base(textWriter)
        {
        }
        public override void Write(TypeName typeName)
        {
            var writer = this.TextWriter;

            writer.Write(typeName.Name);
            if (typeName.GenericTypes.Count > 0)
            {
                writer.Write("(Of ");
                for (int i = 0; i < typeName.GenericTypes.Count; i++)
                {
                    var tp = typeName.GenericTypes[i];
                    this.Write(tp);
                    if (i < typeName.GenericTypes.Count - 1)
                    {
                        writer.Write(", ");
                    }
                }
                writer.Write(")");
            }
        }
        public override void Write(CodeBlock codeBlock)
        {
            throw new NotImplementedException();
        }

        public override void Write(AccessModifier modifier)
        {
            var writer = this.TextWriter;

            switch (modifier)
            {
                case AccessModifier.Public: writer.Write("Public"); break;
                case AccessModifier.Private: writer.Write("Private"); break;
                case AccessModifier.Protected: writer.Write("Protected"); break;
                case AccessModifier.Internal: writer.Write("Internal"); break;
                case AccessModifier.ProtectedInternal: writer.Write("Protected Internal"); break;
                default: throw new NotSupportedException();
            }
        }
        public override void Write(MethodAccessModifier modifier)
        {
            var writer = this.TextWriter;

            switch (modifier)
            {
                case MethodAccessModifier.Public: writer.Write("Public"); break;
                case MethodAccessModifier.Private: writer.Write("Private"); break;
                case MethodAccessModifier.Protected: writer.Write("Protected"); break;
                case MethodAccessModifier.Internal: writer.Write("Internal"); break;
                case MethodAccessModifier.ProtectedInternal: writer.Write("Protected Internal"); break;
                case MethodAccessModifier.Partial: writer.Write("Partial"); break;
                default: throw new NotSupportedException();
            }
        }

        public override void Write(FieldModifier modifier)
        {
            throw new NotImplementedException();
        }
        public override void Write(Field field)
        {
            throw new NotImplementedException();
        }

        public override void Write(ConstructorModifier modifier)
        {
            throw new NotImplementedException();
        }
        public override void Write(Constructor constructor)
        {
            throw new NotImplementedException();
        }

        public override void Write(MethodModifier modifier)
        {
            throw new NotImplementedException();
        }
        public override void Write(MethodParameter parameter)
        {
            throw new NotImplementedException();
        }
        public override void Write(Method method)
        {
            throw new NotImplementedException();
        }
        
        public override void Write(PropertyBody propertyBody)
        {
            throw new NotImplementedException();
        }
        public override void Write(Property property)
        {
            throw new NotImplementedException();
        }
        
        public override void Write(ClassModifier modifier)
        {
            throw new NotImplementedException();
        }
        public override void Write(Class @class)
        {
            throw new NotImplementedException();
        }

        public override void Write(Enum @enum)
        {
            throw new NotImplementedException();
        }
        public override void Write(EnumValue enumValue)
        {
            throw new NotImplementedException();
        }

        public override void Write(InterfaceProperty property)
        {
            throw new NotImplementedException();
        }
        public override void Write(InterfaceMethod method)
        {
            throw new NotImplementedException();
        }
        public override void Write(Interface @interface)
        {
            throw new NotImplementedException();
        }
        
        public override void Write(Namespace @namespace)
        {
            throw new NotImplementedException();
        }
        public override void Write(SourceCode sourceCode)
        {
            throw new NotImplementedException();
        }
    }
}
