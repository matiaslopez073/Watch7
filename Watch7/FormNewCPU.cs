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
    public partial class FormNewCPU : Form
    {
        List<string[]> zonas = new List<string[]>();
        List<string[]> instalaciones = new List<string[]>();
        List<string[]> equipos = new List<string[]>();
        List<string[]> tipos = new List<string[]>();
        public FormNewCPU()
        {
            InitializeComponent();

            comboBoxCycles.SelectedIndex = 0;

            zonas = Datos.GetZones();
         

            foreach (string[] z in zonas)
            {
                comboBoxZonas.Items.Add(z[1]);
            }

            tipos = Datos.GetTypes();
            foreach (string[] z in tipos)
            {
                comboBoxTypes.Items.Add(z[1]);
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
            try
            {
                comboBoxTypes.SelectedIndex = 0;
            }
            catch
            {
                comboBoxTypes.Items.Add("");
                comboBoxTypes.SelectedIndex = 0;
            }


        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            CPU NewCPU = new CPU();

            try
            {
                NewCPU.name = textBoxName.Text;
                NewCPU.ip = textBoxIp.Text;
                NewCPU.rack = Convert.ToInt32(textBoxRack.Text);
                NewCPU.slot = Convert.ToInt32(textBoxSlot.Text);
                NewCPU.type = comboBoxTypes.SelectedIndex + 1;
                NewCPU.cycle = comboBoxCycles.SelectedIndex;
                NewCPU.adreess = Convert.ToInt32(textBoxDir.Text);

                string[] id_equipament_string = equipos[comboBoxEquipament.SelectedIndex];
                int id_equipament = Convert.ToInt32(id_equipament_string[0]);


                if (Datos.AddCPU(id_equipament, NewCPU) == 0)
                {
                    Datos.LogBox("Se agrego nueva CPU: Nombre: " + textBoxName.Text + "  Ip: "+ textBoxIp.Text);
                    this.Close();
                    this.Dispose();
                }
                else label2.Visible = true;

            }
            catch { label2.Visible = true; }


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

            try
            {
                string[] id_installation_string = instalaciones[comboBoxInstalations.SelectedIndex];
                int id_installation = Convert.ToInt32(id_installation_string[0]);

                equipos = Datos.GetEquipaments(id_installation);
                foreach (string[] i in equipos)
                {
                    comboBoxEquipament.Items.Add(i[1]);
                }

                comboBoxEquipament.SelectedIndex = 0;
            }
            catch
            {
                comboBoxEquipament.Items.Add("");
                comboBoxEquipament.SelectedIndex = 0;
            }
        }

        private void comboBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTypes.SelectedIndex != 0 && comboBoxTypes.SelectedIndex != 1 )
            {
                textBoxDir.Enabled= true;
                label11.Enabled = true;
            }
            else
            {
                textBoxDir.Enabled = false;
                label11.Enabled = false;
            }
        }
    }
}
