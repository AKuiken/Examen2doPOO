using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen2doPOO.Model.DataSet1TableAdapters;

namespace Examen2doPOO.Controller
{
    class ControllerAlumno : IAlumno
    {
        Alumno a = new Alumno();
        List<Alumno> alumnos = new List<Alumno>();
        public bool ActualizarAlumno(int iD, string nombre, int edad, DateTime fechaNacimiento, string correoElectronico)
        {
            using (var adapter = new personasTableAdapter())
            {
                int filasAfectadas = adapter.UpdateAlumno(nombre, edad, fechaNacimiento, correoElectronico, iD);

                return filasAfectadas > 0;
            }
        }

        public bool AgregarAlumno(int iD, string nombre, int edad, DateTime fechaNacimiento, string correoElectronico)
        {
            Alumno nuevaPersona = new Alumno(iD, nombre, edad, fechaNacimiento, correoElectronico);

            using (personasTableAdapter usuarios1 = new personasTableAdapter())
            {
                try
                {
                    usuarios1.InsertAlumno(nuevaPersona.Nombre, nuevaPersona.Edad, nuevaPersona.FechaNacimiento, nuevaPersona.CorreoElectronico );
                    Console.WriteLine("Persona agregada");

                    alumnos.Add(nuevaPersona);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al agregar el usuario: " + ex);
                    return false;
                }
            }
        }

        public bool EliminarAlumno(int ID)
        {
            using (personasTableAdapter alumnos2 = new personasTableAdapter())
            {
                try
                {
                    var AlumnoExistente = alumnos2.GetDataByPersona(ID);
                    if (AlumnoExistente.Rows.Count > 0)
                    {
                        alumnos2.DeleteAlumno(ID);
                        Console.WriteLine("Persona Eliminada");
                        return true;

                    }
                    else
                    {
                        Console.WriteLine("No se encontró a la persona");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar" + ex);
                    return false;
                }
            }
        }

        public List<Alumno> ObtenerDatos()
        {
            using (personasTableAdapter al = new personasTableAdapter())
            {
                var datos = al.GetData();
                foreach (var row in datos)
                {
                    a.ID = Convert.ToInt32(row["ID"]);
                    a.Nombre = row["Nombre"].ToString();
                    a.Edad = Convert.ToInt32(row["Edad"]);
                    a.FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]);
                    a.CorreoElectronico = row["CorreoElectronico"].ToString();
                    alumnos.Add(new Alumno(a.ID, a.Nombre, a.Edad, a.FechaNacimiento, a.CorreoElectronico));
                }
                return alumnos;
            }
        }
    }
}
