using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Watch7
{
    public partial class FormDeleteEquipament : Form
    {
        List<string[]> zonas = new List<string[]>();
        List<string[]> instalaciones = new List<string[]>();
        List<string[]> equipos = new List<string[]>();
        public FormDeleteEquipament()
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

        private void comboBoxInstalations_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEquipament.Items.Clear();

            string[] id_installation_string = instalaciones[comboBoxInstalations.SelectedIndex];
            int id_installation = Convert.ToInt32(id_installation_string[0]);

            equipos = Datos.GetEquipaments(id_installation);
            foreach (string[] i in equipos)
            {
                comboBoxEquipament.Items.Add(i[1]);
            }

            try
            {
                comboBoxEquipament.SelectedIndex = 0;
            }
            catch
            {
                comboBoxEquipament.Items.Add("");
                comboBoxEquipament.SelectedIndex = 0;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int Result = 1;

            string[] id_equipament_string = equipos[comboBoxEquipament.SelectedIndex];
            int id_equipament = Convert.ToInt32(id_equipament_string[0]);

            DialogResult result = MessageBox.Show("Esta seguro de eliminar el equipo", "Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Result = Datos.DeleteEquipament(id_equipament);
                if (Result == 0)
                {
                    Datos.LogBox("Se eliminó el equipo: " + comboBoxEquipament.GetItemText(comboBoxEquipament.SelectedItem));
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
