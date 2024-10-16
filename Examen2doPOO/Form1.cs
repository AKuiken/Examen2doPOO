using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examen2doPOO.Controller;

namespace Examen2doPOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ControllerAlumno controller = new ControllerAlumno();

            if (txtNombre.Text.Length < 3)
            {
                MessageBox.Show("El nombre debe tener al menos 3 caracteres.");
                return;
            }
            if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0 || edad >= 99)
            {
                MessageBox.Show("Por favor, ingresa una edad válida.");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Correo electrónico no válido.");
                return;
            }

            bool resultado = controller.AgregarAlumno(0, txtNombre.Text, edad, dtpFechaNacimiento.Value, txtCorreo.Text);

            if (resultado)
            {
                MessageBox.Show("Alumno agregado exitosamente.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Hubo un error al agregar al alumno.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ControllerAlumno controller = new ControllerAlumno();
            if (string.IsNullOrWhiteSpace(txtID.Text) || !int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("Por favor, introduce un ID.");
                return;
            }
            if (txtNombre.Text.Length < 3)
            {
                MessageBox.Show("El Nombre debe tener al menos 3 caracteres.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Por favor, introduce un correo electrónico válido.");
                return;
            }

            if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0 || edad > 99)
            {
                MessageBox.Show("Por favor, introduce una edad válida (entre 1 y 99).");
                return;
            }

            bool resultado = controller.ActualizarAlumno(id, txtNombre.Text, edad, dtpFechaNacimiento.Value, txtCorreo.Text);

            if (resultado)
            {
                MessageBox.Show("Alumno actualizado exitosamente.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al actualizar el alumno. Verifica que el ID exista.");
            }
        }

        private void btnElimianr_Click(object sender, EventArgs e)
        {
            ControllerAlumno controller = new ControllerAlumno();
            if (string.IsNullOrWhiteSpace(txtID.Text) || !int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("Por favor, introduce un ID válido para eliminar.");
                return;
            }
            bool resultado = controller.EliminarAlumno(id);

            if (resultado)
            {
                MessageBox.Show("Alumno eliminado exitosamente.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al eliminar el alumno. Verifica que el ID exista.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtEdad.Clear();
            txtCorreo.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            dataGridView1.ClearSelection();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            ControllerAlumno controller = new ControllerAlumno();
            List<Alumno> alumnos = controller.ObtenerDatos();

            dataGridView1.DataSource = alumnos;
        }
    }
}
