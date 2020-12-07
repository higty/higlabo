using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.CodeGenerator;
using System.IO;

namespace HigLaboTest
{
    [TestClass]
    public class InterfacePropertyTest
    {
        [TestMethod]
        public void InterfacePropertyBasicFeature()
        {
            var p = new InterfaceProperty(new TypeName("String"), "DisplayName", true, true);

            Assert.AreEqual("String DisplayName { get; set; }" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, p));
        }
        [TestMethod]
        public void InterfacePropertyGetFeature()
        {
            var p = new InterfaceProperty(new TypeName("String"), "DisplayName", true, false);

            Assert.AreEqual("String DisplayName { get; }" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, p));
        }
    }
}
