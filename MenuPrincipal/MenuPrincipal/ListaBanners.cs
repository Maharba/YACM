using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace MenuPrincipal
{
    public class ListaBanners
    {
        public ListaBanners()
        {
            Lista = new ObservableCollection<string>();
        }
        private ObservableCollection<string> lista;
        public ObservableCollection<string> Lista { get { return lista; } set { lista = value; } }
        public void Cargar(string nombreArchivo)
        {

            XmlTextReader reader = new XmlTextReader(nombreArchivo);
            XmlSerializer serializer = new XmlSerializer(typeof(ListaBanners));
            try
            {
                ListaBanners banners = (ListaBanners)serializer.Deserialize(reader);
                Lista = banners.Lista;
            }
            catch (SerializationException)
            {
                throw new ApplicationException("Ha ocurrido un error durante la carga del archivo");

            }
            reader.Close();
        }
        public void Guardar(string nombreArchivo)
        {
            if (string.IsNullOrEmpty(nombreArchivo)) throw new ApplicationException("Debe poner un nombre al archivo de banners");             
            XmlTextWriter writer = new XmlTextWriter(nombreArchivo, Encoding.UTF8) { Formatting = Formatting.Indented };
            new XmlSerializer(typeof(ListaBanners)).Serialize(writer, this);
            writer.Close();

        }
    }
}
