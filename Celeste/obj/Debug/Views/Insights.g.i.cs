﻿#pragma checksum "..\..\..\Views\Insights.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "879F9E6381C0512050FE92A031799586C5D956D10EF8AAA482CF928E233CDA37"
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
    /// Insights
    /// </summary>
    public partial class Insights : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Views\Insights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border_menu;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\Insights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Views\Insights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_score;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Views\Insights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_triggers;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Views\Insights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_comforts;
        
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
            System.Uri resourceLocater = new System.Uri("/Celeste;component/views/insights.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Insights.xaml"
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
            this.border_menu = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.btn_back = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Views\Insights.xaml"
            this.btn_back.Click += new System.Windows.RoutedEventHandler(this.btn_back_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_score = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Views\Insights.xaml"
            this.btn_score.Click += new System.Windows.RoutedEventHandler(this.btn_score_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_triggers = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\Views\Insights.xaml"
            this.btn_triggers.Click += new System.Windows.RoutedEventHandler(this.btn_triggers_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_comforts = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\Views\Insights.xaml"
            this.btn_comforts.Click += new System.Windows.RoutedEventHandler(this.btn_comforts_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

