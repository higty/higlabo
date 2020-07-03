using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.CodeGenerator;
using System.IO;

namespace HigLaboTest
{
    [TestClass]
    public class ConstructorTest
    {
        [TestMethod]
        public void ConstructorBasicFeature()
        {
            var md = new Constructor(AccessModifier.Public, "BigNumber");
            md.Body.Add(SourceCodeLanguage.CSharp, "this.Value = 123;");

            Assert.AreEqual("public BigNumber()" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + SourceCodeGenerator.Default.Indent + "this.Value = 123;" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine, SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, md));
        }
        [TestMethod]
        public void ConstructorParameters()
        {
            var md = new Constructor(AccessModifier.Public, "Person");
            md.Parameters.Add(new MethodParameter("String", "name"));
            md.Parameters.Add(new MethodParameter("Int32", "age"));
            md.Body.Add(SourceCodeLanguage.CSharp, "this.DisplayName = name + \":\" + age.ToString();");

            Assert.AreEqual("public Person(String name, Int32 age)" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + SourceCodeGenerator.Default.Indent + "this.DisplayName = name + \":\" + age.ToString();" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine, SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, md));
        }
        [TestMethod]
        public void ConstructorGenericParameters()
        {
            var md = new Constructor(AccessModifier.Public, "Person");
            md.AddParameter("String", "name");
            md.AddParameter("Int32", "age");
            md.GenericParameters.Add("T1");
            md.GenericParameters.Add("T2");
            md.Body.Add(SourceCodeLanguage.CSharp, "this.Value = name + \":\" + age.ToString();");

            Assert.AreEqual("public Person<T1, T2>(String name, Int32 age)" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + SourceCodeGenerator.Default.Indent + "this.Value = name + \":\" + age.ToString();" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine, SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, md));
        }
    }
}
