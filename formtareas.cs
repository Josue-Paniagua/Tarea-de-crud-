using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using guiP1B.Clases;

namespace guiP1B
{
    public partial class formtareas : Form
    {
        CrudTarea crudtareas = new CrudTarea();
        public formtareas()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void formtareas_Load(object sender, EventArgs e)
        {
            comboBoxSeccion.Items.Add("A");
            comboBoxSeccion.Items.Add("B");
            comboBoxSeccion.Items.Add("C");
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            textBoxNombreTarea.Text = crudtareas.MostrarTarea(textBoxCarnet.Text);

        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text;
            string nombreTarea = textBoxNombreTarea.Text;
            string descripcion = textBoxDescripcion.Text;
            string seccion = comboBoxSeccion.Text;

            string resultado = crudtareas.AgregarTarea(carnet, nombreTarea, descripcion, seccion);
            MessageBox.Show(resultado);
        }

        private void textBoxCarnet_TextChanged(object sender, EventArgs e)
        {

        }


        private void buttoneliminar_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text;
            if (!string.IsNullOrEmpty(carnet))
            {
                string resultado = crudtareas.EliminarTarea(carnet);
                MessageBox.Show(resultado);
            }
            else
            {
                MessageBox.Show("Por favor ingrese un carnet.");
            }
        }




    }



}
