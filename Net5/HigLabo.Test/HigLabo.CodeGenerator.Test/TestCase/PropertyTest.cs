using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.CodeGenerator;

namespace HigLaboTest
{
    [TestClass]
    public class PropertyTest
    {
        [TestMethod]
        public void PropertyBasicFeature()
        {
            var p = new Property("Int32", "Age");
            p.Get.Body.Add(new CodeBlock(SourceCodeLanguage.CSharp, "return _Age;"));
            p.Set.Body.Add(new CodeBlock(SourceCodeLanguage.CSharp, "_Age = value;"));

            Assert.AreEqual("public Int32 Age" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + "    get" + SourceCodeGenerator.NewLine
                + "    {" + SourceCodeGenerator.NewLine
                + "        return _Age;" + SourceCodeGenerator.NewLine
                + "    }" + SourceCodeGenerator.NewLine
                + "    set" + SourceCodeGenerator.NewLine
                + "    {" + SourceCodeGenerator.NewLine
                + "        _Age = value;" + SourceCodeGenerator.NewLine
                + "    }" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, p));
        }
        [TestMethod]
        public void PropertySetModifierPrivate()
        {
            var p = new Property("Int32", "Age");
            p.Get.Body.Add(new CodeBlock(SourceCodeLanguage.CSharp, "return _Age;"));
            p.Set.Modifier = AccessModifier.Private;
            p.Set.Body.Add(new CodeBlock(SourceCodeLanguage.CSharp, "_Age = value;"));
            var sw = new StringWriter();
            var cs = new CSharpSourceCodeGenerator(sw);
            cs.Write(p);

            Assert.AreEqual("public Int32 Age" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + "    get" + SourceCodeGenerator.NewLine
                + "    {" + SourceCodeGenerator.NewLine
                + "        return _Age;" + SourceCodeGenerator.NewLine
                + "    }" + SourceCodeGenerator.NewLine
                + "    private set" + SourceCodeGenerator.NewLine
                + "    {" + SourceCodeGenerator.NewLine
                + "        _Age = value;" + SourceCodeGenerator.NewLine
                + "    }" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, p));
        }
        [TestMethod]
        public void PropertyGetOnly()
        {
            var p = new Property("Int32", "Age");
            p.Get.Body.Add(new CodeBlock(SourceCodeLanguage.CSharp, "return _Age;"));
            p.Set = null;

            Assert.AreEqual("public Int32 Age" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + "    get" + SourceCodeGenerator.NewLine
                + "    {" + SourceCodeGenerator.NewLine
                + "        return _Age;" + SourceCodeGenerator.NewLine
                + "    }" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, p));
        }
    }
}
