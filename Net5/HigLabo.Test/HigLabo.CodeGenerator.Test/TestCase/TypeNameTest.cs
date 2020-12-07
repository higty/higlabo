using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.CodeGenerator;

namespace HigLaboTest
{
    [TestClass]
    public class TypeNameTest
    {
        [TestMethod]
        public void TypeNameWithoutGenericTypes()
        {
            var tp = new TypeName("Int32");
            Assert.AreEqual("Int32", SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, tp));
            Assert.AreEqual("Int32", SourceCodeGenerator.Write(SourceCodeLanguage.VB, tp));
        }
        [TestMethod]
        public void TypeNameWithGenericTypes()
        {
            var tp = new TypeName("Func");
            tp.GenericTypes.Add(new TypeName("String"));
            tp.GenericTypes.Add(new TypeName("Int32"));

            Assert.AreEqual("Func<String, Int32>", SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, tp));
            Assert.AreEqual("Func(Of String, Int32)", SourceCodeGenerator.Write(SourceCodeLanguage.VB, tp));
        }
        [TestMethod]
        public void TypeNameWithNestedGenericTypes()
        {
            var tp = new TypeName("Func");
            tp.GenericTypes.Add(new TypeName("String"));
            var tp1 = new TypeName("Action");
            tp1.GenericTypes.Add(new TypeName("String"));
            tp1.GenericTypes.Add(new TypeName("Int32"));
            tp.GenericTypes.Add(tp1);

            Assert.AreEqual("Func<String, Action<String, Int32>>", SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, tp));
            Assert.AreEqual("Func(Of String, Action(Of String, Int32))", SourceCodeGenerator.Write(SourceCodeLanguage.VB, tp));
        }
    }
}
