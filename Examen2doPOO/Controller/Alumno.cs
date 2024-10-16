using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2doPOO.Controller
{

    class Alumno
    {
        public Alumno() { }

        public Alumno(int iD, string nombre, int edad, DateTime fechaNacimiento, string correoElectronico)
        {
            ID = iD;
            Nombre = nombre;
            Edad = edad;
            FechaNacimiento = fechaNacimiento;
            CorreoElectronico = correoElectronico;
        }

        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
    }

}
