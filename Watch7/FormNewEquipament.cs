using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watch7
{
    public partial class FormNewEquipament : Form
    {
        List<string[]> zonas = new List<string[]>();
        List<string[]> instalaciones = new List<string[]>();
        public FormNewEquipament()
        {
            InitializeComponent();

         
            zonas = Datos.GetZones();
            foreach (string[] z in zonas)
            {
                comboBoxZonas.Items.Add(z[1]);
            }

            try
            {
                comboBoxZonas.SelectedIndex = 0;
            }
            catch
            {
                comboBoxZonas.Items.Add("");
                comboBoxZonas.SelectedIndex = 0;
            }


        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            int Result = 1;
            try
            {
                string[] id_instalacion_string = instalaciones[comboBoxInstalations.SelectedIndex];
                int id_intalacion = Convert.ToInt32(id_instalacion_string[0]);

                Result = Datos.AddEquipament(id_intalacion, textBoxName.Text);
            }
            catch { }

            if (Result == 0)
            {
                Datos.LogBox("Se agrego nuevo equipo: " + textBoxName.Text);
                this.Close();
                this.Dispose();
            }
            else label2.Visible = true;           
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void comboBoxZonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            comboBoxInstalations.Items.Clear();

            try
            {
                string[] id_zona_string = zonas[comboBoxZonas.SelectedIndex];
                int id_zona = Convert.ToInt32(id_zona_string[0]);

                instalaciones = Datos.GetInstalations(id_zona);
                foreach (string[] i in instalaciones)
                {
                    comboBoxInstalations.Items.Add(i[1]);
                }

            }
            catch { }


            try
            {
                comboBoxInstalations.SelectedIndex = 0;
            }
            catch {
                comboBoxInstalations.Items.Add("");
                comboBoxInstalations.SelectedIndex = 0;
            }
            

        }
    }
}
