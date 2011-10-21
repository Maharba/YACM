using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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
using System.Configuration;
using System.Reflection;
using System.Xml;
using AsistenteCalibracion;
using Microsoft.Win32;

namespace MenuPrincipal
{
    /// <summary>
    /// Interaction logic for wndConfig.xaml
    /// </summary>
    public partial class wndConfig : Window
    {
        public wndConfig()
        {
            InitializeComponent();
        }

        private string _btnEq1;
        private string _btnEq2;

        private void rbPredeterminado_Checked(object sender, RoutedEventArgs e)
        {
            txtSegundos.IsEnabled = false;
        }

        private void rbTiempo_Checked(object sender, RoutedEventArgs e)
        {
            txtSegundos.IsEnabled = true;
        }


        private void btnMas_Click(object sender, RoutedEventArgs e)
        {
            new wndBanners().ShowDialog();
        }

        public static ListaBanners banners;// = new ListaBanners();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            banners = new ListaBanners();
            txtNombreConcurso.Text = ConfigurationManager.AppSettings["nombreConcurso"];
            txtPreguntas.Text = ConfigurationManager.AppSettings["preguntas"];
            txtEquipos.Text = ConfigurationManager.AppSettings["equipos"];
            if (File.Exists(ConfigurationManager.AppSettings["banners"]))
            {
                banners.Cargar(ConfigurationManager.AppSettings["banners"]);
            }
            txtCPreguntas.Text = ConfigurationManager.AppSettings["cPreguntas"];
            if (ConfigurationManager.AppSettings["tPreguntas"] == "Predeterminado")
            {
                rbPredeterminado.IsChecked = true;
            }
            else
            {
                rbTiempo.IsChecked = true;
                txtSegundos.Text = ConfigurationManager.AppSettings["tPreguntas"];
            }

            lstBanners.ItemsSource = banners.Lista;
        }

        private void btnMenos_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el elemento de forma permanente?", "Banners", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                banners.Lista.Remove(lstBanners.SelectedItem as string);
            }

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lstBanners.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            ConfigAcciones config = ConfigAcciones.CargarConfiguracion();
            config.ActualizarLlave("nombreConcurso", txtNombreConcurso.Text);
            config.ActualizarLlave("cPreguntas", txtCPreguntas.Text);
            config.ActualizarLlave("preguntas", txtPreguntas.Text);
            config.ActualizarLlave("equipos", txtEquipos.Text);
            if (rbPredeterminado.IsChecked == true)
            {
                config.ActualizarLlave("tPreguntas", "Predeterminado");
            }
            else if (rbTiempo.IsChecked == true)
            {
                config.ActualizarLlave("tPreguntas", txtSegundos.Text);
            }
            else
            {
                config.ActualizarLlave("tPreguntas", "");
            }
            if (File.Exists(ConfigurationManager.AppSettings["banners"]))
            {
                banners.Guardar(ConfigurationManager.AppSettings["banners"]);
            }
            else
            {
                config.ActualizarLlave("banners", "banners.xml");
                banners.Guardar(string.IsNullOrEmpty(ConfigurationManager.AppSettings["banners"])
                                    ? "banners.xml"
                                    : ConfigurationManager.AppSettings["banners"]);
            }
            config.ActualizarLlave("btnEquipo1", _btnEq1);
            config.ActualizarLlave("btnEquipo2", _btnEq2);
            config.Guardar();
            MessageBox.Show("Se reiniciara la aplicacion para que los cambios surtan efecto", "Configuraciones",
                            MessageBoxButton.OK, MessageBoxImage.Information);
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
            Close();

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnListaPreguntas_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog abrirListaPreguntas = new OpenFileDialog { Filter = "Archivos Xml | *.xml", Title = "Abrir lista de Preguntas" };
            if (abrirListaPreguntas.ShowDialog() == true)
            {
                txtPreguntas.Text = abrirListaPreguntas.FileName;
            }
        }

        private void btnListaEquipos_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog abrirListaEquipos = new OpenFileDialog { Filter = "Archivos Xml | *.xml", Title = "Abrir lista de Equipos" };
            if (abrirListaEquipos.ShowDialog() == true)
            {
                txtEquipos.Text = abrirListaEquipos.FileName;
            }
        }

        private void btnCalibrarBotones_Click(object sender, RoutedEventArgs e)
        {
            AsistenteCalibracionWindow asistente = new AsistenteCalibracionWindow();
            asistente.ShowDialog();
            _btnEq1 = asistente.BotonEquipo1;
            _btnEq2 = asistente.BotonEquipo2;
        }

    }
}
