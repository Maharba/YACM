using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
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
using Equipos;
using Quiz;
using Quiz.Acciones;
using Quiz.Serializador;
using System.Collections.ObjectModel;
using PuertoParalelo;
using System.Threading;
using System.Windows.Threading;

namespace MenuPrincipal
{
    /// <summary>
    /// Interaction logic for wndAdminPantallas.xaml
    /// </summary>
    public partial class wndAdminPantallas : Window
    {
        public wndAdminPantallas()
        {
            InitializeComponent();
        }

        public wndAdminPantallas(wndPantallaPresentacion pantallaPresentacion)
        {
            InitializeComponent();
            _pantallaPresentacion = pantallaPresentacion;
        }

        #region Pantallas Proyector
        private wndPantallaConcurso _pantallaConcurso; //= new wndPantallaConcurso();
        private wndPantallaPresentacion _pantallaPresentacion;

        #region Comentado
        //void MostrarPantallaPresentacion()
        //{
        //    if (System.Windows.Forms.Screen.AllScreens.Length > 1)
        //    {
        //        _pantallaPresentacion=new wndPantallaPresentacion();
        //        _pantallaPresentacion.WindowStartupLocation = WindowStartupLocation.Manual;
        //        System.Drawing.Rectangle workingArea = System.Windows.Forms.Screen.AllScreens[1].WorkingArea;
        //        _pantallaPresentacion.Left = workingArea.Left;
        //        _pantallaPresentacion.Top = workingArea.Top;
        //        _pantallaPresentacion.Width = workingArea.Width;
        //        _pantallaPresentacion.Height = workingArea.Height;
        //        _pantallaPresentacion.WindowStyle = WindowStyle.None;
        //        _pantallaPresentacion.Topmost = true;
        //        _pantallaPresentacion.Show();
        //    }
        //    else
        //    {
        //        _pantallaPresentacion = new wndPantallaPresentacion();
        //        _pantallaPresentacion.Show();
        //    }
        //}
        //void MostrarPantallaConcurso()
        //{
        //    if (System.Windows.Forms.Screen.AllScreens.Length > 1)
        //    {
        //        pantallaConcurso = new wndPantallaConcurso();
        //        pantallaConcurso.WindowStartupLocation = WindowStartupLocation.Manual;
        //        System.Drawing.Rectangle workingArea = System.Windows.Forms.Screen.AllScreens[1].WorkingArea;
        //        pantallaConcurso.Left = workingArea.Left;
        //        pantallaConcurso.Top = workingArea.Top;
        //        pantallaConcurso.Width = workingArea.Width;
        //        pantallaConcurso.Height = workingArea.Height;
        //        pantallaConcurso.WindowStyle = WindowStyle.None;
        //        pantallaConcurso.Topmost = true;
        //        pantallaConcurso.Show();
        //    }
        //    else
        //    {
        //        pantallaConcurso.Show();
        //    }
        //}
        #endregion
        private void btnMostrarPantalla_Click(object sender, RoutedEventArgs e)
        {

            _pantallaPresentacion.Closed -= _pantallaPresentacion_Closed;
            //_pantallaPresentacion = new wndPantallaPresentacion();


            if (lstEquipo1.SelectedIndex != -1 && lstEquipo2.SelectedIndex != -1)
            {
                _pantallaPresentacion.MostrarDatos(lstEquipo1.SelectedItem as Equipo, lstEquipo2.SelectedItem as Equipo);
                _pantallaPresentacion.sckFondoEquipo1.Background.Opacity = 0.2;
                _pantallaPresentacion.sckFondoEquipo2.Background.Opacity = 0.2;
                //Proyector.MostrarEnProyector(_pantallaPresentacion);
                _pantallaPresentacion.Topmost = true;
                _pantallaConcurso.Topmost = false;
                _pantallaPresentacion.Show();

            }
            else
            //Proyector.MostrarEnProyector(_pantallaPresentacion);
            {
                _pantallaPresentacion.Topmost = true;
                _pantallaConcurso.Topmost = false;
                _pantallaPresentacion.Show();

            }


            _pantallaPresentacion.Closed += _pantallaPresentacion_Closed;

            btnOcultarPantalla.IsEnabled = true;
            btnMostrarPantalla.IsEnabled = false;
            btnMostrarPantalla.Background = Brushes.LightBlue;
            btnOcultarPantalla.Background = Brushes.Gray;
            //Proyector.MostrarEnProyector(_pantallaPresentacion);
            //_pantallaPresentacion = new wndPantallaPresentacion();
            //_pantallaPresentacion.Show();
        }



        private void btnOcultarPantalla_Click(object sender, RoutedEventArgs e)
        {

            _pantallaPresentacion.Hide();
            btnMostrarPantalla.IsEnabled = true;
            btnOcultarPantalla.IsEnabled = false;
            btnMostrarPantalla.Background = Brushes.Gray;
            btnOcultarPantalla.Background = Brushes.LightBlue;

            //_pantallaPresentacion.Close();            
        }

        #endregion
        ListaEquipos listaEquipos = new ListaEquipos();
        //MediaElement Buzz = new MediaElement();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Buzz.Source = new Uri("Buzz.wav");
            //Buzz.LoadedBehavior = MediaState.Manual;
            //Proyector.MostrarEnProyector(pantallaConcurso);
            //Proyector.MostrarEnProyector(_pantallaPresentacion);
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["btnEquipo1"]) && string.IsNullOrEmpty(ConfigurationManager.AppSettings["btnEquipo2"]))
            {
                MessageBox.Show("No ha calibrado los botones.\nNo podrá iniciar el concurso hasta que configurlos");
                Close();
            }

            cal = Calibracion.IniciarCalibracion();

            cal.BotonAPresionado += new unDelegadoHandler(cal_BotonAPresionado);
            cal.BotonBPresionado += new unDelegadoHandler(cal_BotonBPresionado);
            try
            {
                listaEquipos.Cargar(ConfigurationManager.AppSettings["equipos"]);
                lstEquipo1.ItemsSource = listaEquipos.Lista;
                lstEquipo2.ItemsSource = listaEquipos.Lista;
                //_pantallaPresentacion = new wndPantallaPresentacion();
                _pantallaPresentacion.Closed += _pantallaPresentacion_Closed;

                _pantallaConcurso = new wndPantallaConcurso(this);

                Proyector.PantallaMostrada += Proyector_PantallaMostrada;
                Proyector.PantallaNoMostrada += Proyector_PantallaNoMostrada;
                if (lstEquipo1.ItemsSource == null || lstEquipo2.ItemsSource == null)
                {
                    MessageBox.Show("No puede mostrarse la pantalla de presentación sin equipos registrados");
                    btnMostrarPantalla.IsEnabled = false;
                    btnOcultarPantalla.IsEnabled = false;
                    btnNuevaRonda.IsEnabled = false;
                    return;
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("No se encuentra el archivo de equipos.\nVerifique las configuraciones generales.", "Administrador De Pantallas", MessageBoxButton.OK, MessageBoxImage.Error);
                this.IsEnabled = false;
                lstEquipo1.ItemsSource = null;
                lstEquipo2.ItemsSource = null;
            }
            catch (SerializationException)
            {
                MessageBox.Show("El archivo de equipos no es valido\nCargue otro en las configuraciones generales.", "Administrador De Pantallas", MessageBoxButton.OK, MessageBoxImage.Error);
                this.IsEnabled = false;
                lstEquipo1.ItemsSource = null;
                lstEquipo2.ItemsSource = null;
            }
            try
            {
                ReciclarPreguntas.CargarPreguntas();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("No se encuentra el archivo de preguntas\nVerifique las configuraciones generales.", "Administrador De Pantallas", MessageBoxButton.OK, MessageBoxImage.Error);
                this.IsEnabled = false;
            }
            catch (SerializationException)
            {
                MessageBox.Show("El archivo de preguntas no es valido\nCargue otro en las configuraciones generales.", "Administrador De Pantallas", MessageBoxButton.OK, MessageBoxImage.Error);
                this.IsEnabled = false;
            }
        }

        void Proyector_PantallaNoMostrada(object sender, EventArgs e)
        {
            MessageBox.Show(
                    "No se ha detectado un proyector conectado.\nLa ventana de presentación se mostrará en el escritorio actual",
                    "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        void Proyector_PantallaMostrada(object sender, EventArgs e)
        {

        }

        private void _pantallaPresentacion_Closed(object sender, EventArgs e)
        {
            btnMostrarPantalla.IsEnabled = true;
            btnOcultarPantalla.IsEnabled = false;
        }

        private void btnNuevaRonda_Click(object sender, RoutedEventArgs e)
        {
            _pantallaPresentacion.sckFondoEquipo1.Opacity = 1;
            _pantallaPresentacion.sckFondoEquipo2.Opacity = 1;
            _pantallaPresentacion.Limpiar();
            //_pantallaPresentacion.lblPEquipo1.Text = string.Empty;
            //_pantallaPresentacion.lblE1Integrante1.Text = string.Empty;
            //_pantallaPresentacion.lblE1Integrante2.Text = string.Empty;
            //_pantallaPresentacion.lblE1Integrante3.Text = string.Empty;
            //_pantallaPresentacion.lblPEquipo2.Text = string.Empty;
            //_pantallaPresentacion.lblE2Integrante1.Text = string.Empty;
            //_pantallaPresentacion.lblE2Integrante2.Text = string.Empty;
            //_pantallaPresentacion.lblE2Integrante3.Text = string.Empty;


            if (lstEquipo1.SelectedIndex == -1 || lstEquipo2.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione los 2 Equipos a enfrentarse");
            }
            else{
            if (lstEquipo1.SelectedIndex == lstEquipo2.SelectedIndex)
                {
                    MessageBox.Show("Los Equipos son los mismos, elija 2 equipos diferentes");
                }
                else
                {

                    ReciclarPreguntas.equipo1 = lstEquipo1.SelectedItem as Equipo;
                    ReciclarPreguntas.equipo2 = lstEquipo2.SelectedItem as Equipo;

                    if (ReciclarPreguntas.ExistenPreguntas() == false)
                    {
                        _pantallaPresentacion.sckFondoEquipo1.Opacity = 0;
                        _pantallaPresentacion.sckFondoEquipo2.Opacity = 0;
                        //TODO:Mejorar el messagebox añadiendole las sugerencias y quitar los cuadros
                        MessageBox.Show("No hay suficientes preguntas de ese nivel");
                    }
                    else
                    {

                        _pantallaPresentacion.MostrarDatos(lstEquipo1.SelectedItem as Equipo,
                                                           lstEquipo2.SelectedItem as Equipo);
                        _pantallaPresentacion.sckFondoEquipo1.Background.Opacity = 0.2;
                        _pantallaPresentacion.sckFondoEquipo2.Background.Opacity = 0.2;
                        lbEquipo1.Text = lstEquipo1.SelectedItem.ToString();
                        lbEquipo2.Text = lstEquipo2.SelectedItem.ToString();
                        txtPreguntaPresentador.Text = string.Empty;
                        txtPuntosPregunta.Text = string.Empty;
                        txtRespuesta.Text = string.Empty;
                        btnIniciarTiempo.IsEnabled = false;
                        btnSiguiente.IsEnabled = true;
                        btnTerminar.IsEnabled = true;
                        txtPuntosE1.Text = "0";
                        txtPuntosE2.Text = "0";
                        btnModPuntosE1.IsEnabled = true;
                        btnModPuntosE2.IsEnabled = true;
                        btnDeshacerPuntuacion.IsEnabled = true;
                        lblCantPreg.Text = string.Format("0 de {0}", ReciclarPreguntas.ListaDisponibles.Count);
                        _pantallaConcurso.EstablecerEquipos(ReciclarPreguntas.equipo1.NombreEquipo,
                                                            ReciclarPreguntas.equipo2.NombreEquipo);
                        //ReciclarPreguntas.NuevaRonda();
                        puntajeE1 = 0;
                        puntajeE2 = 0;
                        _pantallaConcurso.EstablecerPuntaje(1, puntajeE1);
                        _pantallaConcurso.EstablecerPuntaje(2, puntajeE2);
                        _pantallaConcurso.LimpiarPantalla();
                        (_undoStack = new Stack<Marcador>()).Push(new Marcador(0, 0));
                        noPregunta = 1;
                        ReciclarPreguntas.InicioRonda();
                    }

                }

            }
        }

        private Preguntas preguntaActual = new Preguntas();
        private int noPregunta = 1;
        Calibracion cal;
        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            //_pantallaConcurso.Topmost = true;



            _pantallaPresentacion.Topmost = false;
            btnMostrarPantalla.IsEnabled = true;
            btnOcultarPantalla.IsEnabled = false;
            if (!_pantallaConcurso.IsLoaded)
            {
                Proyector.MostrarEnProyector(_pantallaConcurso);
                //_pantallaConcurso.Show();
            }
            btnSiguiente.IsEnabled = false;
            btnIniciarTiempo.IsEnabled = true;
            //preguntaActual = ReciclarPreguntas.SiguientePregunta();
            preguntaActual = ReciclarPreguntas.ListaRonda[noPregunta - 1];
            if (preguntaActual != null)
            {
                _pantallaConcurso.LimpiarPantalla();
                txtPreguntaPresentador.Text = preguntaActual.PreguntaPresentador;
                txtRespuesta.Text = preguntaActual.Respuesta;
                txtPuntosPregunta.Text = preguntaActual.Valor.ToString();
                lblCantPreg.Text = string.Format("{0} de {1}", ReciclarPreguntas.ListaDisponibles.IndexOf(preguntaActual) + 1, ReciclarPreguntas.ListaDisponibles.Count);
                btnIniciarTiempo.IsEnabled = true;
                btnSiguiente.IsEnabled = false;
                _pantallaConcurso.txtPregunta.Text = string.Format("Pregunta No. {0}", noPregunta);
                noPregunta++;
            }
            else
            {
                MessageBox.Show(string.Format("No hay preguntas de nivel {0} en el archivo de preguntas", ReciclarPreguntas.ObtenerNivelPreguntas()), "Error", MessageBoxButton.OK, MessageBoxImage.Error);//Mensaje de prueba;                
            }
        }

        void cal_BotonBPresionado()
        {
            
            if (btnPausarTiempo.Dispatcher.Thread == Thread.CurrentThread)
            {
                //_pantallaConcurso.MostrarMensaje("Equipo 2");
                //_pantallaConcurso.txtRespuesta.Text = "Equipo2";
                //Buzz.Play();
                //_pantallaConcurso.txtRespuesta.Visibility = Visibility.Visible;
                if (_pantallaConcurso.Tiempo.Content.ToString() != "00:00:00")
                {
                    _pantallaConcurso.EquipoPresionoBoton(ReciclarPreguntas.equipo2.NombreEquipo);
                    _pantallaConcurso.DetenerTimer();
                    btnPausarTiempo.Content = "Continuar Tiempo";
                }
               
                //cal.BotonBPresionado -= cal_BotonBPresionado;
            }
            else
            {
                btnPausarTiempo.Dispatcher.Invoke(new unDelegadoHandler(cal_BotonBPresionado), null);
            }
            
        }

        void cal_BotonAPresionado()
        {
            try
            {
                if (btnPausarTiempo.Dispatcher.Thread == Thread.CurrentThread)
                {
                    //_pantallaConcurso.MostrarMensaje("Equipo 1");
                    //_pantallaConcurso.txtRespuesta.Text = "Equipo1";
                    //Buzz.Play();
                    //_pantallaConcurso.txtRespuesta.Visibility = Visibility.Visible;
                    if (_pantallaConcurso.Tiempo.Content.ToString()!="00:00:00")
                    {
                        _pantallaConcurso.EquipoPresionoBoton(ReciclarPreguntas.equipo1.NombreEquipo);
                        _pantallaConcurso.DetenerTimer();
                        btnPausarTiempo.Content = "Continuar Tiempo"; 
                    }
                    //cal.BotonAPresionado -= cal_BotonAPresionado;
                }
                else
                {
                    btnPausarTiempo.Dispatcher.Invoke(new unDelegadoHandler(cal_BotonAPresionado), null);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*
            _pantallaConcurso.MostrarMensaje("Equipo 1");
            _pantallaConcurso.DetenerTimer();
            btnPausarTiempo.Content = "Continuar Tiempo";
            cal.BotonAPresionado -= cal_BotonAPresionado;
             * */
        }

        private void FindeRonda()
        {
            
                if (puntajeE1>puntajeE2)
                {
                    _pantallaConcurso.txtPregunta.Text = string.Format("El equipo {0} ha ganado la ronda",
                                                                  ReciclarPreguntas.equipo1.NombreEquipo);
                }
                else if (puntajeE2>puntajeE1)
                {
                    _pantallaConcurso.txtPregunta.Text = string.Format("El equipo {0} ha ganado la ronda",
                                                                  ReciclarPreguntas.equipo2.NombreEquipo);
                }
                else
                {
                    _pantallaConcurso.txtPregunta.Text = "La ronda ha terminado en empate";
                }
                _pantallaConcurso.txtRespuesta.Text = string.Empty;
                _pantallaConcurso.Puntos.Content = "Puntos: 0";
                _pantallaConcurso.MostrarMensaje("Fin de la Ronda");
                txtPreguntaPresentador.Text = string.Empty;
                txtRespuesta.Text = string.Empty;
                txtPuntosPregunta.Text = string.Empty;
                lblCantPreg.Text = string.Format("0 de {0}", ReciclarPreguntas.ListaDisponibles.Count);
                lbEquipo1.Text = "Equipo 1";
                lbEquipo2.Text = "Equipo 2";
                btnModPuntosE1.IsEnabled = false;
                btnModPuntosE2.IsEnabled = false;
                btnDeshacerPuntuacion.IsEnabled = false;
                btnSiguiente.IsEnabled = false;
                btnAcertoE1.IsEnabled = false;
                btnAcertoE2.IsEnabled = false;
                btnNadieAcerto.IsEnabled = false;
                btnIniciarTiempo.IsEnabled = false;
                btnTerminar.IsEnabled = false;
                _pantallaPresentacion.Limpiar();
                ReciclarPreguntas.ListaRonda.Clear();
            

        }
        int puntajeE1;
        private void btnAcertoE1_Click(object sender, RoutedEventArgs e)
        {
            ReciclarPreguntas.PreguntaCorrecta(preguntaActual);
            //_pantallaConcurso.EquipoPresionoBoton(ReciclarPreguntas.equipo1.NombreEquipo); Linea solo para pruebas
            puntajeE1 = puntajeE1 + preguntaActual.Valor;
            _pantallaConcurso.EstablecerPuntaje(1, puntajeE1);
            _undoStack.Push(new Marcador(puntajeE1, puntajeE2));
            MostrarRespuesta();
            if (ReciclarPreguntas.ListaRonda.IndexOf(preguntaActual) + 1 == int.Parse(ConfigurationManager.AppSettings["cPreguntas"]))
            {
                FindeRonda();
            }
        }

        private void MostrarRespuesta()
        {
            _pantallaConcurso.DetenerTimer();
            _pantallaConcurso.txtRespuesta.Text = preguntaActual.Respuesta;
            _pantallaConcurso.txtRespuesta.Visibility = Visibility.Visible;
            btnPausarTiempo.IsEnabled = false;
            btnIniciarTiempo.IsEnabled = false;
            btnAcertoE1.IsEnabled = false;
            btnAcertoE2.IsEnabled = false;
            btnNadieAcerto.IsEnabled = false;
            btnSiguiente.IsEnabled = true;
        }
        int puntajeE2;
        private void btnAcertoE2_Click(object sender, RoutedEventArgs e)
        {
            ReciclarPreguntas.PreguntaCorrecta(preguntaActual);
            puntajeE2 = puntajeE2 + preguntaActual.Valor;
            _pantallaConcurso.EstablecerPuntaje(2, puntajeE2);
            _undoStack.Push(new Marcador(puntajeE1, puntajeE2));
            MostrarRespuesta();
            if (ReciclarPreguntas.ListaRonda.IndexOf(preguntaActual) + 1 == int.Parse(ConfigurationManager.AppSettings["cPreguntas"]))
            {
                FindeRonda();
            }

        }

        private void btnNadieAcerto_Click(object sender, RoutedEventArgs e)
        {
            _pantallaConcurso.MostrarMensaje("Nadie Acerto");
            MostrarRespuesta();
            if (ReciclarPreguntas.ListaRonda.IndexOf(preguntaActual) + 1 == int.Parse(ConfigurationManager.AppSettings["cPreguntas"]))
            {
                FindeRonda();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //_pantallaPresentacion.Close();
            if (_pantallaConcurso != null) _pantallaConcurso.Close();
            btnLimpiarPantalla_Click(null, null);
        }



        private void btnIniciarTiempo_Click(object sender, RoutedEventArgs e)
        {
            btnAcertoE1.IsEnabled = true;
            btnAcertoE2.IsEnabled = true;
            btnNadieAcerto.IsEnabled = true;
            btnSiguiente.IsEnabled = false;
            btnPausarTiempo.IsEnabled = true;
            btnIniciarTiempo.IsEnabled = false;

            //cal = Calibracion.IniciarCalibracion();
            

            //Thread hiloMonitorBoton = new Thread(cal.MonitorearYDisparar);
            //hiloMonitorBoton.Start();


            //Proyector.MostrarEnProyector(pantallaConcurso);
            if (preguntaActual == null)
            {
                MessageBox.Show("No puede iniciarse el concurso sin haber cargado alguna pregunta", "Error",
                                MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            _pantallaConcurso.EstablecerDatos(preguntaActual.PreguntaPantalla, preguntaActual.Respuesta,
                                             preguntaActual.Valor,
                                             ConfigurationManager.AppSettings["tPreguntas"] == "Predeterminado"
                                                 ? TimeSpan.FromSeconds(double.Parse(preguntaActual.Tiempo.ToString())+1)
                                                 : TimeSpan.FromSeconds(
                                                     double.Parse(ConfigurationManager.AppSettings["tPreguntas"])+1));
            _pantallaConcurso.IniciarTimer();
            //cal.MonitorearYDisparar();
            //Thread sds = new Thread(cal.SSSSS);
            sds = new Thread(cal.SSSSS);
            sds.Start();
        }

        Thread sds;

        private void btnPausarTiempo_Click(object sender, RoutedEventArgs e)
        {
            if (btnPausarTiempo.Content.ToString() == "Pausar Tiempo")
            {
                _pantallaConcurso.DetenerTimer();
                btnPausarTiempo.Content = "Continuar Tiempo";
            }
            else
            {
                _pantallaConcurso.IniciarTimer();
                btnPausarTiempo.Content = "Pausar Tiempo";
            }
        }

        private void btnModPuntosE1_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Reemplazar las textbox por maskedtextbox que solo acepten numeros
            if (!string.IsNullOrWhiteSpace(txtPuntosE1.Text))
            {
                try
                {
                    _pantallaConcurso.EstablecerPuntaje(1, int.Parse(txtPuntosE1.Text));
                    puntajeE1 = int.Parse(txtPuntosE1.Text);
                    //puntajeE2 = int.Parse(txtPuntosE2.Text);
                    _undoStack.Push(new Marcador(puntajeE1, puntajeE2));
                }
                catch (FormatException formatException)
                {

                    MessageBox.Show(formatException.Message);
                }
            }
        }

        private void btnModPuntosE2_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Reemplazar las textbox por maskedtextbox que solo acepten numeros
            if (!string.IsNullOrWhiteSpace(txtPuntosE2.Text))
            {
                try
                {
                    _pantallaConcurso.EstablecerPuntaje(2, int.Parse(txtPuntosE2.Text));
                    //puntajeE1 = int.Parse(txtPuntosE1.Text);
                    puntajeE2 = int.Parse(txtPuntosE2.Text);
                    _undoStack.Push(new Marcador(puntajeE1, puntajeE2));
                }
                catch (FormatException formatException)
                {

                    MessageBox.Show(formatException.Message);
                }
            }
        }

        private Stack<Marcador> _undoStack;
        private void btnDeshacerPuntuacion_Click(object sender, RoutedEventArgs e)
        {
            btnNadieAcerto.IsEnabled = true;
            btnAcertoE1.IsEnabled = true;
            btnAcertoE2.IsEnabled = true;
            btnSiguiente.IsEnabled = false;
            try
            {
                if (_undoStack.Count == 1)
                {
                    puntajeE1 = 0;
                    puntajeE2 = 0;
                    _pantallaConcurso.EstablecerPuntaje(1, puntajeE1);
                    _pantallaConcurso.EstablecerPuntaje(2, puntajeE2);
                }
                else
                {
                    if (_undoStack.Peek().PuntosEquipo1 == puntajeE1 &&
                        _undoStack.Peek().PuntosEquipo2 == puntajeE2)
                        _undoStack.Pop();
                    Marcador mrc = _undoStack.Peek();
                    puntajeE1 = mrc.PuntosEquipo1;
                    puntajeE2 = mrc.PuntosEquipo2;
                    _pantallaConcurso.EstablecerPuntaje(1, puntajeE1);
                    _pantallaConcurso.EstablecerPuntaje(2, puntajeE2);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnLimpiarPantalla_Click(object sender, RoutedEventArgs e)
        {
            _pantallaPresentacion.sckFondoEquipo1.Opacity = 0;
            _pantallaPresentacion.sckFondoEquipo2.Opacity = 0;
            btnLimpiarPantalla.Background = Brushes.LightBlue;
            btnMostrarDatosPantalla.Background = Brushes.Gray;
            btnLimpiarPantalla.IsEnabled = false;
            btnMostrarDatosPantalla.IsEnabled = true;
        }

        private void btnMostrarDatosPantalla_Click(object sender, RoutedEventArgs e)
        {
            _pantallaPresentacion.sckFondoEquipo1.Opacity = 1;
            _pantallaPresentacion.sckFondoEquipo2.Opacity = 1;
            btnLimpiarPantalla.Background = Brushes.Gray;
            btnMostrarDatosPantalla.Background = Brushes.LightBlue;
            btnLimpiarPantalla.IsEnabled = true;
            btnMostrarDatosPantalla.IsEnabled = false;
        }

        private void btnTerminar_Click(object sender, RoutedEventArgs e)
        {
            FindeRonda();
        }

    }
}
