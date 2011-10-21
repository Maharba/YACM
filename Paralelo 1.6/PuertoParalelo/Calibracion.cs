using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Configuration;

namespace PuertoParalelo
{
    public delegate void unDelegadoHandler();
    public class Calibracion
    {
        private string _bitsDefault;
        private string _bitsEquipo1;
        private string _bitsEquipo2;
        private volatile string _result;
        private static Calibracion _instancia;
        public event PropertyChangedEventHandler PropertyChanged;
        public event BotonPresionadoEventHandler BotonPresionado;




        public event unDelegadoHandler BotonAPresionado;
        public event unDelegadoHandler BotonBPresionado;


        public delegate void BotonPresionadoEventHandler(object sender, BotonPresionadoEventArgs e);

        public string BitsDefault
        {
            get { return _bitsDefault; }
            set
            {
                if (_bitsDefault == value) return;
                _bitsDefault = value;
                RaisePropertyChanged("BitsDefault");
            }
        }

        public string BitsEquipo1
        {
            get { return _bitsEquipo1; }
            set
            {
                if (_bitsEquipo1 == value) return;
                _bitsEquipo1 = value;
                RaisePropertyChanged("BitsEquipo1");
            }
        }

        public string BitsEquipo2
        {
            get { return _bitsEquipo2; }
            set
            {
                if (_bitsEquipo2 == value) return;
                _bitsEquipo2 = value;
                RaisePropertyChanged("BitsEquipo2");
            }
        }

        // Raise PropertyChanged event
        void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public static Calibracion IniciarCalibracion()
        {
            return _instancia ?? (_instancia = new Calibracion());
        }

        private Calibracion()
        {
            int x = PortInterop.Input(889);
            BitsDefault = _result = Convert.ToString(x, 2).PadRight(8, '0');
            Thread.Sleep(100);
        }

        public void Calibrar(BotonConfigurar boton)
        {
            Monitorear();
            switch (boton)
            {
                case BotonConfigurar.A:
                    BitsEquipo1 = _result;
                    if (BotonPresionado != null)
                    {
                        BotonPresionado(this, new BotonPresionadoEventArgs { Boton = BotonConfigurar.A });
                    }
                    if (BitsEquipo1 == BitsEquipo2)
                    {
                        BitsEquipo2 = string.Empty;
                        Thread.CurrentThread.Abort();
                    }
                    break;
                case BotonConfigurar.B:
                    BitsEquipo2 = _result;
                    if (BotonPresionado != null)
                    {
                        BotonPresionado(this, new BotonPresionadoEventArgs { Boton = BotonConfigurar.B });
                    }
                    if (BitsEquipo2 == BitsEquipo1)
                    {
                        BitsEquipo1 = string.Empty;
                        Thread.CurrentThread.Abort();
                    }
                    break;
                case BotonConfigurar.Ninguno:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("boton");
            }
        }

        private void Monitorear()
        {
            do
            {
                //Obtiene la cadena de bits del puerto paralelo
                int x = PortInterop.Input(889);
                //La convierte a binario
                _result = Convert.ToString(x, 2).PadRight(8, '0');

                Thread.Sleep(100);
            } while (BitsDefault == _result);
        }

        public void MonitorearYDisparar()
        {
            Thread ts = new Thread(Monitorear);
            ts.Start();
            ts.Join();
            //Monitorear();
            if (_result == ConfigurationManager.AppSettings["btnEquipo1"])
            {
                BotonAPresionado();//(this, new EventArgs());
                ts.Abort();
            }
            else if (_result == ConfigurationManager.AppSettings["btnEquipo2"])
            {
                BotonBPresionado();//(this, new EventArgs());
                ts.Abort();
            }
            //BotonPresionado(this, new BotonPresionadoEventArgs { Boton =
        }

        public void SSSSS()
        {
            do
            {
                //Obtiene la cadena de bits del puerto paralelo
                int x = PortInterop.Input(889);
                //La convierte a binario
                _result = Convert.ToString(x, 2).PadRight(8, '0');

                Thread.Sleep(100);
            } while (BitsDefault == _result);
            if (_result == ConfigurationManager.AppSettings["btnEquipo1"])
            {
                BotonAPresionado();//(this, new EventArgs());
                //ts.Abort();
            }
            else if (_result == ConfigurationManager.AppSettings["btnEquipo2"])
            {
                BotonBPresionado();//(this, new EventArgs());
                //ts.Abort();
            }
        }
    }
}
