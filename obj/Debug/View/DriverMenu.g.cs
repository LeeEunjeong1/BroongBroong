﻿#pragma checksum "..\..\..\View\DriverMenu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B2DD6D6CE07A57D6CA193B9B422EE5F309B00D41"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using BroongBroong.View;
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


namespace BroongBroong.View {
    
    
    /// <summary>
    /// DriverMenu
    /// </summary>
    public partial class DriverMenu : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 71 "..\..\..\View\DriverMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button receiveDelivery;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\View\DriverMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delivering;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\View\DriverMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button completeDelivery;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\View\DriverMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exchangeBalance;
        
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
            System.Uri resourceLocater = new System.Uri("/BroongBroong;component/view/drivermenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\DriverMenu.xaml"
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
            this.receiveDelivery = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\View\DriverMenu.xaml"
            this.receiveDelivery.Click += new System.Windows.RoutedEventHandler(this.receiveDelivery_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.delivering = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\View\DriverMenu.xaml"
            this.delivering.Click += new System.Windows.RoutedEventHandler(this.delivering_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.completeDelivery = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\View\DriverMenu.xaml"
            this.completeDelivery.Click += new System.Windows.RoutedEventHandler(this.completeDelivery_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.exchangeBalance = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\View\DriverMenu.xaml"
            this.exchangeBalance.Click += new System.Windows.RoutedEventHandler(this.exchangeBalance_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

