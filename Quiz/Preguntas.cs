using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Quiz
{
	[Serializable]
	public class Preguntas
	{
		#region Constructores

		//public Preguntas(byte nivel, string pregunta, ushort valor, string respuesta, TimeSpan tiempo)
		//{
		//    this.Nivel = nivel;
		//    this.PreguntaPresentador = pregunta;
		//    this.Valor = valor;
		//    this.Respuesta = respuesta;
		//    this.Tiempo = tiempo;
		//}

		//public Preguntas(byte nivel, string preguntaPresentador, string preguntaPantalla, ushort valor, string respuesta, TimeSpan tiempo)
		//{
		//    this.Nivel = nivel;
		//    this.PreguntaPresentador = preguntaPresentador;
		//    this.PreguntaPantalla = preguntaPantalla;
		//    this.Valor = valor;
		//    this.Respuesta = respuesta;
		//    this.Tiempo = tiempo;
		//} 
		#endregion
		
		#region Propiedades
		[XmlAttribute]
		public byte Nivel { get; set; }

		[XmlElement]
		public string PreguntaPresentador { get; set; }

		[XmlElement]
		public string PreguntaPantalla { get; set; }

		[XmlAttribute]
		public ushort Valor { get; set; }

		[XmlElement]
		public string Respuesta { get; set; }

		[XmlAttribute]
		public int Tiempo { get; set; }
		#endregion
	}
}