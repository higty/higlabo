using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace HigLabo.Wpf.UI
{
    public class WindowStateInfo
    {
        [XmlIgnore]
        public static ImageSource DefaultIcon { get; set; }

        [XmlIgnore]
        public ImageSource Icon { get; set; }
        public Double Width { get; set; }
        public Double Height { get; set; }
        public Double Left { get; set; }
        public Double Top { get; set; }

        public WindowStateInfo()
        {
            this.Icon = DefaultIcon;
        }
        public WindowStateInfo(Double width, Double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public void Initialize(Window window)
        {
            var w = window;
            w.Icon = this.Icon;
            w.Closing += Window_Closing;
            this.InitializeProperty(window);
        }

        protected virtual void InitializeProperty(Window window)
        {
            var w = window;
            var wsi = this;
            w.Width = wsi.Width;
            w.Height = wsi.Height;
            w.Left = wsi.Left;
            w.Top = wsi.Top;
        }
        void Window_Closing(object sender, CancelEventArgs e)
        {
            this.WindowClosing(sender as Window);
        }
        protected virtual void WindowClosing(Window window)
        {
            var w = window;
            var wsi = this;
            wsi.Width = w.Width;
            wsi.Height = w.Height;
            wsi.Left = w.Left;
            wsi.Top = w.Top;
        }
    }
}
