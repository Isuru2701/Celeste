﻿#pragma checksum "..\..\..\Views\Home.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8C3343DC4A95B5671568084852AA7A738555A7F1D141CA0823B86F0D0A46A964"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LottieSharp;
using ScottPlot;
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


namespace Celeste.Views {
    
    
    /// <summary>
    /// Home
    /// </summary>
    public partial class Home : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Views\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border writer;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Views\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_writer;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_user;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Views\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_resources;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Views\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_notification;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\Views\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_entries;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\Views\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_exit;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\Views\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_insights;
        
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
            System.Uri resourceLocater = new System.Uri("/Celeste;component/views/home.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Home.xaml"
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
            this.writer = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.btn_writer = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Views\Home.xaml"
            this.btn_writer.Click += new System.Windows.RoutedEventHandler(this.btn_writer_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_user = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\Views\Home.xaml"
            this.btn_user.Click += new System.Windows.RoutedEventHandler(this.btn_user_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_resources = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\Views\Home.xaml"
            this.btn_resources.Click += new System.Windows.RoutedEventHandler(this.btn_resources_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_notification = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\Views\Home.xaml"
            this.btn_notification.Click += new System.Windows.RoutedEventHandler(this.btn_notification_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_entries = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\Views\Home.xaml"
            this.btn_entries.Click += new System.Windows.RoutedEventHandler(this.btn_entries_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_exit = ((System.Windows.Controls.Button)(target));
            
            #line 121 "..\..\..\Views\Home.xaml"
            this.btn_exit.Click += new System.Windows.RoutedEventHandler(this.btn_exit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_insights = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\..\Views\Home.xaml"
            this.btn_insights.Click += new System.Windows.RoutedEventHandler(this.btn_insights_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

