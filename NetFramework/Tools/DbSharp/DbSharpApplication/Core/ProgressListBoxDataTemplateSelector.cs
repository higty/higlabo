using HigLabo.DbSharp.CodeGenerator;
using HigLabo.DbSharp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HigLabo.DbSharpApplication
{
    public class ProgressListBoxDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null)
            {
                if (item is SourceCodeFileGeneratedEventArgs)
                {
                    return element.FindResource("SourceCodeFileGeneratedDataTemplate") as DataTemplate;
                }
                return element.FindResource("ProgressListBoxDataTemplate") as DataTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
