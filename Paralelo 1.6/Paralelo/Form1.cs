using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PuertoParalelo;
using WpfParalelo;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace Paralelo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string BitsDefault { get; set; }
        public string BitsEquipo1 { get; set; }
        public string BitsEquipo2 { get; set; }

        //private int equipo1;
        //private int equipo2;
        private string result;
        //private volatile bool _shouldStop;

        //Ya copiado...
        private enum Botones
        {
            A, B, Ninguno
        }

        void Metodo(Botones boton)
        {
            do {
                //Obtiene la cadena de bits del puerto paralelo
                int x = PortInterop.Input(889);
                //La convierte a binario
                result = Convert.ToString(x, 2).PadRight(8, '0');
                
                Thread.Sleep(100);
            } while (BitsDefault == result);
            switch (boton)
            {
                case Botones.A:
                    BitsEquipo1 = result;
                    if (BitsEquipo1 == BitsEquipo2) 
                    { 
                        BitsEquipo2 = string.Empty;
                        Thread.CurrentThread.Abort();
                    }
                    break;
                case Botones.B:
                    BitsEquipo2 = result;
                    if (BitsEquipo2 == BitsEquipo1)
                    {
                        BitsEquipo1 = string.Empty;
                        Thread.CurrentThread.Abort();
                    }
                    break;
                case Botones.Ninguno:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("boton");
            }
        }


        //delegate void Delegado(string r);

        //public void Cambiar(string res)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.BeginInvoke(new Delegado(Cambiar), new object[] { res });
        //    }
        //    else
        //    {
        //        this.Text = res;
        //        if (BitsDefault != res)
        //        {
        //            for (int i = 0; i < res.Length; i++)
        //            {
                        

        //            }
                    
        //            if (BitsEquipo1 != res)
        //            {
        //                BitsEquipo1 = res;
        //                txtEquipo1.Text = BitsEquipo1;
        //            }
        //            else if (BitsEquipo2 != res)
        //            {
        //                BitsEquipo2 = res;
        //                txtEquipo2.Text = BitsEquipo2;
        //            }

        //        }
        //    }
        //}

        private Thread t;
        private void button1_Click(object sender, EventArgs e)
        {
            //PortInterop.Output(888, 0);
            //ThreadStart ts = delegate { Metodo(Botones.Ninguno); };
            //if (chkbEq1.Checked && chkbEq2.Checked || !chkbEq1.Checked && !chkbEq2.Checked)
            //{
            //    return;
            //}
            //if (chkbEq1.Checked)
            //{
            //    ts = delegate { Metodo(Botones.A); };
            //}
            //else if (chkbEq2.Checked) { 
            //    ts = delegate { Metodo(Botones.B); };
            //}
            
            //t = new Thread(ts);
            //t.Start();
            //t.Join(new TimeSpan(0, 0, 0, 5));
            ////while (t.IsAlive)
            ////{
            ////    if (!string.IsNullOrEmpty(BitsEquipo1) && !string.IsNullOrEmpty(BitsEquipo2))
            ////        t.Abort();
            ////}
            //txtEquipo1.Text = BitsEquipo1;
            //txtEquipo2.Text = BitsEquipo2;

            Calibracion calibracion = Calibracion.IniciarCalibracion();
            ThreadStart ts = delegate { calibracion.Calibrar(BotonConfigurar.Ninguno); };
            if (chkbEq1.Checked && chkbEq2.Checked || !chkbEq1.Checked && !chkbEq2.Checked)
            {
                return;
            }
            if (chkbEq1.Checked)
                ts = () => calibracion.Calibrar(BotonConfigurar.A);
            else if (chkbEq2.Checked)
                ts = () => calibracion.Calibrar(BotonConfigurar.B);
            t = new Thread(ts);
            t.Start();
            t.Join(TimeSpan.FromSeconds(5));
            txtEquipo1.Text = calibracion.BitsEquipo1;
            txtEquipo2.Text = calibracion.BitsEquipo2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PortInterop.Output(888,255);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = PortInterop.Input(889);
            string s = Convert.ToString(x, 2).PadRight(8, '0');
            MessageBox.Show(s);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //int x = PortInterop.Input(889);
            //BitsDefault = result = Convert.ToString(x, 2).PadRight(8, '0');
            //Thread.Sleep(100);
        }

        

    }
}