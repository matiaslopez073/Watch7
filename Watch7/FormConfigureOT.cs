using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Watch7
{
    public partial class FormConfigureOT : Form
    {
        private bool ConnState = false;

        public FormConfigureOT()
        {
            InitializeComponent();
            textBoxIp.Text = Properties.Settings.Default.Red_ip;
            textBoxMask.Text = Properties.Settings.Default.Red_mask;
            textBoxPort.Text = Properties.Settings.Default.Red_port;

        }

        private void buttonTest_Click(object sender, EventArgs e)
        {


           
            if (Datos.pingState(Properties.Settings.Default.Red_port))
            {
                labelOK.Visible = true;
                labelNOK.Visible = false;
                ConnState = true;
                Datos.ConexionStateOT(true);
                Datos.LogBox("TEST de conexión con red OT exitoso.");
            }
            else
            {
                labelOK.Visible = false;
                labelNOK.Visible = true;
                ConnState = false;
                Datos.ConexionStateOT(false);
                Datos.LogBox("ERROR de conexión con red OT.");
            }
            Datos.Disconnect();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Red_ip = textBoxIp.Text;
            Properties.Settings.Default.Red_mask = textBoxMask.Text;
            Properties.Settings.Default.Red_port = textBoxPort.Text;
            Properties.Settings.Default.Save();

            buttonTest.Enabled = true;

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
            this.Dispose();
        }
    }
}
