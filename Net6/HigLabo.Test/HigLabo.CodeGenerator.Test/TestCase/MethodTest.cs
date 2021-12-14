using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.CodeGenerator;
using System.IO;

namespace HigLaboTest
{
    [TestClass]
    public class MethodTest
    {
        [TestMethod]
        public void MethodBasicFeature()
        {
            var md = new Method(MethodAccessModifier.Public, "GetNumber");
            md.Body.Add(SourceCodeLanguage.CSharp, "return 123;");

            Assert.AreEqual("public void GetNumber()" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + SourceCodeGenerator.Default.Indent + "return 123;" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, md));
        }
        [TestMethod]
        public void MethodParameters()
        {
            var md = new Method(MethodAccessModifier.Public, "GetDisplayName");
            md.Parameters.Add(new MethodParameter("String", "name"));
            md.Parameters.Add(new MethodParameter("Int32", "age"));
            md.Body.Add(SourceCodeLanguage.CSharp, "return name + \":\" + age.ToString();");

            Assert.AreEqual("public void GetDisplayName(String name, Int32 age)" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + SourceCodeGenerator.Default.Indent + "return name + \":\" + age.ToString();" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, md));
        }
        [TestMethod]
        public void MethodGenericParameters()
        {
            var md = new Method(MethodAccessModifier.Public, "GetDisplayName");
            md.AddParameter("String", "name");
            md.AddParameter("Int32", "age");
            md.GenericParameters.Add("T1");
            md.GenericParameters.Add("T2");
            md.Body.Add(SourceCodeLanguage.CSharp, "return name + \":\" + age.ToString();");

            Assert.AreEqual("public void GetDisplayName<T1, T2>(String name, Int32 age)" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + SourceCodeGenerator.Default.Indent + "return name + \":\" + age.ToString();" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, md));
        }
        [TestMethod]
        public void MethodPartialFeature()
        {
            var md = new Method(MethodAccessModifier.Partial, "GetNumber");
            //These will be ignored
            md.Parameters.Add(new MethodParameter("Int32", "number"));
            md.GenericParameters.Add("T");
            md.ReturnTypeName = new TypeName("void");
            md.Body.Add(SourceCodeLanguage.CSharp, "return 123;");

            Assert.AreEqual("partial void GetNumber<T>(Int32 number);" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, md));
        }
    }
}
