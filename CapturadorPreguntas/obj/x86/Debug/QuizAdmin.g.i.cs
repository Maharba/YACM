﻿#pragma checksum "..\..\..\QuizAdmin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3CCBBBCB634C462B0F88D78AB87A0DA0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.237
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


namespace CapturadorPreguntas {
    
    
    /// <summary>
    /// QuizAdmin
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class QuizAdmin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\QuizAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem nuevoMenuItem;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\QuizAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem abrirMenuItem;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\QuizAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem guardarMeuItem;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\QuizAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem cerrarMenuItem;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\QuizAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem acercaDeMenuItem;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\QuizAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvPreguntas;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\QuizAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregar;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\QuizAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificar;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\QuizAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminar;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\QuizAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCerrar;
        
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
            System.Uri resourceLocater = new System.Uri("/CapturadorPreguntas;component/quizadmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\QuizAdmin.xaml"
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
            
            #line 4 "..\..\..\QuizAdmin.xaml"
            ((CapturadorPreguntas.QuizAdmin)(target)).Loaded += new System.Windows.RoutedEventHandler(this.WindowLoaded);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\QuizAdmin.xaml"
            ((CapturadorPreguntas.QuizAdmin)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.WindowClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nuevoMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 39 "..\..\..\QuizAdmin.xaml"
            this.nuevoMenuItem.Click += new System.Windows.RoutedEventHandler(this.NuevoMenuItemClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.abrirMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 40 "..\..\..\QuizAdmin.xaml"
            this.abrirMenuItem.Click += new System.Windows.RoutedEventHandler(this.AbrirMenuItemClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.guardarMeuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 41 "..\..\..\QuizAdmin.xaml"
            this.guardarMeuItem.Click += new System.Windows.RoutedEventHandler(this.GuardarMeuItemClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cerrarMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 43 "..\..\..\QuizAdmin.xaml"
            this.cerrarMenuItem.Click += new System.Windows.RoutedEventHandler(this.CerrarMenuItemClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.acercaDeMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 46 "..\..\..\QuizAdmin.xaml"
            this.acercaDeMenuItem.Click += new System.Windows.RoutedEventHandler(this.AcercaDeMenuItemClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lvPreguntas = ((System.Windows.Controls.ListView)(target));
            
            #line 75 "..\..\..\QuizAdmin.xaml"
            this.lvPreguntas.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LvPreguntasSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAgregar = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\..\QuizAdmin.xaml"
            this.btnAgregar.Click += new System.Windows.RoutedEventHandler(this.BtnAgregarClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnModificar = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\..\QuizAdmin.xaml"
            this.btnModificar.Click += new System.Windows.RoutedEventHandler(this.BtnModificarClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnEliminar = ((System.Windows.Controls.Button)(target));
            
            #line 131 "..\..\..\QuizAdmin.xaml"
            this.btnEliminar.Click += new System.Windows.RoutedEventHandler(this.BtnEliminarClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnCerrar = ((System.Windows.Controls.Button)(target));
            
            #line 132 "..\..\..\QuizAdmin.xaml"
            this.btnCerrar.Click += new System.Windows.RoutedEventHandler(this.BtnCerrarClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

