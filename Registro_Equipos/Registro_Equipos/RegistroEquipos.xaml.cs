using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Win32;
using System.IO;
using Equipos;
using Seguridad;



namespace Registro_Equipos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RegistroEquipos : Window
    {
        public RegistroEquipos()
        {
            InitializeComponent();
        }

        public static ListaEquipos equipos = new ListaEquipos();
        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            Datos datos = new Datos(true);
            datos.ShowDialog();
           
           
        }                
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            lvEquipos.ItemsSource = equipos.Lista;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
                                            
            MessageBoxResult guardarCambios = MessageBox.Show("¿Desea guardar los cambios antes de salir?","Registro De Equipos", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (guardarCambios == MessageBoxResult.Yes)
            {
                
                if (_abrirLista!=null)
                {
                    equipos.Guardar(_abrirLista.FileName);                                       
                }
                else
                {
                    SaveFileDialog nuevaLista = new SaveFileDialog {Filter = "Archivos Xml | *.xml"};
                    if (nuevaLista.ShowDialog() == true)
                    {
                        equipos.Guardar(nuevaLista.FileName);                                                 
                    }
                    
                }                
            }
            else if (guardarCambios == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

             
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
           
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lvEquipos.SelectedIndex != -1)
            {
                if (MessageBox.Show(string.Format("¿Desea eliminar a {0} de manera permanente?",((Equipo) lvEquipos.SelectedItem).NombreEquipo),"Eliminar Equipo", MessageBoxButton.YesNo, MessageBoxImage.Warning)==MessageBoxResult.Yes)
                {
                    equipos.EliminarEquipo(lvEquipos.SelectedItem as Equipo);    
                }
                
            }
            else 
            {
                MessageBox.Show("Seleccione el equipo que desea eliminar", "Eliminar Equipo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lvEquipos.SelectedIndex != -1)
            {                
                 Datos datos = new Datos(lvEquipos.SelectedItem as Equipo, false);                  
                 datos.ShowDialog();
                 lvEquipos.ItemsSource = equipos.Lista;
            }
            else
            {
                MessageBox.Show("Seleccione el equipo que desea editar","Editar Equipo",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
        }


        private OpenFileDialog _abrirLista;
        private void AbrirMenuItemClick(object sender, RoutedEventArgs e)
        {
            
            _abrirLista = new OpenFileDialog {Filter = "Archivos Xml | *.xml"};
            if (_abrirLista.ShowDialog() == true)
            {                
                equipos.Cargar(_abrirLista.FileName);
                this.Title = string.Format("{0} - Registro de Equipos",
                                           Path.GetFileNameWithoutExtension(_abrirLista.FileName));
                lvEquipos.ItemsSource = equipos.Lista;

            }

        }

        private void GuardarMenuItemClick(object sender, RoutedEventArgs e)
        {
            if (_abrirLista != null)
            {
                equipos.Guardar(_abrirLista.FileName);                
            }
            else
            {
                SaveFileDialog nuevaLista = new SaveFileDialog {Filter = "Archivos Xml | *.xml"};
                if (nuevaLista.ShowDialog() == true)
                {
                    equipos.Guardar(nuevaLista.FileName);                    
                }

            }                
        }

        private void CerrarMenuItemClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AcercaDeMenuItemClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lvEquipos.SelectedIndex = -1;
        }

        //private void nuevoMenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    equipos = new ListaEquipos();
        //    lvEquipos.ItemsSource = equipos.Lista;
        //    Title = "Registro De Equipos - Sin Titulo";
        //}       
    }
}
