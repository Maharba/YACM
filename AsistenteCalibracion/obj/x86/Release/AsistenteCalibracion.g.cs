﻿#pragma checksum "..\..\..\AsistenteCalibracion.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9B123600B105F33320C9BAAAC17BCF13"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
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


namespace AsistenteCalibracion {
    
    
    /// <summary>
    /// AsistenteCalibracionWindow
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class AsistenteCalibracionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\AsistenteCalibracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnterior;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\AsistenteCalibracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSiguiente;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\AsistenteCalibracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelar;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\AsistenteCalibracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stckConfig;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\AsistenteCalibracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.TranslateTransform Mover;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\AsistenteCalibracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse elipseEquipo1;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\AsistenteCalibracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCalibrar1;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\AsistenteCalibracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse elipseEquipo2;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\AsistenteCalibracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCalibrar2;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\AsistenteCalibracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse elipseEquipo1_1;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\AsistenteCalibracion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse elipseEquipo1_2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AsistenteCalibracion;component/asistentecalibracion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AsistenteCalibracion.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\AsistenteCalibracion.xaml"
            ((AsistenteCalibracion.AsistenteCalibracionWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnAnterior = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\..\AsistenteCalibracion.xaml"
            this.btnAnterior.Click += new System.Windows.RoutedEventHandler(this.btnAnterior_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnSiguiente = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\..\AsistenteCalibracion.xaml"
            this.btnSiguiente.Click += new System.Windows.RoutedEventHandler(this.btnSiguiente_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\..\AsistenteCalibracion.xaml"
            this.btnCancelar.Click += new System.Windows.RoutedEventHandler(this.btnCancelar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.stckConfig = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.Mover = ((System.Windows.Media.TranslateTransform)(target));
            return;
            case 7:
            this.elipseEquipo1 = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 8:
            this.btnCalibrar1 = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\AsistenteCalibracion.xaml"
            this.btnCalibrar1.Click += new System.Windows.RoutedEventHandler(this.btnCalibrar1_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.elipseEquipo2 = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 10:
            this.btnCalibrar2 = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\AsistenteCalibracion.xaml"
            this.btnCalibrar2.Click += new System.Windows.RoutedEventHandler(this.btnCalibrar2_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.elipseEquipo1_1 = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 12:
            this.elipseEquipo1_2 = ((System.Windows.Shapes.Ellipse)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

