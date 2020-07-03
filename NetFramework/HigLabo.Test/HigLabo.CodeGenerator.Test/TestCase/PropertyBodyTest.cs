using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.CodeGenerator;

namespace HigLaboTest
{
    [TestClass]
    public class PropertyBodyTest
    {
        [TestMethod]
        public void TestPropertyBasicFeature()
        {
            var p = new PropertyBody(PropertyBodyType.Get);
            p.Body.Add(new CodeBlock(SourceCodeLanguage.CSharp, "return _Age;"));

            var cs = new CSharpSourceCodeGenerator();
            cs.CurrentIndentLevel = 1;
            cs.Write(p);

            Assert.AreEqual("    get" + SourceCodeGenerator.NewLine
                + "    {" + SourceCodeGenerator.NewLine
                + "        return _Age;" + SourceCodeGenerator.NewLine
                + "    }" + SourceCodeGenerator.NewLine
                , cs.ToString());
        }
        [TestMethod]
        public void TestAutomaticProperty()
        {
            var p = new PropertyBody(PropertyBodyType.Get);
            p.IsAutomaticProperty = true;

            Assert.AreEqual("get;" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, p));
        }
    }
}
