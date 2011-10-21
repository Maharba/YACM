using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;
using System.Xml;
using Microsoft.Win32;
using Quiz;
using System.Diagnostics;
using Quiz.Acciones;
using Quiz.Serializador;

namespace CapturadorPreguntas
{
    /// <summary>
    /// Interaction logic for AdminQuiz.xaml
    /// </summary>
    public partial class QuizAdmin
    {
        private readonly PreguntasSerializador _lp = new PreguntasSerializador();
        private FileSystemWatcher _watcher;
        public static ListaPreguntas Pregs = new ListaPreguntas();
        private string _nombreArchivoPregs;

        public QuizAdmin()
        {
            InitializeComponent();
        }

        private void LvPreguntasSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            if (lvPreguntas.SelectedIndex != -1)
            {
                cbCategoria.Text = (lvPreguntas.SelectedItem as Preguntas).Categoria;
                txtPregunta.Text = (lvPreguntas.SelectedItem as Preguntas).Pregunta;
                cbPuntuacion.Text = (lvPreguntas.SelectedItem as Preguntas).Puntuacion;
                cbRespuesta.Text = (lvPreguntas.SelectedItem as Preguntas).Respuesta;
                txtTiempo.Text = (lvPreguntas.SelectedItem as Preguntas).Tiempo;
            }          */
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog { Filter = "Archivo XML|*.xml|Archivo binario|*.dat" };
            if ((bool)opFile.ShowDialog())
            {
                _nombreArchivoPregs = opFile.SafeFileName;
                Pregs.Lista = _lp.LeerXml(opFile.FileName);
                lvPreguntas.ItemsSource = Pregs.Lista;
            }
            else
            {
                MessageBox.Show("Archivo de preguntas no encontrado.\nSe creará uno vacío.", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                _nombreArchivoPregs = "Sin título";
                XmlWriter.Create(_nombreArchivoPregs);
                lvPreguntas.ItemsSource = Pregs.Lista;
            }
            Title = _nombreArchivoPregs + " - Administrador de Preguntas";
            _watcher = new FileSystemWatcher { Path = Directory.GetCurrentDirectory(), Filter = _nombreArchivoPregs };
            _watcher.Changed += WatcherChanged;
            _watcher.EnableRaisingEvents = true;
        }

        //TODO: No completo
        private void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("Se ha detectado cambios en " + _nombreArchivoPregs + ".\nHaga click en 'Ok' para recargar la lista", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            Process.Start(Application.ResourceAssembly.Location);

            //TODO: Implementar algo mejor que esta... chalanería.
            Application.Current.Shutdown();

            lvPreguntas.ItemsSource = null;
            _lp.LeerXml(_nombreArchivoPregs);
        }

        private void BtnAgregarClick(object sender, RoutedEventArgs e)
        {
            QuizEditor qzEditor = new QuizEditor(QuizEditor.Modo.Agregar);
            qzEditor.ShowDialog();
        }

        private void BtnModificarClick(object sender, RoutedEventArgs e)
        {
            if (lvPreguntas.SelectedIndex != -1)
            {
                QuizEditor qzEditor = new QuizEditor(lvPreguntas.SelectedItem as Preguntas, QuizEditor.Modo.Modificar);
                qzEditor.ShowDialog();
            }
            else
            {
                MostrarAdvertenciaSeleccion("modificar");
            }
        }

        private void BtnCerrarClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEliminarClick(object sender, RoutedEventArgs e)
        {
            if (lvPreguntas.SelectedIndex != -1)
            {
                if (MessageBox.Show("¿Desea eliminar la pregunta seleccionada?", "Eliminar Pregunta",
                                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    PreguntasAcciones pAccion = new PreguntasAcciones(Pregs);
                    pAccion.Eliminar(lvPreguntas.SelectedItem as Preguntas);
                    lvPreguntas.Items.Refresh();
                }
            }
            else
            {
                MostrarAdvertenciaSeleccion("eliminar");
            }
        }

        private void MostrarAdvertenciaSeleccion(string nombre)
        {
            MessageBox.Show(this, "Seleccione una pregunta primero para poder " + nombre, "Ops!", MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _watcher.EnableRaisingEvents = false;
            var guardarCambios = MessageBox.Show("¿Desea guardar los cambios hechos?", "¿Guardar cambios?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (guardarCambios)
            {
                case MessageBoxResult.Yes:
                    GuardarMeuItemClick(this, new RoutedEventArgs());
                    //_lp.EscribirXml(_nombreArchivoPregs, Pregs);
                    break;
                case MessageBoxResult.Cancel:
                    e.Cancel = true;
                    break;
            }
            Pregs = new ListaPreguntas();
        }

        private void NuevoMenuItemClick(object sender, RoutedEventArgs e)
        {
            var guardarCambios = MessageBox.Show("¿Desea guardar los cambios hechos en " + _nombreArchivoPregs + "?", "¿Guardar cambios?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (guardarCambios)
            {
                case MessageBoxResult.Yes:
                    _lp.EscribirXml(_nombreArchivoPregs, Pregs);
                    break;
                case MessageBoxResult.Cancel:
                    return;
            }
            Pregs = new ListaPreguntas();
            lvPreguntas.ItemsSource = Pregs.Lista;
            _nombreArchivoPregs = string.Empty;
            Title = "Sin título - Administrador de Preguntas";
        }

        private void AbrirMenuItemClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog() { Filter = "Archivos XML|*.xml|Archivos binarios|*.dat" };
            if (!((bool)openDialog.ShowDialog())) return;
            _nombreArchivoPregs = openDialog.FileName;
            if (openDialog.FilterIndex == 1)
                Pregs.Lista = _lp.LeerXml(_nombreArchivoPregs);
            else if (openDialog.FilterIndex == 2)
                Pregs.Lista = _lp.LeerBin(_nombreArchivoPregs);
            lvPreguntas.ItemsSource = Pregs.Lista;
            Title = _nombreArchivoPregs + " - Administrador de Preguntas";
        }

        private void CerrarMenuItemClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GuardarMeuItemClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog() { Filter = "Archivos XML|*.xml|Archivos binarios|*.dat" };
            if (!((bool)saveDialog.ShowDialog())) return;
            _nombreArchivoPregs = saveDialog.FileName;
            if (saveDialog.FilterIndex == 1)
                _lp.EscribirXml(_nombreArchivoPregs, Pregs);
            else if (saveDialog.FilterIndex == 2)
                _lp.EscribirBin(_nombreArchivoPregs, Pregs);
            Title = _nombreArchivoPregs + " - Administrador de Preguntas";
        }

        private void AcercaDeMenuItemClick(object sender, RoutedEventArgs e)
        {
            //TODO: Implementar el cuadro del acerca de...
        }
    }
}
