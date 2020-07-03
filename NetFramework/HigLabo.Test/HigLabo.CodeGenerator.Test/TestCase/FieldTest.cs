using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.CodeGenerator;
using System.IO;

namespace HigLaboTest
{
    [TestClass]
    public class FieldTest
    {
        [TestMethod]
        public void FieldBasic1()
        {
            var f = new Field("String", "_name")
            {
                Initializer = "\"Default Name\""
            };
            Assert.AreEqual("private String _name = \"Default Name\";" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, f));
        }
    }
}
