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
    public partial class FormNewZone : Form
    {
        public FormNewZone()
        {
            InitializeComponent();
        }
       
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            int Result = 1;
          
            Result =Datos.AddZone(textBoxName.Text);

            if (Result == 0)
            {
                Datos.LogBox("Se agregó nueva zona: " + textBoxName.Text);
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
