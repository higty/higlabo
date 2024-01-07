using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.CodeGenerator;
using System.IO;

namespace HigLaboTest
{
    [TestClass]
    public class SourceCodeTest
    {
        [TestMethod]
        public void SourceCodeBasicFeature()
        {
            var sc = new SourceCode();
            sc.UsingNamespaces.Add("System");
            sc.UsingNamespaces.Add("System.Collection");
            sc.UsingNamespaces.Add("System.Data");
            sc.UsingNamespaces.Add("System.IO");

            Assert.AreEqual("using System;" + SourceCodeGenerator.NewLine
                + "using System.Collection;" + SourceCodeGenerator.NewLine
                + "using System.Data;" + SourceCodeGenerator.NewLine
                + "using System.IO;" + SourceCodeGenerator.NewLine
                + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, sc));
        }
    }
}
