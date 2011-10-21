using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace Equipos
{
    
        [Serializable]
        public class Equipo
        {
            public Equipo()
            {
                this.Concursantes = new ObservableCollection<Concursante>();
            }

            public override string ToString()
            {
                return this.NombreEquipo;
            }

            private ObservableCollection<Concursante> concursantes = new ObservableCollection<Concursante>();


            public ObservableCollection<Concursante> Concursantes
            {
                set { concursantes = value; }
                get { return concursantes; }
            }

            private string nombreequipo;

            [XmlAttribute]
            public string NombreEquipo
            {
                set { nombreequipo = value; }
                get { return nombreequipo; }
            }
            private string escuela;

            [XmlAttribute]
            public string Escuela
            {
                set { escuela = value; }
                get { return escuela; }
            }
      
        }
    
}
