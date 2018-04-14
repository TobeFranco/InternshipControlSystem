using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipControlSystem.Model
{
    class Revisor
    {
        // Variables de Clase
        public int Id;
        public String FirstName;
        public String LastName;

        // Constructor de la clase
        public Revisor(int Id, String FirstName, String LastName)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}
