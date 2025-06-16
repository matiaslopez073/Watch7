using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Watch7
{
    public partial class FormConfigureDB : Form
    {
        private bool ConnState=false;
       
        public FormConfigureDB()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.DB_Chain;          

        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
         
            
            Datos.Connect();
            if (Datos.Connection != null && Datos.Connection.State.Equals(ConnectionState.Open))
            {
                labelOK.Visible = true;
                labelNOK.Visible = false;
                ConnState = true;
                Datos.ConexionStateBD(true);
                Datos.LogBox("TEST de conexión con base de datos exitoso.");
            }
            else
            {
                labelOK.Visible = false;
                labelNOK.Visible = true;
                ConnState = false;
                Datos.ConexionStateBD(false);
                Datos.LogBox("Cadena de conexión erronea o sin conexión.");
            }
            Datos.Disconnect();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Datos.Connection.ConnectionString = textBox1.Text;
            Properties.Settings.Default.DB_Chain =textBox1.Text;
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
