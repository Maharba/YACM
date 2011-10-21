using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MenuPrincipal
{
    public class Proyector
    {
        public static event EventHandler PantallaMostrada;
        public static event EventHandler PantallaNoMostrada;

        public static void MostrarEnProyector(Window pantalla)
        {
            if (System.Windows.Forms.Screen.AllScreens.Length > 1)
            {
                pantalla.WindowStartupLocation = WindowStartupLocation.Manual;
                System.Drawing.Rectangle workingArea = System.Windows.Forms.Screen.AllScreens[1].WorkingArea;
                pantalla.Left = workingArea.Left;
                pantalla.Top = workingArea.Top;
                pantalla.Width = workingArea.Width;
                pantalla.Height = workingArea.Height;
                pantalla.WindowStyle = WindowStyle.None;
                pantalla.Topmost = true;
                pantalla.Show();
                if (PantallaMostrada != null)
                    PantallaMostrada(null, new EventArgs());
            }
            else
            {
                if (PantallaNoMostrada != null)
                    PantallaNoMostrada(null, new EventArgs());
                pantalla.Show();
            }
        }        

    }
}
