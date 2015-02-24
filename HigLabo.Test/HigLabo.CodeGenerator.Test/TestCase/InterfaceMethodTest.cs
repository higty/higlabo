using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.CodeGenerator;
using System.IO;

namespace HigLaboTest
{
    [TestClass]
    public class InterfaceMethodTest
    {
        [TestMethod]
        public void InterfaceMethodBasicFeature()
        {
            var md = new InterfaceMethod("GetNumber");

            Assert.AreEqual("void GetNumber();" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, md));
        }
        [TestMethod]
        public void InterfaceMethodParameters()
        {
            var md = new InterfaceMethod("GetDisplayName");
            md.Parameters.Add(new MethodParameter("String", "name"));
            md.Parameters.Add(new MethodParameter("Int32", "age"));

            Assert.AreEqual("void GetDisplayName(String name, Int32 age);" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, md));
        }
        [TestMethod]
        public void InterfaceMethodGenericParameters()
        {
            var md = new InterfaceMethod("GetDisplayName");
            md.AddParameter("String", "name");
            md.AddParameter("Int32", "age");
            md.GenericParameters.Add("T1");
            md.GenericParameters.Add("T2");

            Assert.AreEqual("void GetDisplayName<T1, T2>(String name, Int32 age);" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, md));
        }
        [TestMethod]
        public void InterfaceMethodPartialFeature()
        {
            var md = new InterfaceMethod("GetNumber");
            //These will be ignored
            md.Parameters.Add(new MethodParameter("Int32", "number"));
            md.GenericParameters.Add("T");
            md.ReturnTypeName = new TypeName("Int32");

            Assert.AreEqual("Int32 GetNumber<T>(Int32 number);" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, md));
        }
    }
}
