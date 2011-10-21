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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Quiz;
using Quiz.Acciones;

namespace CapturadorPreguntas
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class QuizEditor : Window
	{
		public enum Modo
		{
			Agregar, Modificar
		}

		readonly Modo _modo;
		readonly Preguntas _preg = new Preguntas();

		public QuizEditor(Modo modo)
		{
			InitializeComponent();
			_modo = modo;
		}

		public QuizEditor(Preguntas preg, Modo modo)
		{
			InitializeComponent();
			_preg = preg;
			txtPregPantalla.Text = preg.PreguntaPantalla;
			txtPregPresentador.Text = preg.PreguntaPresentador;
			txtRespuesta.Text = preg.Respuesta;
			txtTiempo.Text = preg.Tiempo.ToString();
			cbCategoria.Text = preg.Nivel.ToString();
			cbPuntuacion.Text = preg.Valor.ToString();
			_modo = modo;
		}

		private void BtnCancelarClick(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BtnAceptarClick(object sender, RoutedEventArgs e)
		{
			PreguntasAcciones pregAccion;
			switch (_modo)
			{
				case Modo.Agregar:
					pregAccion = new PreguntasAcciones(QuizAdmin.Pregs);

					try
					{
						pregAccion.Agregar(txtPregPresentador.Text, txtPregPantalla.Text, txtRespuesta.Text, byte.Parse(cbCategoria.Text), ushort.Parse(cbPuntuacion.Text), int.Parse(txtTiempo.Text));
					}
					catch (FormatException)
					{
						MessageBox.Show(this, "Por favor, llene todos los campos antes de agregar una nueva pregunta.",
										"Atención", MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					catch (ArgumentNullException)
					{
						MessageBox.Show(this, "Por favor, llene todos los campos antes de agregar una nueva pregunta.",
									   "Atención", MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					break;
				case Modo.Modificar:
					pregAccion = new PreguntasAcciones(QuizAdmin.Pregs);
					foreach (var p in QuizAdmin.Pregs.Lista.Where(p => p == _preg))
					{
						try
						{
							pregAccion.Modificar(p, txtPregPantalla.Text, txtPregPresentador.Text, txtRespuesta.Text, byte.Parse(cbCategoria.Text), ushort.Parse(cbPuntuacion.Text), int.Parse(txtTiempo.Text));
						}
						catch (FormatException)
						{
							MessageBox.Show(this, "Por favor, llene todos los campos.",
										"Atención", MessageBoxButton.OK, MessageBoxImage.Hand);
							return;
						}
						catch (ArgumentNullException)
						{
							MessageBox.Show(this, "Por favor, llene todos los campos.",
										   "Atención", MessageBoxButton.OK, MessageBoxImage.Hand);
							return;
						}
						break;
					}
					break;
			}
			Close();
		}

		private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		}

		private void WindowLoaded(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
