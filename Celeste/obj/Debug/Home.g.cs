﻿#pragma checksum "..\..\Home.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "412166F84E28CA488F513063441CDFC7539FFFE27475739A2BFB920C9BBDEF79"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Celeste;
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


namespace Celeste {
    
    
    /// <summary>
    /// Home
    /// </summary>
    public partial class Home : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Celeste.Home HomeView;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_resources;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_settings;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_entries;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_lightmode;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\Home.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Celeste;component/home.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Home.xaml"
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
            this.HomeView = ((Celeste.Home)(target));
            return;
            case 2:
            this.btn_resources = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\Home.xaml"
            this.btn_resources.Click += new System.Windows.RoutedEventHandler(this.btn_resources_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_settings = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\Home.xaml"
            this.btn_settings.Click += new System.Windows.RoutedEventHandler(this.btn_settings_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_entries = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\Home.xaml"
            this.btn_entries.Click += new System.Windows.RoutedEventHandler(this.btn_entries_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_lightmode = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\Home.xaml"
            this.btn_lightmode.Click += new System.Windows.RoutedEventHandler(this.btn_lightmode_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_insights = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\Home.xaml"
            this.btn_insights.Click += new System.Windows.RoutedEventHandler(this.btn_insights_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

