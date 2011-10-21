using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Equipos
{
    [Serializable]
    public class Concursante
    {
        public Concursante()
        { }

        public Concursante(string noControl, string carrera,string semestre,string nombreAlumno) 
        {
            this.nocontrol = noControl;
            this.carrera = carrera;
            this.semestre = semestre;
            this.nombrealumno = nombreAlumno;
        }

        private string carrera;

        [XmlAttribute]
        public string Carrera
        {
            set { carrera = value; }
            get { return carrera; }
        }

        private string nocontrol;

        [XmlAttribute]
        public string NoControl
        {
            set { nocontrol = value; }
            get { return nocontrol; }
        }

        private string nombrealumno;

        [XmlAttribute]
        public string NombreAlumno
        {
            set { nombrealumno = value; }
            get { return nombrealumno; }
        }

        private string semestre;

        [XmlAttribute]
        public string Semestre
        {
            set { semestre = value; }
            get { return semestre; }
        }
        public void Modificar(Concursante c)
        {
            this.NombreAlumno = c.NombreAlumno;
            this.NoControl = c.NoControl;
            this.Semestre = c.Semestre;
            this.Carrera = c.Carrera;
        }
        
    }
}
