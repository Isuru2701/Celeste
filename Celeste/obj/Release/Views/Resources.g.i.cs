﻿#pragma checksum "..\..\..\Views\Resources.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "729E249DABCB9B953650BA8B5C44CDD883DF0566A345FABD74E2999FC1A1F727"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Celeste.Views;
using ScottPlot;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
    /// Resources
    /// </summary>
    public partial class Resources : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Views\Resources.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame InfoViewer;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\Resources.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border_menu;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\Resources.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Container;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Views\Resources.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\Views\Resources.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_videos;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\Views\Resources.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_locations;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Views\Resources.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_forum;
        
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
            System.Uri resourceLocater = new System.Uri("/Celeste;component/views/resources.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Resources.xaml"
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
            this.InfoViewer = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.border_menu = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.Container = ((System.Windows.Controls.Frame)(target));
            return;
            case 4:
            this.btn_back = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\Views\Resources.xaml"
            this.btn_back.Click += new System.Windows.RoutedEventHandler(this.btn_back_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_videos = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\Views\Resources.xaml"
            this.btn_videos.Click += new System.Windows.RoutedEventHandler(this.btn_videos_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_locations = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\Views\Resources.xaml"
            this.btn_locations.Click += new System.Windows.RoutedEventHandler(this.btn_locations_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_forum = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\..\Views\Resources.xaml"
            this.btn_forum.Click += new System.Windows.RoutedEventHandler(this.btn_forum_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

