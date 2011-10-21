using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Windows.Threading;
using Equipos;
using Timer = System.Timers.Timer;

namespace MenuPrincipal
{
    /// <summary>
    /// Interaction logic for wndPantallaPresentacion.xaml
    /// </summary>
    public partial class wndPantallaPresentacion : Window
    {
        public wndPantallaPresentacion()
        {
            InitializeComponent();
        }
        public void MostrarDatos(Equipo equipo1, Equipo equipo2)
        {
            InitializeComponent();
            lblPEquipo1.Text = string.Format("Equipo 1: {0}", equipo1.NombreEquipo);
            lblE1Integrante1.Text = string.Format("1. {0} .- {1}", equipo1.Concursantes[0].NoControl, equipo1.Concursantes[0].NombreAlumno);
            if (equipo1.Concursantes.Count == 2)
            {
                lblE1Integrante2.Text = string.Format("2. {0} .- {1}", equipo1.Concursantes[1].NoControl, equipo1.Concursantes[1].NombreAlumno);


            }
            else if (equipo1.Concursantes.Count == 3)
            {
                lblE1Integrante2.Text = string.Format("2. {0} .- {1}", equipo1.Concursantes[1].NoControl, equipo1.Concursantes[1].NombreAlumno);
                lblE1Integrante3.Text = string.Format("3. {0} .- {1}", equipo1.Concursantes[2].NoControl, equipo1.Concursantes[2].NombreAlumno);
            }

            lblPEquipo2.Text = string.Format("Equipo 2: {0}", equipo2.NombreEquipo);
            lblE2Integrante1.Text = string.Format("1. {0} .- {1}", equipo2.Concursantes[0].NoControl, equipo2.Concursantes[0].NombreAlumno);

            if (equipo2.Concursantes.Count == 2)
            {
                lblE2Integrante2.Text = string.Format("2. {0} .- {1}", equipo2.Concursantes[1].NoControl, equipo2.Concursantes[1].NombreAlumno);
            }
            else if (equipo2.Concursantes.Count == 3)
            {
                lblE2Integrante2.Text = string.Format("2. {0} .- {1}", equipo2.Concursantes[1].NoControl, equipo2.Concursantes[1].NombreAlumno);
                lblE2Integrante3.Text = string.Format("3. {0} .- {1}", equipo2.Concursantes[2].NoControl, equipo2.Concursantes[2].NombreAlumno);

            }

        }
        Random r = new Random();
        ListaBanners lb = new ListaBanners();
        private DispatcherTimer _timer;
        private TimeSpan _lapso;
        private readonly TimeSpan _suma = new TimeSpan(0, 0, 1);
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblNombreConcurso.Text = ConfigurationManager.AppSettings["nombreConcurso"];
            lb.Cargar(ConfigurationManager.AppSettings["banners"]);
            //lb.Cargar("banners.xml");
            lblBanners.Text = lb.Lista[r.Next(lb.Lista.Count)].ToString();
            
            FadeInBanners();

            _timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += _timer_Tick;
            _timer.Start();
            //_timer = new Timer(1000);
            //_timer.Elapsed += _timer_Elapsed;
            //_timer.Start();
        }

        private void FadeInBanners()
        {
            DoubleAnimation da = new DoubleAnimation { From = 0, To = 1, Duration = TimeSpan.FromSeconds(2) };
            lblBanners.BeginAnimation(OpacityProperty, da);
        }

        private void FadeOutBanners()
        {
            DoubleAnimation dAnima = new DoubleAnimation { From = 1, To = 0, Duration = TimeSpan.FromSeconds(2) };
            lblBanners.BeginAnimation(OpacityProperty, dAnima);
        }

        private int _segundosLimite;
        void _timer_Tick(object sender, EventArgs e)
        {
            if (_segundosLimite < 30)
                _segundosLimite++;
            else
            {
                FadeOutBanners();
                _segundosLimite = 0;

                lblBanners.Text = lb.Lista[r.Next(lb.Lista.Count)];
                //Thread.Sleep(10);
                FadeInBanners();
                
            }
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_lapso.Seconds < 5)
                _lapso = _lapso.Add(_suma);
            else
            {
                _lapso = new TimeSpan(0, 0, 0);
                DoubleAnimation fadeIn = new DoubleAnimation(0, 1, new Duration(_suma));
                if (lblBanners.Dispatcher.Thread == Thread.CurrentThread)
                {
                    lblBanners.BeginAnimation(OpacityProperty, fadeIn);
                }
                else
                {
                    lblBanners.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                                      new EventHandler<ElapsedEventArgs>(_timer_Elapsed));
                }
            }
        }

        public void Limpiar()
        {           
            lblPEquipo1.Text = string.Empty;
            lblE1Integrante1.Text = string.Empty;
            lblE1Integrante2.Text = string.Empty;
            lblE1Integrante3.Text = string.Empty;
            lblPEquipo2.Text = string.Empty;
            lblE2Integrante1.Text = string.Empty;
            lblE2Integrante2.Text = string.Empty;
            lblE2Integrante3.Text = string.Empty;
        }

    }
}
