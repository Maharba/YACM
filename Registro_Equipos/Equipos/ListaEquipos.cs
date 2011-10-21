using System;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace Equipos
{   [Serializable]
    public class ListaEquipos
    {
            public ListaEquipos()
        {
            this.Lista = new ObservableCollection<Equipo>();
                
        }

        private ObservableCollection<Equipo> lista;
        

        public ObservableCollection<Equipo> Lista
        {
            get { return lista; }
            set { lista = value; }
        }                        
        public void Agregar(string nombreequipo, string escuela, params Concursante []integrantes)
        {
            if (string.IsNullOrEmpty(nombreequipo)&&string.IsNullOrEmpty(nombreequipo))throw new ApplicationException();            
            Equipo nuevoEquipo = new Equipo {NombreEquipo = nombreequipo, Escuela = escuela};
            foreach (Concursante integrante in integrantes)
                {
                   if ((string.IsNullOrEmpty(integrante.NoControl)||string.IsNullOrEmpty(integrante.NombreAlumno)||string.IsNullOrEmpty(integrante.Semestre)||string.IsNullOrEmpty(integrante.Carrera))) throw new ApplicationException("NoControl");                    
                   nuevoEquipo.Concursantes.Add(integrante);
                }
                Lista.Add(nuevoEquipo);                        
        }
        public void EliminarEquipo(Equipo equipo)
        {
            Lista.Remove(equipo);
        }
        public void Editar(Equipo equipo, string nombreequipo, string escuela, params Concursante[] integrantes) 
        {
                int indice = Lista.IndexOf(equipo);
                Lista.Remove(equipo);
                if (string.IsNullOrEmpty(nombreequipo) || string.IsNullOrEmpty(escuela))
                {
                    Lista.Insert(indice,equipo);
                    throw new ApplicationException();
                }
                Equipo nuevoEquipo = new Equipo {NombreEquipo = nombreequipo, Escuela = escuela};
                foreach (Concursante integrante in integrantes)
                {
                    if (string.IsNullOrEmpty(integrante.NoControl)||string.IsNullOrEmpty(integrante.NombreAlumno)||string.IsNullOrEmpty(integrante.Semestre)||string.IsNullOrEmpty(integrante.Carrera))
                    {
                        Lista.Insert(indice, equipo);
                        throw new ApplicationException();
                    }                    
                    nuevoEquipo.Concursantes.Add(integrante);
                }                
                Lista.Insert(indice, nuevoEquipo);
 
        }
       
        public void Cargar(string nombreArchivo)
        {
            
            XmlTextReader reader = new XmlTextReader(nombreArchivo);
            XmlSerializer serializer = new XmlSerializer(typeof(ListaEquipos));
            try
            {
                ListaEquipos equipos = (ListaEquipos)serializer.Deserialize(reader);
                Lista = equipos.Lista;
            }
            catch (SerializationException)
            {
                throw new ApplicationException("Ha ocurrido un error durante la carga del archivo");

            }
            reader.Close();
        }
        public void Guardar(string nombreArchivo)
        {
            XmlTextWriter writer = new XmlTextWriter(nombreArchivo, Encoding.UTF8) {Formatting = Formatting.Indented};
            new XmlSerializer(typeof(ListaEquipos)).Serialize((XmlWriter)writer, this);
            writer.Close();

        }

    }
}
