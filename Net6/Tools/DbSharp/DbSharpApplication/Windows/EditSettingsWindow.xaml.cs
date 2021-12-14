using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using HigLabo.DbSharpApplication.Core;
using Microsoft.AppCenter.Analytics;

namespace HigLabo.DbSharpApplication
{
    /// <summary>
    /// Interaction logic for EditSettingsWindow.xaml
    /// </summary>
    public partial class EditSettingsWindow : Window
    {
        public EditSettingsWindow()
        {
            InitializeComponent();

            this.LanguageComboBox.SelectedValuePath = "CultureName";
            this.LanguageComboBox.ItemsSource = this.CreateLanguageViewModelList();
            this.LanguageComboBox.SelectedValue = AValue.ConfigData.CultureName;
            this.UseTableFeatureCheckBox.DataContext = AValue.ConfigData;
        }
        private List<LanguageViewModel> CreateLanguageViewModelList()
        {
            var l = new List<LanguageViewModel>();

            l.Add(new LanguageViewModel("English", "en-US"));
            l.Add(new LanguageViewModel("日本語", "ja-JP"));

            return l;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var d = new Dictionary<String, String>();

            var language = this.LanguageComboBox.SelectedItem as LanguageViewModel;
            if (language != null)
            {
                d.Add("Language", language.ToString());
                AValue.ConfigData.ChangeCultureInfo(language.CultureName);
            }
            d.Add("UseTableFeature", this.UseTableFeatureCheckBox.IsChecked.ToString());
            Analytics.TrackEvent("EditSettings Execute", d);

            this.Close();

            var w = new MainWindow();
            w.Show();
        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            var w = new MainWindow();
            w.Show();
        }

        private class LanguageViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private String _Name = "";
            private String _CultureName = "";

            public String Name
            {
                get { return this._Name; }
                set { this.SetPropertyValue(ref _Name, value, this.PropertyChanged); }
            }
            public String CultureName
            {
                get { return this._CultureName; }
                set { this.SetPropertyValue(ref _CultureName, value, this.PropertyChanged); }
            }

            public LanguageViewModel(String name, String cultureName)
            {
                this.Name = name;
                this.CultureName = cultureName;
            }
        }
    }
}
