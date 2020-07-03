using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HigLabo.Csv
{
    public class CsvWriter : StreamWriter
    {
        public static readonly CsvWriterDefaultSettings Default = new CsvWriterDefaultSettings();

        public Char Separator { get; set; } = Default.Separator;
        public FoldingMode FoldingMode { get; set; } = Default.FoldingMode;
        public Char FoldBy { get; set; } = Default.FoldBy;
        public new String NewLine { get; set; } = Default.NewLine;
        public Boolean IsExportHeader { get; set; } = Default.IsExportHeader;

        public CsvWriter(Stream stream)
            : base(stream)
        {

        }
        public CsvWriter(Stream stream, Encoding encoding)
            : base(stream, encoding)
        {

        }
        public void AddRow(IEnumerable<String> row)
        {
            var firstRow = true;
            if (this.FoldingMode == FoldingMode.Always)
            {
                foreach (var item in row)
                {
                    if (firstRow == false)
                    {
                        this.Write(this.Separator);
                    }
                    this.Write(FoldBy);
                    for (int i = 0; i < item.Length; i++)
                    {
                        this.Write(item[i]);
                        if (item[i] == this.FoldBy)
                        {
                            this.Write(this.FoldBy);
                        }
                    }
                    this.Write(FoldBy);

                    firstRow = false;
                }
            }
        }
        public void AddRowAndNewLine(IEnumerable<String> row)
        {
            this.AddRow(row);
            this.Write(this.NewLine);
        }
        public void AddRows(IEnumerable<String[]> rows)
        {
            foreach (var row in rows)
            {
                //for performance reason, not to call AddRowAndNewLine.
                this.AddRow(row);
                this.Write(this.NewLine);
            }
        }

        public void Write(ICsvExport csv)
        {
            if (this.IsExportHeader)
            {
                this.AddRow(csv.GetHeader());
                this.Write(this.NewLine);
            }
            foreach (var row in csv.GetRows())
            {
                //for performance reason, not to call AddRowAndNewLine.
                this.AddRow(row);
                this.Write(this.NewLine);
            }
        }
    }
}
