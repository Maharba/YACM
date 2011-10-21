using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CapturadorPreguntas;
using Registro_Equipos;
using MenuPrincipal;

namespace Principal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this._pantallaPresentacion = new wndPantallaPresentacion();
        }

        private string _descripcion;
        private wndPantallaPresentacion _pantallaPresentacion;

        private void txbLimpiarDescripcion(object sender, MouseEventArgs e)
        {
            _descripcion = string.Empty;
            txbDescripcion.Text = _descripcion;
            //imgPreview.Source = null;
        }

        private void txbPreguntas_MouseEnter(object sender, MouseEventArgs e)
        {
            _descripcion = "Captura las preguntas que serán usadas en el concurso";
            txbDescripcion.Text = _descripcion;

            //imgPreview.Source = new BitmapImage(new Uri("admin_preguntas.png"));
        }

        private void txbEquipos_MouseEnter(object sender, MouseEventArgs e)
        {
            _descripcion = "Registra los equipos a participar en el concurso, concursante por concursante.";
            txbDescripcion.Text = _descripcion;
            //imgPreview.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\admin_equipos.png"));
        }

        private void txbConcurso_MouseEnter(object sender, MouseEventArgs e)
        {
            _descripcion =
                "Inicia el concurso actual con los parámetros previamente definidos en las configuraciones generales.";
            txbDescripcion.Text = _descripcion;
            //imgPreview.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\admin_pantallas.png"));
        }

        private void txbConfig_MouseEnter(object sender, MouseEventArgs e)
        {
            _descripcion =
                "Cambia el nombre de concurso, las cápsulas informativas, carga los equipos a concursar y las preguntas a usar; la cantidad de tiempo por pregunta y el número de ellas por ronda";
            txbDescripcion.Text = _descripcion;
            //imgPreview.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\config.png"));
        }

        private void txbSalir_MouseEnter(object sender, MouseEventArgs e)
        {
            _descripcion = "Cierra el Administrador de Concursos.";
            txbDescripcion.Text = _descripcion;
            
        }

        private void txbPreguntas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new QuizAdmin().ShowDialog();
        }

        private void txbSalir_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void txbEquipos_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new RegistroEquipos().ShowDialog();
        }

        private void txbConcurso_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new wndAdminPantallas(_pantallaPresentacion).Show();
        }

        private void txbConfig_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new wndConfig().ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Proyector.MostrarEnProyector(_pantallaPresentacion);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
