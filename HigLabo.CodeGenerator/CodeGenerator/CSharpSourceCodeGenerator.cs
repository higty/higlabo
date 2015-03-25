using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HigLabo.CodeGenerator
{
    public class CSharpSourceCodeGenerator : SourceCodeGenerator
    {
        private static Dictionary<String, String> Keywords = new Dictionary<string, string>();

        public override SourceCodeLanguage Language
        {
            get { return SourceCodeLanguage.CSharp; }
        }

        static CSharpSourceCodeGenerator()
        {
            InitializeKeywords();
        }
        private static void InitializeKeywords()
        {
            var d = Keywords;

            d["public"] = "@public";
            d["private"] = "@private";
            d["protected"] = "@protected";
            d["static"] = "@static";
            d["this"] = "@this";
            d["class"] = "@class";
            d["property"] = "@property";
            d["void"] = "@void";
            d["int"] = "@int";
            d["long"] = "@long";
            d["params"] = "@params";
        }
        public CSharpSourceCodeGenerator()
            : this(new StringWriter())
        {
        }
        public CSharpSourceCodeGenerator(TextWriter textWriter)
            : base(textWriter)
        {
        }
        public override void Write(TypeName typeName)
        {
            var writer = this.TextWriter;

            writer.Write(typeName.Name);
            if (typeName.GenericTypes.Count > 0)
            {
                writer.Write("<");
                for (int i = 0; i < typeName.GenericTypes.Count; i++)
                {
                    var tp = typeName.GenericTypes[i];
                    this.Write(tp);
                    if (i < typeName.GenericTypes.Count - 1)
                    {
                        writer.Write(", ");
                    }
                }
                writer.Write(">");
            }
        }
        public override void Write(CodeBlock codeBlock)
        {
            var writer = this.TextWriter;

            this.WriteIndent();
            writer.Write(codeBlock.GetCodeBlock(this.Language));
            if (codeBlock.CurlyBracket == true)
            {
                this.WriteLineAndIndent();
                writer.WriteLine("{");
            }
            for (int i = 0; i < codeBlock.CodeBlocks.Count; i++)
            {
                var cb = codeBlock.CodeBlocks[i];
                this.CurrentIndentLevel += (1 + cb.IndentLevel);
                this.Write(cb);
                this.CurrentIndentLevel -= (1 + cb.IndentLevel);
            }
            if (codeBlock.CurlyBracket == true)
            {
                this.WriteIndent();
                writer.WriteLine("}");
            }
            else
            {
                writer.WriteLine();
            }
        }

        public override void Write(AccessModifier modifier)
        {
            var writer = this.TextWriter;

            switch (modifier)
            {
                case AccessModifier.Public: writer.Write("public"); break;
                case AccessModifier.Private: writer.Write("private"); break;
                case AccessModifier.Protected: writer.Write("protected"); break;
                case AccessModifier.Internal: writer.Write("internal"); break;
                case AccessModifier.ProtectedInternal: writer.Write("protected internal"); break;
                default: throw new NotSupportedException();
            }
        }
        public override void Write(MethodAccessModifier modifier)
        {
            var writer = this.TextWriter;

            switch (modifier)
            {
                case MethodAccessModifier.None: break;
                case MethodAccessModifier.Public: writer.Write("public"); break;
                case MethodAccessModifier.Private: writer.Write("private"); break;
                case MethodAccessModifier.Protected: writer.Write("protected"); break;
                case MethodAccessModifier.Internal: writer.Write("internal"); break;
                case MethodAccessModifier.ProtectedInternal: writer.Write("protected internal"); break;
                case MethodAccessModifier.Partial: writer.Write("partial"); break;
                default: throw new NotSupportedException();
            }
        }
  
        public override void Write(FieldModifier modifier)
        {
            var writer = this.TextWriter;

            this.Write(modifier.AccessModifier);
            writer.Write(" ");
            if (modifier.Const == true)
            {
                writer.Write("const ");
                return;
            }

            if (modifier.Static == true)
            {
                writer.Write("static ");
            }
            if (modifier.ReadOnly == true)
            {
                writer.Write("readonly ");
            }
            if (modifier.Volatile == true)
            {
                writer.Write("volatile ");
            }
        }
        public override void Write(Field field)
        {
            var writer = this.TextWriter;

            this.WriteIndent();
            this.Write(field.Modifier);
            this.Write(field.TypeName);
            writer.Write(" ");
            this.WriteElementName(field.Name);
            if (String.IsNullOrWhiteSpace(field.Initializer) == false)
            {
                writer.Write(" = ");
                writer.Write(field.Initializer);
            }
            writer.WriteLine(";");
        }

        public override void Write(ConstructorModifier modifier)
        {
            var writer = this.TextWriter;

            this.Write(modifier.AccessModifier);
            writer.Write(" ");

            if (modifier.Static == true)
            {
                writer.Write("static ");
            }
        }
        public override void Write(Constructor constructor)
        {
            var writer = this.TextWriter;

            this.WriteIndent();
            this.Write(constructor.Modifier);
            this.WriteElementName(constructor.Name);
            if (constructor.GenericParameters.Count > 0)
            {
                writer.Write("<");
                for (int i = 0; i < constructor.GenericParameters.Count; i++)
                {
                    var p = constructor.GenericParameters[i];
                    writer.Write(p);
                    if (i < constructor.GenericParameters.Count - 1)
                    {
                        writer.Write(", ");
                    }
                }
                writer.Write(">");
            }
            writer.Write("(");
            for (int i = 0; i < constructor.Parameters.Count; i++)
            {
                var p = constructor.Parameters[i];
                this.Write(p);
                if (i < constructor.Parameters.Count - 1)
                {
                    writer.Write(", ");
                }
            }
            this.WriteLineAndIndent(")");
            writer.WriteLine("{");
            this.CurrentIndentLevel += 1;
            for (int i = 0; i < constructor.Body.Count; i++)
            {
                var cb = constructor.Body[i];
                this.Write(cb);
            }
            this.CurrentIndentLevel -= 1;
            this.WriteIndent();
            writer.WriteLine("}");
        }

        public override void Write(MethodModifier modifier)
        {
            var writer = this.TextWriter;

            if (modifier.AccessModifier != MethodAccessModifier.None)
            {
                this.Write(modifier.AccessModifier);
                writer.Write(" ");
            }

            if (modifier.Static == true)
            {
                writer.Write("static ");
            }
            else
            {
                switch (modifier.Polymophism)
                {
                    case MethodPolymophism.None: break;
                    case MethodPolymophism.Abstract: writer.Write("abstract "); break;
                    case MethodPolymophism.Virtual: writer.Write("virtual "); break;
                    case MethodPolymophism.Override: writer.Write("override "); break;
                    case MethodPolymophism.New: writer.Write("new "); break;
                    default: throw new InvalidOperationException();
                }
            }
        }
        public override void Write(MethodParameter parameter)
        {
            var writer = this.TextWriter;

            this.Write(parameter.TypeName);
            writer.Write(" ");
            writer.Write(parameter.Name);
        }
        public override void Write(Method method)
        {
            var writer = this.TextWriter;

            this.WriteIndent();
            this.Write(method.Modifier);
            this.Write(method.ReturnTypeName);
            writer.Write(" ");
            this.WriteElementName(method.Name);
            if (method.GenericParameters.Count > 0)
            {
                writer.Write("<");
                for (int i = 0; i < method.GenericParameters.Count; i++)
                {
                    var p = method.GenericParameters[i];
                    writer.Write(p);
                    if (i < method.GenericParameters.Count - 1)
                    {
                        writer.Write(", ");
                    }
                }
                writer.Write(">");
            }
            writer.Write("(");
            for (int i = 0; i < method.Parameters.Count; i++)
            {
                var p = method.Parameters[i];
                this.Write(p);
                if (i < method.Parameters.Count - 1)
                {
                    writer.Write(", ");
                }
            }
            if (method.Modifier.AccessModifier == MethodAccessModifier.Partial ||
                method.Modifier.Polymophism == MethodPolymophism.Abstract)
            {
                writer.WriteLine(");");
                return;
            }
            else
            {
                this.WriteLineAndIndent(")");
            }
            writer.WriteLine("{");
            this.CurrentIndentLevel += 1;
            for (int i = 0; i < method.Body.Count; i++)
            {
                var cb = method.Body[i];
                this.Write(cb);
            }
            this.CurrentIndentLevel -= 1;
            this.WriteIndent();
            writer.WriteLine("}");
        }

        public override void Write(PropertyBody propertyBody)
        {
            var writer = this.TextWriter;

            this.WriteIndent();
            if (propertyBody.Modifier.HasValue == true)
            {
                this.Write(propertyBody.Modifier.Value);
                writer.Write(" ");
            }
            switch (propertyBody.BodyType)
            {
                case PropertyBodyType.Get: writer.Write("get"); break;
                case PropertyBodyType.Set: writer.Write("set"); break;
                default: throw new InvalidOperationException();
            }
            if (propertyBody.IsAutomaticProperty == true)
            {
                writer.WriteLine(";");
                return;
            }

            writer.WriteLine();
            this.WriteIndent();
            writer.WriteLine("{");
            {
                this.CurrentIndentLevel += 1;
                foreach (var item in propertyBody.Body)
                {
                    this.Write(item);
                }
                this.CurrentIndentLevel -= 1;
            }
            this.WriteIndent();
            writer.WriteLine("}");
        }
        public override void Write(Property property)
        {
            var writer = this.TextWriter;

            this.WriteIndent();
            foreach (var item in property.Attributes)
            {
                this.WriteLineAndIndent(item);
            }
            this.Write(property.Modifier);
            this.Write(property.TypeName);
            writer.Write(" ");
            this.WriteElementName(property.Name);
            if (property.Get != null && property.Get.IsAutomaticProperty == true &&
                property.Set != null && property.Set.IsAutomaticProperty == true)
            {
                writer.WriteLine(" { get; set; }");
            }
            else
            {
                writer.WriteLine();
                this.WriteIndent();
                writer.WriteLine("{");
                this.CurrentIndentLevel += 1;
                if (property.Get != null)
                {
                    this.Write(property.Get);
                }
                if (property.Set != null)
                {
                    this.Write(property.Set);
                }
                this.CurrentIndentLevel -= 1;
                this.WriteIndent();
                writer.WriteLine("}");
            }
        }
        
        public override void Write(ClassModifier modifier)
        {
            var writer = this.TextWriter;

            this.Write(modifier.AccessModifier);
            writer.Write(" ");
            if (modifier.Partial == true)
            {
                writer.Write("partial ");
            }

            if (modifier.Static == true)
            {
                writer.Write("static ");
            }
            else if (modifier.Abstract == true)
            {
                writer.Write("abstract ");
            }
        }
        public override void Write(Class @class)
        {
            var writer = this.TextWriter;
            var c = @class;
            Boolean hasElement = false;

            this.WriteIndent();
            this.Write(c.Modifier);
            writer.Write("class ");
            this.WriteElementName(c.Name);
            if (c.BaseClass != null || 
                c.ImplementInterfaces.Count > 0)
            {
                writer.Write(" : ");
                if (c.BaseClass != null)
                {
                    writer.Write(c.BaseClass.Name);
                }
                if (c.ImplementInterfaces.Count > 0)
                {
                    writer.Write(", ");
                    for (int i = 0; i < c.ImplementInterfaces.Count; i++)
                    {
                        writer.Write(c.ImplementInterfaces[i].Name);
                        if (i < c.ImplementInterfaces.Count - 1)
                        {
                            writer.Write(", ");
                        }
                    }
                }
            }
            this.WriteLineAndIndent();
            writer.WriteLine("{");

            hasElement = this.Write(c.Fields, hasElement, this.Write);
            hasElement = this.Write(c.Properties, hasElement, this.Write);
            hasElement = this.Write(c.Constructors, hasElement, this.Write);
            hasElement = this.Write(c.Methods, hasElement, this.Write);
            hasElement = this.Write(c.Interfaces, hasElement, this.Write);
            hasElement = this.Write(c.Classes, hasElement, this.Write);
            hasElement = this.Write(c.Enums, hasElement, this.Write);

            this.WriteIndent();
            writer.WriteLine("}");
        }
        private Boolean Write<T>(List<T> items, Boolean hasElement, Action<T> write)
        {
            var writer = this.TextWriter;

            if (hasElement == true && items.Count > 0)
            {
                writer.WriteLine();
            }
            foreach (T item in items)
            {
                this.CurrentIndentLevel += 1;
                write(item);
                this.CurrentIndentLevel -= 1;
            }
            return hasElement == true || items.Count > 0;
        }

        public override void Write(Enum @enum)
        {
            var writer = this.TextWriter;
            var em = @enum;

            this.WriteIndent();
            this.Write(em.Modifier);
            writer.Write("enum ");
            this.WriteElementName(em.Name);
            if (String.IsNullOrEmpty(em.BaseClass) == false)
            {
                writer.Write(" : ");
                writer.Write(em.BaseClass);
            }

            this.WriteLineAndIndent();
            writer.WriteLine("{");
            foreach (var item in em.Values)
            {
                this.CurrentIndentLevel += 1;
                this.Write(item);
                writer.WriteLine();
                this.CurrentIndentLevel -= 1;
            }
            this.WriteIndent();
            writer.WriteLine("}");
        }
        public override void Write(EnumValue enumValue)
        {
            var writer = this.TextWriter;

            this.WriteIndent();
            writer.Write(enumValue.Text);
            if (enumValue.Value.HasValue)
            {
                writer.Write(" = ");
                writer.Write(enumValue.Value.ToString());
            }
            writer.Write(",");
        }

        public override void Write(InterfaceProperty property)
        {
            var writer = this.TextWriter;

            this.WriteIndent();
            this.Write(property.TypeName);
            writer.Write(" ");
            writer.Write(property.Name);
            writer.Write(" { ");
            if (property.Get == true)
            {
                writer.Write("get; ");
            }
            if (property.Set == true)
            {
                writer.Write("set; ");
            }
            writer.Write("}");
            writer.WriteLine();
        }
        public override void Write(InterfaceMethod method)
        {
            var writer = this.TextWriter;

            this.WriteIndent();
            this.Write(method.ReturnTypeName);
            writer.Write(" ");
            writer.Write(method.Name);
            if (method.GenericParameters.Count > 0)
            {
                writer.Write("<");
                for (int i = 0; i < method.GenericParameters.Count; i++)
                {
                    var p = method.GenericParameters[i];
                    writer.Write(p);
                    if (i < method.GenericParameters.Count - 1)
                    {
                        writer.Write(", ");
                    }
                }
                writer.Write(">");
            }
            writer.Write("(");
            for (int i = 0; i < method.Parameters.Count; i++)
            {
                var p = method.Parameters[i];
                this.Write(p);
                if (i < method.Parameters.Count - 1)
                {
                    writer.Write(", ");
                }
            }
            writer.WriteLine(");");
        }
        public override void Write(Interface @interface)
        {
            var writer = this.TextWriter;
            var c = @interface;
            Boolean hasElement = false;

            this.WriteIndent();
            this.Write(c.Modifier);
            writer.Write(" interface ");
            this.WriteElementName(c.Name);

            this.WriteLineAndIndent();
            writer.WriteLine("{");

            hasElement = this.Write(c.Properties, hasElement, this.Write);
            hasElement = this.Write(c.Methods, hasElement, this.Write);

            this.WriteIndent();
            writer.WriteLine("}");
        }
        
        public override void Write(Namespace @namespace)
        {
            var writer = this.TextWriter;

            writer.Write("namespace ");
            this.WriteElementName(@namespace.Name);
            this.WriteLineAndIndent();
            writer.WriteLine("{");
            this.CurrentIndentLevel += 1;
            foreach (var item in @namespace.Classes)
            {
                this.Write(item);
            }
            this.CurrentIndentLevel -= 1;
            writer.WriteLine("}");
        }

        public override void Write(SourceCode sourceCode)
        {
            var writer = this.TextWriter;
            var sc = sourceCode;

            this.CurrentIndentLevel = 0;
            foreach (var item in sourceCode.UsingNamespaces)
            {
                writer.Write("using ");
                writer.Write(item);
                writer.WriteLine(";");
            }
            writer.WriteLine();
            foreach (var item in sourceCode.Namespaces)
            {
                this.Write(item);
            }
        }

        private void WriteElementName(String value)
        {
            var writer = this.TextWriter;

            if (Keywords.ContainsKey(value) == true)
            {
                writer.Write(Keywords[value]);
            }
            else
            {
                writer.Write(value);
            }
        }
    }
}
