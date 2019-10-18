using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computoPOOLinQ
{
    public class clsComputo
    {
        private int _id;
        private string _nombre;
        private int _capacidad;
        private int _cantidadComputadoras;
        public int Id { get { return _id;  } set { _id = value; } }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int Capacidad
        {
            get { return _capacidad; }
            set { _capacidad = value; }
        }

        /*
         Propiedad CantidadComputadoras de solo lectura
         Devuelve el numero de computadoras que posee el computo actualmente.
             */
        public int CantidadComputadoras
        {
            get { return _cantidadComputadoras; }
            
        }
    }
}
