using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Quiz
{
    [Serializable]
    public class ListaPreguntas
    {
        public ListaPreguntas()
        {
            Lista = new ObservableCollection<Preguntas>();
        }

        public ObservableCollection<Preguntas> Lista { get; set; }
    }
}
