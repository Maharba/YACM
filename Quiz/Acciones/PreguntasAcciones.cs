using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Quiz.Acciones
{
    public class PreguntasAcciones
    {
        private readonly ListaPreguntas _preguntas = new ListaPreguntas();
        private Preguntas _nuevaPregunta;
        public PreguntasAcciones()
        { }

        public PreguntasAcciones(ListaPreguntas preguntas)
        {
            if (preguntas != null) _preguntas = preguntas;
        }

        public void Agregar(string preguntaPresentador, string preguntaPantalla, string respuesta, byte nivel, ushort valor, int tiempo)
        {
            if (string.IsNullOrEmpty(preguntaPresentador)) throw new ArgumentNullException("preguntaPresentador");
            if (string.IsNullOrEmpty(preguntaPantalla)) throw new ArgumentNullException("preguntaPantalla");
            if (string.IsNullOrEmpty(respuesta)) throw new ArgumentNullException("respuesta");
            _nuevaPregunta = new Preguntas
                                          {
                                              Nivel = nivel,
                                              Respuesta = respuesta,
                                              Valor = valor,
                                              PreguntaPantalla = preguntaPantalla,
                                              PreguntaPresentador = preguntaPresentador,
                                              Tiempo = tiempo
                                          };
            _preguntas.Lista.Add(_nuevaPregunta);
        }

        public void Modificar(Preguntas preg, string preguntaPantalla, string preguntaPresentador, string respuesta, byte nivel, ushort valor, int tiempo)
        {
            if (preg == null) throw new ArgumentNullException("preg");
            if (preguntaPantalla == null) throw new ArgumentNullException("preguntaPantalla");
            if (preguntaPresentador == null) throw new ArgumentNullException("preguntaPresentador");
            if (respuesta == null) throw new ArgumentNullException("respuesta");
            var indice = _preguntas.Lista.IndexOf(preg);
            _preguntas.Lista.Remove(preg);
            
            _nuevaPregunta = new Preguntas
                                 {
                                     Nivel = nivel,
                                     PreguntaPantalla = preguntaPantalla,
                                     PreguntaPresentador = preguntaPresentador,
                                     Respuesta = respuesta,
                                     Valor = valor,
                                     Tiempo = tiempo
                                 };

            _preguntas.Lista.Insert(indice, _nuevaPregunta);
        }
        
        public void Eliminar(Preguntas pregunta)
        {
            if (_preguntas.Lista != null) _preguntas.Lista.Remove(pregunta);
        }

        public ObservableCollection<Preguntas> ObtenerPreguntas()
        {
            return _preguntas.Lista ?? null;
        }
    }
}
