using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HigLabo.DbSharpApplication.Core;

namespace HigLabo.DbSharpApplication
{
    /// <summary>
    /// MessageWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(String message)
        {
            InitializeComponent();
            AValue.ConfigData.MessageWindow.Initialize(this);
            this.MessageTextBox.Text = message;
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
