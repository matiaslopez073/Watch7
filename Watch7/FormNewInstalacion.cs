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
    public partial class FormNewInstalacion : Form
    {
        List<string[]> zonas = new List<string[]>();
        public FormNewInstalacion()
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
                string[] id_zona_string = zonas[comboBoxZonas.SelectedIndex];
                int id_zona = Convert.ToInt32(id_zona_string[0]);

                Result = Datos.AddInstallation(id_zona, textBoxName.Text);

            }
            catch {}

            if (Result == 0)
            {
                Datos.LogBox("Se agregó nueva instalción: " + textBoxName.Text);
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
    }
}
