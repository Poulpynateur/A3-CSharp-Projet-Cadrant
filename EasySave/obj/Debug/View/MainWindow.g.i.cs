﻿#pragma checksum "..\..\..\View\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3560285463B8038A98A4484EF5B1B65F03BDD0F57787294736DB10FC1CEBFA90"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using EasySave;
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


namespace EasySave.View {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnParam;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QuickName;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QuickSourcePath;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnQuickSourcePath;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QuickTargetPath;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnQuickTargetPath;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioMirrorSave;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioDifferentialSave;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox QuickSaveEncrypt;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExecuteQuickSave;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel TaskList;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnTaskExecute;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnTaskRemove;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnTaskAdd;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer LogScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel LogTextWrapper;
        
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
            System.Uri resourceLocater = new System.Uri("/EasySave;component/view/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MainWindow.xaml"
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
            
            #line 9 "..\..\..\View\MainWindow.xaml"
            ((EasySave.View.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.MainWindow_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnParam = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\View\MainWindow.xaml"
            this.BtnParam.Click += new System.Windows.RoutedEventHandler(this.BtnParam_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.QuickName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.QuickSourcePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnQuickSourcePath = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\View\MainWindow.xaml"
            this.btnQuickSourcePath.Click += new System.Windows.RoutedEventHandler(this.BtnQuickSourcePath_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.QuickTargetPath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnQuickTargetPath = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\View\MainWindow.xaml"
            this.btnQuickTargetPath.Click += new System.Windows.RoutedEventHandler(this.BtnQuickTargetPath_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RadioMirrorSave = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.RadioDifferentialSave = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.QuickSaveEncrypt = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            this.ExecuteQuickSave = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\View\MainWindow.xaml"
            this.ExecuteQuickSave.Click += new System.Windows.RoutedEventHandler(this.ExecuteQuickSave_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.TaskList = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 13:
            this.BtnTaskExecute = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\View\MainWindow.xaml"
            this.BtnTaskExecute.Click += new System.Windows.RoutedEventHandler(this.BtnTaskExecute_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.BtnTaskRemove = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\View\MainWindow.xaml"
            this.BtnTaskRemove.Click += new System.Windows.RoutedEventHandler(this.BtnTaskRemove_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.BtnTaskAdd = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\View\MainWindow.xaml"
            this.BtnTaskAdd.Click += new System.Windows.RoutedEventHandler(this.BtnTaskAdd_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.LogScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 88 "..\..\..\View\MainWindow.xaml"
            this.LogScrollViewer.ScrollChanged += new System.Windows.Controls.ScrollChangedEventHandler(this.ScrollViewer_ScrollChanged);
            
            #line default
            #line hidden
            return;
            case 17:
            this.LogTextWrapper = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

