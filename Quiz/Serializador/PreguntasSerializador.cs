using System;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using Seguridad;

namespace Quiz.Serializador
{
    public class PreguntasSerializador
    {
        public ObservableCollection<Preguntas> LeerXml(string nombre)
        {
            if (nombre == null) throw new ArgumentNullException("nombre");
            var serializer = new XmlSerializer(typeof(ObservableCollection<Preguntas>));
            var reader = new XmlTextReader(nombre);
            var lista = new ObservableCollection<Preguntas>();
            try
            {
                lista = (ObservableCollection<Preguntas>)serializer.Deserialize(reader);
            }
            catch (SerializationException ex)
            {
                Debug.Assert(true, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Debug.Assert(true, ex.Message);
            }
            finally
            {
                reader.Close();
            }
            return lista;
        }
        public void EscribirXml(string nombre, ListaPreguntas pregs)
        {
            if (nombre == null) throw new ArgumentNullException("nombre");
            if (pregs == null) throw new ArgumentNullException("pregs");
            var w = new XmlTextWriter(nombre, Encoding.UTF8) {Formatting = Formatting.Indented};
            var s = new XmlSerializer(typeof(ObservableCollection<Preguntas>));
            s.Serialize(w, pregs.Lista);
            w.Close();
        }

        public void EscribirBin(string nombre, ListaPreguntas pregs)
        {
            Binario.GuardarBin(nombre, pregs);
        }

        public ObservableCollection<Preguntas> LeerBin(string nombre)
        {
            return Binario.CargarBin<ObservableCollection<Preguntas>>(nombre);
        }
    }
}
