﻿#pragma checksum "..\..\..\Windows\CopyResultSetWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EFD49BDEBEB6B56BB99D6178E30836A3CF47FA500621D9E0F4199E61481AE59D"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

using HigLabo.DbSharpApplication;
using HigLabo.DbSharpApplication.Properties;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HigLabo.DbSharpApplication {
    
    
    /// <summary>
    /// CopyResultSetWindow
    /// </summary>
    public partial class CopyResultSetWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Windows\CopyResultSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SourceStoredProcedureComboBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Windows\CopyResultSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SourceStoredProcedureResultSetComboBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Windows\CopyResultSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SourceResultSetParameterComboBox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Windows\CopyResultSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TargetStoredProcedureComboBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Windows\CopyResultSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TargetStoredProcedureResultSetComboBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Windows\CopyResultSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TargetResultSetParameterComboBox;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Windows\CopyResultSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label StatusMessage;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Windows\CopyResultSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExecuteButton;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Windows\CopyResultSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button QuitButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DbSharpApplication;component/windows/copyresultsetwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\CopyResultSetWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SourceStoredProcedureComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\Windows\CopyResultSetWindow.xaml"
            this.SourceStoredProcedureComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SourceStoredProcedureComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SourceStoredProcedureResultSetComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.SourceResultSetParameterComboBox = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.TargetStoredProcedureComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 48 "..\..\..\Windows\CopyResultSetWindow.xaml"
            this.TargetStoredProcedureComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TargetStoredProcedureComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TargetStoredProcedureResultSetComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.TargetResultSetParameterComboBox = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.StatusMessage = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.ExecuteButton = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\Windows\CopyResultSetWindow.xaml"
            this.ExecuteButton.Click += new System.Windows.RoutedEventHandler(this.ExecuteButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.QuitButton = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\Windows\CopyResultSetWindow.xaml"
            this.QuitButton.Click += new System.Windows.RoutedEventHandler(this.QuitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
