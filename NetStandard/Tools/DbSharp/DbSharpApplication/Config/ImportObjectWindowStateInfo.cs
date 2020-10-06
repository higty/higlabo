using HigLabo.Wpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HigLabo.DbSharpApplication.Core
{
    public class ImportObjectWindowStateInfo : WindowStateInfo
    {
        public Boolean TableSelectAllCheckBoxChecked { get; set; }
        public Boolean StoredProcedureSelectAllCheckBoxChecked { get; set; }
        public Boolean UserDefinedTableTypeSelectAllCheckBoxChecked { get; set; }

        public ImportObjectWindowStateInfo()
        {
        }
        public ImportObjectWindowStateInfo(Double width, Double height)
        {
            this.Width = width;
            this.Height = height;
        }
        protected override void InitializeProperty(Window window)
        {
            var w = window as ImportObjectWindow;
            var wsi = this;

            w.Width = wsi.Width;
            w.Height = wsi.Height;

            w.TableSelectAllCheckBox.IsChecked = wsi.TableSelectAllCheckBoxChecked;
            w.StoredProcedureSelectAllCheckBox.IsChecked = wsi.StoredProcedureSelectAllCheckBoxChecked;
            w.UserDefinedTableTypeSelectAllCheckBox.IsChecked = wsi.UserDefinedTableTypeSelectAllCheckBoxChecked;
        }
        protected override void WindowClosing(Window window)
        {
            var w = window as ImportObjectWindow;
            var wsi = this;

            base.WindowClosing(w);
            wsi.TableSelectAllCheckBoxChecked = w.TableSelectAllCheckBox.IsChecked ?? false;
            wsi.StoredProcedureSelectAllCheckBoxChecked = w.StoredProcedureSelectAllCheckBox.IsChecked ?? false;
            wsi.UserDefinedTableTypeSelectAllCheckBoxChecked = w.UserDefinedTableTypeSelectAllCheckBox.IsChecked ?? false;

        }
    }
}
