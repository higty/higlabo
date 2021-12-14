using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HigLabo.Wpf.UI;

namespace HigLabo.DbSharpApplication.Core
{
    public class MainWindowStateInfo : WindowStateInfo
    {
        public Double TableGridColumnWidth { get; set; }
        public Double ColumnGridColumnWidth { get; set; }
        public Double StoredProcedureGridColumnWidth { get; set; }
        public Double ParameterResultSetGridColumnWidth { get; set; }
        public Double ParameterGridRowHeight { get; set; }
        public Double ResultSetGridRowHeight { get; set; }
        public MainWindowStateInfo()
        {
            this.InitializeProperty();
        }
        public MainWindowStateInfo(Int32 width, Int32 height)
            :base(width, height)
        {
            this.InitializeProperty();
        }
        private void InitializeProperty()
        {
            this.TableGridColumnWidth = 1;
            this.ColumnGridColumnWidth = 2;
            this.StoredProcedureGridColumnWidth = 1;
            this.ParameterResultSetGridColumnWidth = 2;
            this.ParameterGridRowHeight = 1;
            this.ResultSetGridRowHeight = 1;
        }
        protected override void InitializeProperty(Window window)
        {
            var w = window as MainWindow;
            var wsi = this;
            w.Width = wsi.Width;
            w.Height = wsi.Height;
            w.TableGridColumn.Width = new GridLength(wsi.TableGridColumnWidth, GridUnitType.Star);
            w.ColumnGridColumn.Width = new GridLength(wsi.ColumnGridColumnWidth, GridUnitType.Star);
            w.StoredProcedureGridColumn.Width = new GridLength(wsi.StoredProcedureGridColumnWidth, GridUnitType.Star);
            w.ParameterResultSetGridColumn.Width = new GridLength(wsi.ParameterResultSetGridColumnWidth, GridUnitType.Star);
            w.ParameterGridRow.Height = new GridLength(wsi.ParameterGridRowHeight, GridUnitType.Star);
            w.ResultSetGridRow.Height = new GridLength(wsi.ResultSetGridRowHeight, GridUnitType.Star);
        }
        protected override void WindowClosing(Window window)
        {
            var w = window as MainWindow;
            var wsi = this;

            base.WindowClosing(w);
            wsi.TableGridColumnWidth = w.TableGridColumn.Width.Value;
            wsi.ColumnGridColumnWidth = w.ColumnGridColumn.Width.Value;
            wsi.StoredProcedureGridColumnWidth = w.StoredProcedureGridColumn.Width.Value;
            wsi.ParameterResultSetGridColumnWidth = w.ParameterResultSetGridColumn.Width.Value;
            wsi.ParameterGridRowHeight = w.ParameterGridRow.Height.Value;
            wsi.ResultSetGridRowHeight = w.ResultSetGridRow.Height.Value;   

        }
    }
}
