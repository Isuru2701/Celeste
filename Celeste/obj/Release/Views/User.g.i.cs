﻿#pragma checksum "..\..\..\Views\User.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A5BBAEC5342412DDAF299E9446F8242BFEA8FE83FDA486493ED9846A0983A0A8"
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


namespace Celeste {
    
    
    /// <summary>
    /// User
    /// </summary>
    public partial class User : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Views\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_confirm;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_password_error;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Views\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image pic_pfp;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Views\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button changepfp_btn;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Views\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button resetpfp_btn;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\Views\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_username;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Views\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_email;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Views\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_user_id;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\Views\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwb_password;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Views\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwb_confirm;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\Views\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back;
        
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
            System.Uri resourceLocater = new System.Uri("/Celeste;component/views/user.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\User.xaml"
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
            
            #line 10 "..\..\..\Views\User.xaml"
            ((Celeste.User)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_confirm = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Views\User.xaml"
            this.btn_confirm.Click += new System.Windows.RoutedEventHandler(this.btn_confirm_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lbl_password_error = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.pic_pfp = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.changepfp_btn = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\Views\User.xaml"
            this.changepfp_btn.Click += new System.Windows.RoutedEventHandler(this.changepfp_btn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.resetpfp_btn = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\Views\User.xaml"
            this.resetpfp_btn.Click += new System.Windows.RoutedEventHandler(this.resetpfp_btn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lbl_username = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lbl_email = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lbl_user_id = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.pwb_password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 11:
            this.pwb_confirm = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 12:
            this.btn_back = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\..\Views\User.xaml"
            this.btn_back.Click += new System.Windows.RoutedEventHandler(this.btn_back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

