﻿#pragma checksum "..\..\..\Views\Signup.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5D7D508475C5EC89A3AB99BA8CC951308FF3ABB1C9C61CAB776C67C408724DD0"
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
    /// Signup
    /// </summary>
    public partial class Signup : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 76 "..\..\..\Views\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_email;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Views\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_username;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Views\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwb_password;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Views\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwb_confirm;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Views\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_signup;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Views\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Views\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_days;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\Views\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_months;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\Views\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_years;
        
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
            System.Uri resourceLocater = new System.Uri("/Celeste;component/views/signup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Signup.xaml"
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
            
            #line 11 "..\..\..\Views\Signup.xaml"
            ((Celeste.Views.Signup)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.pwb_password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.pwb_confirm = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.btn_signup = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\Views\Signup.xaml"
            this.btn_signup.Click += new System.Windows.RoutedEventHandler(this.btn_signup_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_back = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\Views\Signup.xaml"
            this.btn_back.Click += new System.Windows.RoutedEventHandler(this.btn_back_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cmb_days = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.cmb_months = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.cmb_years = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

