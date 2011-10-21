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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;

namespace MenuPrincipal
{
    /// <summary>
    /// Interaction logic for wndPantallaConcurso.xaml
    /// </summary>
    public partial class wndPantallaConcurso : Window
    {
        public wndPantallaConcurso()
        {
            InitializeComponent();
        }

        public wndPantallaConcurso(wndAdminPantallas admin)
        {
            InitializeComponent();
            _admin = admin;
        }

        DispatcherTimer timer = new DispatcherTimer();

        string pregunta;
        string respuesta;
        int valor;
        TimeSpan tiempoPregunta;
        private readonly wndAdminPantallas _admin;

        public void EstablecerDatos(string pregunta, string respuesta, int valor, TimeSpan tiempo)
        {
            txtPregunta.Text = pregunta;
            tiempoPregunta = tiempo;
            Puntos.Content = string.Format("Puntos: {0}",valor);
        }

        public void EstablecerEquipos(string equipo1, string equipo2)
        {
            Equipo1.Content = equipo1;
            Equipo2.Content = equipo2;
            puntaje1.Value = 0;
            puntaje2.Value = 0;
            
        }

        public void EstablecerPuntaje(byte equipo, int puntaje)
        {
            DoubleAnimation d = new DoubleAnimation();

            if (equipo == 1)
            {

                d.From = puntaje1.Value;
                d.To = puntaje;
                d.Duration = TimeSpan.FromSeconds(1);

                puntaje1.BeginAnimation(Slider.ValueProperty, d);
            }
            else
            {
                d.From = puntaje2.Value;
                d.To = puntaje;
                d.Duration = TimeSpan.FromSeconds(1);

                puntaje2.BeginAnimation(Slider.ValueProperty, d);
            }

        }

        public delegate void mensajeDelegado(string c);

        public void MostrarMensaje(string mensaje)
        {
            if (this.Dispatcher.Thread == Thread.CurrentThread)
            {
                TextoMensaje.Text = mensaje;
                Storyboard story = (Storyboard)this.FindResource("animacionequipo");
                story.Begin();
            }
            else
            {
                this.Dispatcher.Invoke(new mensajeDelegado(MostrarMensaje), null);
            }
        }

        public void IniciarTimer()
        {
            timer.Start();
        }

        public void DetenerTimer()
        {
            timer.Stop();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //LimpiarPantalla();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
        }

        public void LimpiarPantalla()
        {
            txtPregunta.Text = string.Empty;
            txtRespuesta.Text = string.Empty;
            txtRespuesta.Visibility = Visibility.Hidden;
            Tiempo.Content = "00:00:00";
            Puntos.Content = "Puntos: 0";
            //EstablecerPuntaje(1,0);
            //EstablecerPuntaje(2,0);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            tiempoPregunta = tiempoPregunta.Subtract(new TimeSpan(0, 0, 1));
            Tiempo.Content = tiempoPregunta;

            if (tiempoPregunta == TimeSpan.FromSeconds(0))
            {
                //Se acabo el tiempo
                MostrarMensaje("Se acabo el tiempo");
                timer.Stop();
                _admin.btnPausarTiempo.IsEnabled = false;
            }
        }
        public void EquipoPresionoBoton(string nombreEquipo)
        {
            txtEquipoRespondio.Text = nombreEquipo;
            txtEquipoRespondio.Opacity = 1;
            //txtEquipoRespondio.Visibility = Visibility.Visible;
            DoubleAnimation dAnima = new DoubleAnimation { From = 1, To = 0, Duration = TimeSpan.FromSeconds(5) };
            //lblBanners.BeginAnimation(OpacityProperty, dAnima);
            txtEquipoRespondio.BeginAnimation(OpacityProperty,dAnima);
        }
    }
}
