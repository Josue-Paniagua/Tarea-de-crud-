using guiP1B.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guiP1B
{
    public partial class Form1 : Form
    {

        Crud miCrud = new Crud();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSaludar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola te saludo desde el formulario ");
        }

     


       private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text;
            string nombreEstudiante = miCrud.MostrarInformacion(carnet);
            
        

            if (string.IsNullOrEmpty(nombreEstudiante))
            {
                MessageBox.Show("Carnet no encontrado.");
            }
            else
            {
                textBoxEstudiante.Text = nombreEstudiante;
                
            }
         
        }




        private void buttonCrear_Click(object sender, EventArgs e)
        {
            string nombre = textBoxEstudiante.Text;
            string carnet = textBoxCarnet.Text;
            string email = textBoxEmail.Text;
            string seccion = comboBoxseccion.Text;
            string respuesta = miCrud.AgregarAlumno(carnet, nombre, email, seccion);
            MessageBox.Show(respuesta);
        }

        private void comboBoxseccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxseccion.Items.Add("A");
            comboBoxseccion.Items.Add("B");
            comboBoxseccion.Items.Add("C");
        }

        private void buttontarea_Click(object sender, EventArgs e)
        {
            formtareas formTareas = new formtareas();
            formTareas.Show();
        }

        private void buttoneliminar_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text; 
            if (!string.IsNullOrEmpty(carnet))
            {
                miCrud.EliminarAlumno(carnet); 
            }
            else
            {
                MessageBox.Show("Por favor ingrese un carnet.");
            }
        
    }

        private void buttonactualizar_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text;
            string nombre = textBoxEstudiante.Text;
            string email = textBoxEmail.Text;
            string seccion = comboBoxseccion.Text;

            string respuesta = miCrud.Actualizar(carnet, nombre,email, seccion );
            MessageBox.Show(respuesta);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelnombre_Click(object sender, EventArgs e)
        {

        }

        private void buttonlimpiar_Click(object sender, EventArgs e)
        {
            textBoxCarnet.Clear();
            textBoxEstudiante.Clear();
            textBoxEmail.Clear();
            comboBoxseccion.SelectedIndex = -1; // Limpiar la selección del ComboBox
        }
    }
}  

    
    


