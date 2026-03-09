using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace DbSharpApplication;

public static class ComboboxHeight
{
    public static readonly DependencyProperty EnableProperty =
        DependencyProperty.RegisterAttached(
            "Enable", typeof(bool), typeof(ComboboxHeight),
            new PropertyMetadata(false, OnEnableChanged));

    public static void SetEnable(DependencyObject d, bool v) => d.SetValue(EnableProperty, v);
    public static bool GetEnable(DependencyObject d) => (bool)d.GetValue(EnableProperty);

    private static void OnEnableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not ComboBox cb) return;

        cb.DropDownOpened -= OnOpened;
        if ((bool)e.NewValue) cb.DropDownOpened += OnOpened;
    }

    private static void OnOpened(object? sender, EventArgs e)
    {
        if (sender is not ComboBox cb) return;

        cb.Dispatcher.BeginInvoke(new Action(() =>
        {
            cb.ApplyTemplate();

            if (cb.Template.FindName("PART_Popup", cb) is not Popup popup) return;
            if (popup.Child is not FrameworkElement fe) return;

            var h = cb.MaxDropDownHeight;

            if (VisualTreeHelper.GetChildrenCount(fe) > 0 &&
                VisualTreeHelper.GetChild(fe, 0) is FrameworkElement inner)
            {
                inner.Height = h;
                inner.MaxHeight = h;
            }
            fe.MaxHeight = h;

        }), DispatcherPriority.ContextIdle);

    }
}
