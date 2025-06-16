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
    public partial class FormDeleteCPU : Form
    {
        List<string[]> zonas = new List<string[]>();
        List<string[]> instalaciones = new List<string[]>();
        List<string[]> equipos = new List<string[]>();
        List<string[]> cpus = new List<string[]>();
        public FormDeleteCPU()
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
            foreach (string[] q in equipos)
            {
                comboBoxEquipament.Items.Add(q[1]);
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

        private void comboBoxEquipament_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCPUs.Items.Clear();

            string[] id_equipament_string = equipos[comboBoxEquipament.SelectedIndex];
            int id_equipament = Convert.ToInt32(id_equipament_string[0]);

            cpus = Datos.GetCPUs(id_equipament);
            foreach (string[] c in cpus)
            {
                comboBoxCPUs.Items.Add(c[3]);
            }

            try
            {
                comboBoxCPUs.SelectedIndex = 0;
            }
            catch
            {
                comboBoxCPUs.Items.Add("");
                comboBoxCPUs.SelectedIndex = 0;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int Result = 1;

            string[] id_cpu_string = cpus[comboBoxCPUs.SelectedIndex];
            int id_cpu = Convert.ToInt32(id_cpu_string[0]);

            DialogResult result = MessageBox.Show("Esta seguro de eliminar la CPU", "Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Result = Datos.DeleteCPU(id_cpu);
                if (Result == 0)
                {
                    Datos.LogBox("Se eliminó el módulo CPU: " + comboBoxCPUs.GetItemText(comboBoxCPUs.SelectedItem) +"  Con Id: " + id_cpu);
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
