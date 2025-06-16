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
    public partial class FormDeleteZone : Form
    {
        List<string[]> zonas = new List<string[]>();
        public FormDeleteZone()
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int Result = 1;

            string[] id_zona_string = zonas[comboBoxZonas.SelectedIndex];
            int id_zona = Convert.ToInt32(id_zona_string[0]);

            DialogResult result = MessageBox.Show("Esta seguro de eliminar la zona?", "Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Result = Datos.DeleteZona(id_zona);
                if (Result == 0)
                {
                    Datos.LogBox("Se eliminó la zona: " + comboBoxZonas.GetItemText(comboBoxZonas.SelectedItem));
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
