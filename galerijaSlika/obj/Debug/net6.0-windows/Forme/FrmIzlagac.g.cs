﻿#pragma checksum "..\..\..\..\Forme\FrmIzlagac.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6C4C4092CBDE0216FF5EF0891E88D479127AFA8D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using galerijaSlika.Forme;


namespace galerijaSlika.Forme {
    
    
    /// <summary>
    /// FrmIzlagac
    /// </summary>
    public partial class FrmIzlagac : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\Forme\FrmIzlagac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIzlagacIme;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Forme\FrmIzlagac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIzlagacPrezime;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Forme\FrmIzlagac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtJMBG;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Forme\FrmIzlagac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAdresa;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Forme\FrmIzlagac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGrad;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Forme\FrmIzlagac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKontakt;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Forme\FrmIzlagac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Forme\FrmIzlagac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOtkazi;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Forme\FrmIzlagac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbKorisnik;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/galerijaSlika;component/forme/frmizlagac.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forme\FrmIzlagac.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtIzlagacIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtIzlagacPrezime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtJMBG = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtAdresa = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtGrad = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtKontakt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\Forme\FrmIzlagac.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Forme\FrmIzlagac.xaml"
            this.btnOtkazi.Click += new System.Windows.RoutedEventHandler(this.btnOtkazi_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cbKorisnik = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

