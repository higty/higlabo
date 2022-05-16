using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public class InputPropertyColorPanel : InputPropertyPanel
    {
        public class ColorTableRow
        {
            public List<String> ColorList { get; private set; } = new List<String>();

            public ColorTableRow() { }
            public ColorTableRow(IEnumerable<String> colorList)
            {
                this.ColorList.AddRange(colorList);
            }
        }

        public override InputElementType ElementType => InputElementType.Color;

        public TextBoxElement TextBox { get; init; } = new TextBoxElement();
        public List<ColorTableRow> ColorTableRowList { get; private set; } = new List<ColorTableRow>();

        public InputPropertyColorPanel()
        {
            this.LoadDefaultColor();
        }
        public void LoadDefaultColor()
        {
            foreach (var item in Default.ColorTableRowList)
            {
                var row = new ColorTableRow();
                row.ColorList.AddRange(item.ColorList);
                this.ColorTableRowList.Add(row);
            }
        }
    }
}
