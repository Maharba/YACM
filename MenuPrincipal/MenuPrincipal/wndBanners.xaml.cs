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

namespace MenuPrincipal
{
    /// <summary>
    /// Interaction logic for wndBanners.xaml
    /// </summary>
    public partial class wndBanners : Window
    {
        public wndBanners()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            wndConfig.banners.Lista.Add(txtBanner.Text);
            Close();
        }
    }
}
