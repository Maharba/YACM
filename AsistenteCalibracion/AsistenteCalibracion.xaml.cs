using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PuertoParalelo;
using System.Windows.Threading;

namespace AsistenteCalibracion
{
    /// <summary>
    /// Interaction logic for AsistenteCalibracionWindow.xaml
    /// </summary>
    public partial class AsistenteCalibracionWindow : Window
    {
        private Calibracion calibracion;

        public AsistenteCalibracionWindow()
        {
            InitializeComponent();
            _siguiente = 0;
            calibracion = Calibracion.IniciarCalibracion();
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            _animation.From = _siguiente;
            _siguiente += 510;
            _animation.To = _siguiente;
            Mover.BeginAnimation(TranslateTransform.XProperty, _animation);
            if (_siguiente == 0)
                btnAnterior.IsEnabled = false;

        }

        private int _siguiente;
        private DoubleAnimation _animation;
        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btnSiguiente.Content != "Finalizar")
            {
                _animation = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(0.5),
                    From = Mover.X,
                    AccelerationRatio = 0.5,
                    DecelerationRatio = 0.5
                };
                if (_siguiente <= 0)
                {
                    _siguiente -= 510;
                    if (_siguiente == -510)
                    {
                        btnCalibrar1.Visibility = Visibility.Visible;
                        btnSiguiente.IsEnabled = false;
                    }
                    else if (_siguiente == -1020)
                    {
                        btnCalibrar2.Visibility = Visibility.Visible;
                        btnSiguiente.IsEnabled = false;
                    }
                    _animation.To = _siguiente;
                    btnAnterior.IsEnabled = true;

                    if (_siguiente == -2040)
                    {
                        btnAnterior.IsEnabled = false;
                        btnCancelar.IsEnabled = false;
                        btnSiguiente.Content = "Finalizar";
                    }
                }
                else
                {
                    _siguiente -= 510;
                    _animation.To = _siguiente;
                }
                Mover.BeginAnimation(TranslateTransform.XProperty, _animation);
            }
            else
                this.Close();
        }

        private void CalibrarBotonB()
        {
            ThreadStart ts = () => calibracion.Calibrar(BotonConfigurar.B);
            t = new Thread(ts);
            t.Start();
            t.Join(TimeSpan.FromSeconds(5));
            BotonEquipo2 = calibracion.BitsEquipo2;
        }

        private Thread t;
        private string Equipo1;
        private string Equipo2;

        public string BotonEquipo1 { get; set; }
        public string BotonEquipo2 { get; set; }

        private void CalibrarBotonA()
        {
            ThreadStart ts = () => calibracion.Calibrar(BotonConfigurar.A);
            t = new Thread(ts);
            t.Start();
            t.Join(TimeSpan.FromSeconds(5));
            BotonEquipo1 = calibracion.BitsEquipo1;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            calibracion.BotonPresionado += new Calibracion.BotonPresionadoEventHandler(calibracion_BotonPresionado);
        }

        void IluminarBoton()
        {

        }

        DispatcherTimer timer1;

        void calibracion_BotonPresionado(object sender, BotonPresionadoEventArgs e)
        {
            if (e.Boton == BotonConfigurar.A)
            {
                if (elipseEquipo1.Dispatcher.Thread == Thread.CurrentThread)
                {
                    elipseEquipo1.Fill = Brushes.Red;
                    timer1 = new DispatcherTimer();
                    timer1.Interval = TimeSpan.FromSeconds(1);
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Start();
                }
                else
                    elipseEquipo1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new PuertoParalelo.Calibracion.BotonPresionadoEventHandler(calibracion_BotonPresionado), sender, new object[] { e });

                //Penúltima pantalla... prueba.
                if (_siguiente == -1530)
                {
                    if (elipseEquipo1_1.Dispatcher.Thread == Thread.CurrentThread)
                    {
                        elipseEquipo1_1.Fill = Brushes.Red;
                        timer1 = new DispatcherTimer();
                        timer1.Interval = TimeSpan.FromSeconds(1);
                        timer1.Tick += new EventHandler(timer1_Tick);
                        timer1.Start();
                    }
                    else
                        elipseEquipo1_1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new PuertoParalelo.Calibracion.BotonPresionadoEventHandler(calibracion_BotonPresionado), sender, new object[] { e });
                }
            }

            // Boton 2
            else if (e.Boton == BotonConfigurar.B)
            {

                //elipseEquipo2.Fill = Brushes.Red;
                if (elipseEquipo2.Dispatcher.Thread == Thread.CurrentThread)
                {
                    elipseEquipo2.Fill = Brushes.Red;
                    timer1 = new DispatcherTimer();
                    timer1.Interval = TimeSpan.FromSeconds(1);
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Start();
                }
                else
                    elipseEquipo2.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new PuertoParalelo.Calibracion.BotonPresionadoEventHandler(calibracion_BotonPresionado), sender, new object[] { e });

                if (_siguiente == -1530)
                {
                    //elipseEquipo1_2.Fill = Brushes.Red;
                    if (elipseEquipo1_2.Dispatcher.Thread == Thread.CurrentThread)
                    {
                        elipseEquipo1_2.Fill = Brushes.Red;
                        timer1 = new DispatcherTimer();
                        timer1.Interval = TimeSpan.FromSeconds(1);
                        timer1.Tick += new EventHandler(timer1_Tick);
                        timer1.Start();
                    }
                    else
                        elipseEquipo1_2.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new PuertoParalelo.Calibracion.BotonPresionadoEventHandler(calibracion_BotonPresionado), sender, new object[] { e });
                }
            }
        }

        int seconds = 0;
        void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds == 5)
            {
                btnSiguiente.IsEnabled = true;
                seconds = 0;
                timer1.Stop();
            }
        }

        private void btnCalibrar1_Click(object sender, RoutedEventArgs e)
        {
            CalibrarBotonA();
        }

        private void btnCalibrar2_Click(object sender, RoutedEventArgs e)
        {
            CalibrarBotonB();
        }
    }
}
