using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.CodeGenerator;
using System.IO;

namespace HigLaboTest
{
    [TestClass]
    public class InterfaceTest
    {
        [TestMethod]
        public void InterfaceBasicFeature()
        {
            var c = new Interface("IPerson");

            var p = new InterfaceProperty("Int32", "Age", true, true);
            c.Properties.Add(p);

            var md = new InterfaceMethod("GetNumber");
            c.Methods.Add(md);

            Assert.AreEqual("public interface IPerson" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + "    Int32 Age { get; set; }" + SourceCodeGenerator.NewLine
                + SourceCodeGenerator.NewLine
                + "    void GetNumber();" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, c));
        }
        [TestMethod]
        public void InterfaceIndent()
        {
            var c = new Interface("IPerson");

            var cs = new CSharpSourceCodeGenerator();
            cs.CurrentIndentLevel = 2;
            cs.Write(c);
            //static prefer
            Assert.AreEqual("        public interface IPerson" + SourceCodeGenerator.NewLine
                + "        {" + SourceCodeGenerator.NewLine
                + "        }" + SourceCodeGenerator.NewLine, cs.ToString());
        }
    }
}
