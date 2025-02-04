using System.ComponentModel;
using System.Windows;

namespace DbSharpApplication.Core;
public class WindowStateInfo
{
    public double Left { get; set; } = 100;
    public double Top { get; set; } = 100;
    public double Width { get; set; } = 1200;
    public double Height { get; set; } = 900;

    public void Initialize(Window window)
    {
        var w = window;
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
    void Window_Closing(object? sender, CancelEventArgs e)
    {
        this.WindowClosing(sender as Window);
    }
    protected virtual void WindowClosing(Window? window)
    {
        if (window == null) { return; }

        var w = window;
        var wsi = this;
        wsi.Width = w.Width;
        wsi.Height = w.Height;
        wsi.Left = w.Left;
        wsi.Top = w.Top;
    }
}
