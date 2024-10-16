using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2doPOO.Controller
{
    interface IAlumno
    {
        List<Alumno> ObtenerDatos();
        bool EliminarAlumno(int ID);
        bool AgregarAlumno(int iD, string nombre, int edad, DateTime fechaNacimiento, string correoElectronico);
        bool ActualizarAlumno(int iD, string nombre, int edad, DateTime fechaNacimiento, string correoElectronico);
    }
}
