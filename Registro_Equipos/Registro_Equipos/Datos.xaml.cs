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
using System.Windows.Shapes;
using Equipos;

namespace Registro_Equipos
{
    /// <summary>
    /// Interaction logic for Datos.xaml
    /// </summary>
    public partial class Datos : Window
    {
        readonly bool _nuevoEquipo;
        public Datos(bool estadoEquipo)
        {
            this._nuevoEquipo = estadoEquipo;
            InitializeComponent();
        }

         readonly Equipo _eq;
         public Datos(Equipo equipo, bool estadoEquipo)
        {
           this._nuevoEquipo = estadoEquipo;
           InitializeComponent();
           _eq = equipo;
           txtNombreEquipo.Text = equipo.NombreEquipo;
           txtEscuela.Text = equipo.Escuela;
           cbNumIntegrantes.Text = equipo.Concursantes.Count.ToString();
           txtNombre1.Text = equipo.Concursantes[0].NombreAlumno;
           txtNocontrol1.Text = equipo.Concursantes[0].NoControl;
           cbNivel1.Text = equipo.Concursantes[0].Semestre;
           txtCarrera1.Text = equipo.Concursantes[0].Carrera;
           if (cbNumIntegrantes.SelectedIndex==1)
           {
           txtNombre2.Text = equipo.Concursantes[1].NombreAlumno;
           txtNocontrol2.Text = equipo.Concursantes[1].NoControl;
           cbNivel2.Text = equipo.Concursantes[1].Semestre;
           txtCarrera2.Text = equipo.Concursantes[1].Carrera;
           }
           if (cbNumIntegrantes.SelectedIndex==2)
           {
               txtNombre2.Text = equipo.Concursantes[1].NombreAlumno;
               txtNocontrol2.Text = equipo.Concursantes[1].NoControl;
               cbNivel2.Text = equipo.Concursantes[1].Semestre;
               txtCarrera2.Text = equipo.Concursantes[1].Carrera;
               txtNombre3.Text = equipo.Concursantes[2].NombreAlumno;
               txtNocontrol3.Text = equipo.Concursantes[2].NoControl;
               cbNivel3.Text = equipo.Concursantes[2].Semestre;
               txtCarrera3.Text = equipo.Concursantes[2].Carrera; 
           }
  
                
        }      
        
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {            
            //Si es un nuevo equipo lo añade a la lista, si ya existe lo edita          
            if (_nuevoEquipo)
            {                
                switch (cbNumIntegrantes.SelectedIndex)
                {
                    case 0:
                        {
                            try
                            {
                                Concursante integrante1 = new Concursante(txtNocontrol1.Text, txtCarrera1.Text, cbNivel1.Text, txtNombre1.Text);
                                RegistroEquipos.equipos.Agregar(txtNombreEquipo.Text, txtEscuela.Text, integrante1);
                            }
                            catch (ApplicationException)
                            {
                                MessageBox.Show(this, "Por favor, llene todos los campos antes de agregar un equipo.",
                                               "Atención", MessageBoxButton.OK, MessageBoxImage.Hand);
                                return;
                            }
                        }
                        break;
                    case 1:
                        {
                            try
                            {
                                Concursante integrante1 = new Concursante(txtNocontrol1.Text, txtCarrera1.Text, cbNivel1.Text, txtNombre1.Text);
                                Concursante integrante2 = new Concursante(txtNocontrol2.Text, txtCarrera2.Text, cbNivel2.Text, txtNombre2.Text);
                                RegistroEquipos.equipos.Agregar(txtNombreEquipo.Text, txtEscuela.Text, integrante1, integrante2);
                            }
                            catch (ApplicationException)
                            {
                                MessageBox.Show(this, "Por favor, llene todos los campos antes de agregar un equipo.",
                                               "Atención", MessageBoxButton.OK, MessageBoxImage.Hand);
                                return;
                            }
                        }
                        break;
                    case 2:
                        {
                            try
                            {
                                Concursante integrante1 = new Concursante(txtNocontrol1.Text, txtCarrera1.Text, cbNivel1.Text, txtNombre1.Text);
                                Concursante integrante2 = new Concursante(txtNocontrol2.Text, txtCarrera2.Text, cbNivel2.Text, txtNombre2.Text);
                                Concursante integrante3 = new Concursante(txtNocontrol3.Text, txtCarrera3.Text, cbNivel3.Text, txtNombre3.Text);
                                RegistroEquipos.equipos.Agregar(txtNombreEquipo.Text, txtEscuela.Text, integrante1, integrante2, integrante3);
                            }
                            catch (ApplicationException)
                            {
                                MessageBox.Show(this, "Por favor, llene todos los campos antes de agregar un equipo.",
                                               "Atención", MessageBoxButton.OK, MessageBoxImage.Hand);
                                return;
                            }

                        }
                        break;
                    default:
                        break;
                }    
            }
            else
            {                
                switch (cbNumIntegrantes.SelectedIndex)
                {
                    case 0:
                        {
                            try
                            {
                                Concursante integrante1 = new Concursante(txtNocontrol1.Text, txtCarrera1.Text, cbNivel1.Text, txtNombre1.Text);
                                RegistroEquipos.equipos.Editar(_eq, txtNombreEquipo.Text, txtEscuela.Text, integrante1);
                            }
                            catch (ApplicationException)
                            {
                                MessageBox.Show(this, "Por favor, llene todos los campos antes de editar un equipo.",
                                               "Atención", MessageBoxButton.OK, MessageBoxImage.Hand);
                                return;
                            }
                        }
                        break;
                    case 1:
                        {
                            try
                            {
                                Concursante integrante1 = new Concursante(txtNocontrol1.Text, txtCarrera1.Text, cbNivel1.Text, txtNombre1.Text);
                                Concursante integrante2 = new Concursante(txtNocontrol2.Text, txtCarrera2.Text, cbNivel2.Text, txtNombre2.Text);
                                RegistroEquipos.equipos.Editar(_eq, txtNombreEquipo.Text, txtEscuela.Text, integrante1, integrante2);
                            }
                            catch (ApplicationException)
                            {
                                MessageBox.Show(this, "Por favor, llene todos los campos antes de editar un equipo.",
                                               "Atención", MessageBoxButton.OK, MessageBoxImage.Hand);
                                return;
                            }
                        }
                        break;
                    case 2:
                        {
                            try
                            {
                                Concursante integrante1 = new Concursante(txtNocontrol1.Text, txtCarrera1.Text, cbNivel1.Text, txtNombre1.Text);
                                Concursante integrante2 = new Concursante(txtNocontrol2.Text, txtCarrera2.Text, cbNivel2.Text, txtNombre2.Text);
                                Concursante integrante3 = new Concursante(txtNocontrol3.Text, txtCarrera3.Text, cbNivel3.Text, txtNombre3.Text);
                                RegistroEquipos.equipos.Editar(_eq, txtNombreEquipo.Text, txtEscuela.Text, integrante1, integrante2, integrante3);
                            }
                            catch (ApplicationException)
                            {
                                MessageBox.Show(this, "Por favor, llene todos los campos antes de editar un equipo.",
                                               "Atención", MessageBoxButton.OK, MessageBoxImage.Hand);
                                return;
                            }

                        }
                        break;
                    default:
                        break;
                }
            }
            
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbNumIntegrantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabIntegrantes.IsEnabled = true;
            switch (Convert.ToInt32(((ComboBoxItem)cbNumIntegrantes.SelectedItem).Content))
            {
                case 1:
                    tabIntegrantes.SelectedIndex = 0;
                    tabIntegrante2.IsEnabled = false;
                    tabIntegrante3.IsEnabled = false;
                    break;
                case 2:
                    tabIntegrantes.SelectedIndex = 1;
                    tabIntegrante2.IsEnabled = true;
                    tabIntegrante3.IsEnabled = false;
                    break;
                case 3:
                    tabIntegrantes.SelectedIndex = 2;
                    tabIntegrante2.IsEnabled = true;
                    tabIntegrante3.IsEnabled = true;
                    break;
            }
        }

        private void WndDatos_Loaded(object sender, RoutedEventArgs e)
        {
        }

        
    }
}
