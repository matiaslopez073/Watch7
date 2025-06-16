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
    public partial class FormDeleteInstallation : Form
    {
        List<string[]> zonas = new List<string[]>();
        List<string[]> instalaciones = new List<string[]>();
        public FormDeleteInstallation()
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

        private void comboBoxZonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxInstalations.Items.Clear();

            string[] id_zona_string = zonas[comboBoxZonas.SelectedIndex];
            int id_zona = Convert.ToInt32(id_zona_string[0]);


            instalaciones = Datos.GetInstalations(id_zona);
            foreach (string[] i in instalaciones)
            {
                comboBoxInstalations.Items.Add(i[1]);
            }

            try
            {
                comboBoxInstalations.SelectedIndex = 0;
            }
            catch
            {
                comboBoxInstalations.Items.Add("");
                comboBoxInstalations.SelectedIndex = 0;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int Result = 1;

            string[] id_installation_string = instalaciones[comboBoxInstalations.SelectedIndex];
            int id_installation = Convert.ToInt32(id_installation_string[0]);

            DialogResult result = MessageBox.Show("Esta seguro de eliminar la instalación?", "Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Result = Datos.DeleteInstallation(id_installation);
                if (Result == 0)
                {
                    Datos.LogBox("Se eliminó la instalación: " + comboBoxInstalations.GetItemText(comboBoxInstalations.SelectedItem));
                    this.Close();
                    this.Dispose();
                }
                else label2.Visible = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
