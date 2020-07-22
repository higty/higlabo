using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.CodeGenerator;
using System.IO;

namespace HigLaboTest
{
    [TestClass]
    public class ClassTest
    {
        [TestMethod]
        public void ClassBasicFeature()
        {
            var c = new Class(AccessModifier.Public, "Person");
            var f = new Field("Int32", "_Age");
            c.Fields.Add(f);

            var p = new Property("Int32", "Age");
            p.Get.Body.Add(new CodeBlock(SourceCodeLanguage.CSharp, "return _Age;"));
            p.Set.Body.Add(new CodeBlock(SourceCodeLanguage.CSharp, "_Age = value;"));
            c.Properties.Add(p);

            var md = new Method(MethodAccessModifier.Public, "GetNumber");
            md.Body.Add(SourceCodeLanguage.CSharp, "return 123;");
            c.Methods.Add(md);

            var sw = new StringWriter();
            var cs = new CSharpSourceCodeGenerator(sw);
            cs.Write(c);

            Assert.AreEqual("public class Person" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + "    private Int32 _Age;" + SourceCodeGenerator.NewLine
                + SourceCodeGenerator.NewLine
                + "    public Int32 Age" + SourceCodeGenerator.NewLine
                + "    {" + SourceCodeGenerator.NewLine
                + "        get" + SourceCodeGenerator.NewLine
                + "        {" + SourceCodeGenerator.NewLine
                + "            return _Age;" + SourceCodeGenerator.NewLine
                + "        }" + SourceCodeGenerator.NewLine
                + "        set" + SourceCodeGenerator.NewLine
                + "        {" + SourceCodeGenerator.NewLine
                + "            _Age = value;" + SourceCodeGenerator.NewLine
                + "        }" + SourceCodeGenerator.NewLine
                + "    }" + SourceCodeGenerator.NewLine
                + SourceCodeGenerator.NewLine
                + "    public void GetNumber()" + SourceCodeGenerator.NewLine
                + "    {" + SourceCodeGenerator.NewLine
                + "        return 123;"+ SourceCodeGenerator.NewLine
                + "    }" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , sw.ToString());
        }
        [TestMethod]
        public void ClassLineBreakFeature()
        {
            var c = new Class(AccessModifier.Public, "Person");

            var md = new Method(MethodAccessModifier.Public, "GetNumber");
            md.Body.Add(SourceCodeLanguage.CSharp, "return 123;");
            c.Methods.Add(md);

            Assert.AreEqual("public class Person" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + "    public void GetNumber()" + SourceCodeGenerator.NewLine
                + "    {" + SourceCodeGenerator.NewLine
                + "        return 123;" + SourceCodeGenerator.NewLine
                + "    }" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, c));
        }
        [TestMethod]
        public void ClassInheritance()
        {
            var c = new Class(AccessModifier.Public, "Person");
            c.BaseClass = new TypeName("PersonBase");

            Assert.AreEqual("public class Person : PersonBase" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, c));
        }
        [TestMethod]
        public void ClassInheritanceAndImplement()
        {
            var c = new Class(AccessModifier.Public, "Person");
            c.BaseClass = new TypeName("PersonBase");
            c.ImplementInterfaces.Add(new TypeName("IDisposable"));
            c.ImplementInterfaces.Add(new TypeName("IEnumerable"));

            Assert.AreEqual("public class Person : PersonBase, IDisposable, IEnumerable" + SourceCodeGenerator.NewLine 
                +"{" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, c));
        }
        [TestMethod]
        public void ClassModifierStaticAbstractPriority()
        {
            var c = new Class(AccessModifier.Public, "StringUtility");
            c.Modifier.Static = true;
            c.Modifier.Abstract = true;

            Assert.AreEqual("public static class StringUtility" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, c));
        }
        [TestMethod]
        public void ClassIndent()
        {
            var c = new Class(AccessModifier.Public, "StringUtility");
            c.Modifier.Static = true;
            c.Modifier.Abstract = true;

            CSharpSourceCodeGenerator sc = new CSharpSourceCodeGenerator();
            sc.CurrentIndentLevel = 2;
            sc.Write(c);

            Assert.AreEqual("        public static class StringUtility" + SourceCodeGenerator.NewLine
                + "        {" + SourceCodeGenerator.NewLine
                + "        }" + SourceCodeGenerator.NewLine
                , sc.ToString());
        }
    }
}
