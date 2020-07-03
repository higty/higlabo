using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.CodeGenerator;
using System.IO;

namespace HigLaboTest
{
    [TestClass]
    public class CodeBlockTest
    {
        [TestMethod]
        public void CodeBlockBasicFeature()
        {
            var cb = new CodeBlock(SourceCodeLanguage.CSharp, "Int32 x = 12;");
            Assert.AreEqual("Int32 x = 12;" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, cb));
        }
        [TestMethod]
        public void CodeBlockIfStatement()
        {
            var cb = new CodeBlock(SourceCodeLanguage.CSharp, "if (bl == true)");
            cb.CurlyBracket = true;
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "MessageBox.Show(\"Update successfully!\");"));

            Assert.AreEqual("if (bl == true)" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + "    MessageBox.Show(\"Update successfully!\");" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, cb));
        }
        [TestMethod]
        public void CodeBlockForStatement()
        {
            var cb = new CodeBlock(SourceCodeLanguage.CSharp, "for (int i = 0; i < length; i++)");
            cb.CurlyBracket = true;
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "x = x + 1;"));

            Assert.AreEqual("for (int i = 0; i < length; i++)" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + "    x = x + 1;" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , SourceCodeGenerator.Write(SourceCodeLanguage.CSharp, cb));
        }
        [TestMethod]
        public void CodeBlockIndentIsTwoWhitespace()
        {
            var cb = new CodeBlock(SourceCodeLanguage.CSharp, "if (bl == true)");
            cb.CurlyBracket = true;
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "MessageBox.Show(\"Update successfully!\");"));
      
            var cs = new CSharpSourceCodeGenerator();
            cs.Indent = "  ";
            cs.Write(cb);

            Assert.AreEqual("if (bl == true)" + SourceCodeGenerator.NewLine
                + "{" + SourceCodeGenerator.NewLine
                + "  MessageBox.Show(\"Update successfully!\");" + SourceCodeGenerator.NewLine
                + "}" + SourceCodeGenerator.NewLine
                , cs.ToString());
        }
        [TestMethod]
        public void CodeBlockBracket()
        {
            var cb = new CodeBlock(SourceCodeLanguage.CSharp, "catch (InvalidCastException ex)");
            cb.CurlyBracket = true;
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "throw new StoredProcedureSchemaMismatchedException(this, ex);"));

            var cs = new CSharpSourceCodeGenerator();
            cs.CurrentIndentLevel = 3;
            cs.Indent = "    ";
            cs.Write(cb);

            Assert.AreEqual("            catch (InvalidCastException ex)" + SourceCodeGenerator.NewLine
                + "            {" + SourceCodeGenerator.NewLine
                + "                throw new StoredProcedureSchemaMismatchedException(this, ex);" + SourceCodeGenerator.NewLine
                + "            }" + SourceCodeGenerator.NewLine
                , cs.ToString());
        }
    }
}
