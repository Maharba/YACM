using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using Equipos;
using Quiz;
using Quiz.Serializador;

namespace MenuPrincipal
{
    public class ReciclarPreguntas
    {
        public ReciclarPreguntas()
        {
            _listaDisponibles = new ObservableCollection<Preguntas>();

        }

        private static ObservableCollection<Preguntas> listaTodas = new ObservableCollection<Preguntas>();
        private static List<Preguntas> filtroPreguntas = new List<Preguntas>();//usada para obtener preguntas de un detarminado nivel                      
        static Random r = new Random();

        public static Equipo equipo1 { get; set; }
        public static Equipo equipo2 { get; set; }
        
        private static ObservableCollection<Preguntas> _listaDisponibles = new ObservableCollection<Preguntas>();
        public static ObservableCollection<Preguntas> ListaDisponibles { get { return _listaDisponibles; } set { _listaDisponibles = value; } }
        
        private static ObservableCollection<Preguntas> listaRonda = new ObservableCollection<Preguntas>();
        public static ObservableCollection<Preguntas> ListaRonda { get { return listaRonda; } }        

       

        public static void CargarPreguntas()
        {
            _listaDisponibles = new PreguntasSerializador().LeerXml(ConfigurationManager.AppSettings["preguntas"]);
            listaTodas = new PreguntasSerializador().LeerXml(ConfigurationManager.AppSettings["preguntas"]);
        }

        static void Reciclar()
        {
            _listaDisponibles.Clear();
            _listaDisponibles = new PreguntasSerializador().LeerXml(ConfigurationManager.AppSettings["preguntas"]);           
        }

        static int ObtenerNivelEquipo(Equipo equipo)
        {
            switch (equipo.Concursantes.Count)
            {
                case 3: if (int.Parse(equipo.Concursantes[0].Semestre) < int.Parse(equipo.Concursantes[1].Semestre) && int.Parse(equipo.Concursantes[0].Semestre) < int.Parse(equipo.Concursantes[2].Semestre))
                    {
                        return int.Parse(equipo.Concursantes[0].Semestre);
                    }
                    if (int.Parse(equipo.Concursantes[1].Semestre) < int.Parse(equipo.Concursantes[0].Semestre) && int.Parse(equipo.Concursantes[1].Semestre) < int.Parse(equipo.Concursantes[2].Semestre))
                    {
                        return int.Parse(equipo.Concursantes[1].Semestre);
                    }
                    if (int.Parse(equipo.Concursantes[2].Semestre) < int.Parse(equipo.Concursantes[0].Semestre) && int.Parse(equipo.Concursantes[2].Semestre) < int.Parse(equipo.Concursantes[1].Semestre))
                    {
                        return int.Parse(equipo.Concursantes[1].Semestre);
                    }
                    break;
                case 2: if (int.Parse(equipo.Concursantes[0].Semestre) < int.Parse(equipo.Concursantes[1].Semestre))
                    {
                        return int.Parse(equipo.Concursantes[0].Semestre);
                    }
                    if (int.Parse(equipo.Concursantes[0].Semestre) > int.Parse(equipo.Concursantes[1].Semestre))
                    {
                        return int.Parse(equipo.Concursantes[1].Semestre);
                    }
                    break;
            }
            return int.Parse(equipo.Concursantes[0].Semestre);
        }
        public static int ObtenerNivelPreguntas()
        {

            return ObtenerNivelEquipo(equipo1) < ObtenerNivelEquipo(equipo2) ? ObtenerNivelEquipo(equipo1)
                : ObtenerNivelEquipo(ObtenerNivelEquipo(equipo1) > ObtenerNivelEquipo(equipo2) ? equipo2 : equipo1);

        }

        public static void InicioRonda()
        {            
            filtroPreguntas.Clear();
            filtroPreguntas.AddRange(_listaDisponibles.Where(pregunta => pregunta.Nivel <= ObtenerNivelPreguntas()));
            if (filtroPreguntas.Count >= int.Parse(ConfigurationManager.AppSettings["cPreguntas"]))
            {
                AñadirPreguntas();
            }
            else
            {             
                Reciclar();                
                InicioRonda();                
            }
        }

        private static void AñadirPreguntas()
        {
            for (int i = 1; ListaRonda.Count < int.Parse(ConfigurationManager.AppSettings["cPreguntas"]); i++)
            {
                Preguntas p = filtroPreguntas[r.Next(0, filtroPreguntas.Count)];
                if (!ListaRonda.Contains(p))
                {
                    ListaRonda.Add(p);
                }                
            }
        }

        public static void PreguntaCorrecta(Preguntas pregunta)
        {            
            ListaDisponibles.Remove(pregunta);
        }
      
        public static bool ExistenPreguntas()
        {
            int count = listaTodas.Count(pregunta => pregunta.Nivel <= ObtenerNivelPreguntas());
            if (count >= int.Parse(ConfigurationManager.AppSettings["cPreguntas"]))
            {
                return true;
            }
            return false;
        }

    }

}