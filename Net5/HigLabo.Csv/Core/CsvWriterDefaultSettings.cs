using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Csv
{
    public enum FoldingMode
    {
        Always,
    }
    public class CsvWriterDefaultSettings
    {
        public Char Separator { get; set; } = ',';
        public FoldingMode FoldingMode { get; set; } = FoldingMode.Always;
        public Char FoldBy { get; set; } = '"';
        public String NewLine { get; set; } = "\r\n";
        public Boolean IsExportHeader { get; set; } = true;
    }
}
