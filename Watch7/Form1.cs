using Snap7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Snap7.S7Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;
using System.Threading;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Web;
using System.Security.Cryptography;

namespace Watch7
{
    public partial class FormMain : Form
    {
        private S7Client Client;
        Automatismo Auto = new Automatismo();
        private int ButtomCase = 0;

        public FormMain()
        {
            InitializeComponent();
            Client = new S7Client();
            if (IntPtr.Size == 4)
                Datos.LogBox("Aplicación WATCH7 corriendo 32 bits.");
            else
                Datos.LogBox("Aplicación WATCH7 corriendo 64 bits.");
            updateTree();
        }


        #region [MENU TOP BAR]

        private void buttonTreeUpdate_Click(object sender, EventArgs e)
        {
            updateTree();
        }
        private void zonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewZone CambioF = new FormNewZone();
            CambioF.Show();
        }

        private void instalaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewInstalacion CambioF = new FormNewInstalacion();
            CambioF.Show();
        }

        private void equipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewEquipament CambioF = new FormNewEquipament();
            CambioF.Show();
        }
        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfigureDB CambioF = new FormConfigureDB();
            CambioF.Show();
        }
        private void cPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewCPU CambioF = new FormNewCPU();
            CambioF.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

             this.Close();
             this.Dispose();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Confirma cierre de aplicación?  ",
                                "Advertencia!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                Datos.LogBox("Se cerró la aplicación desde interfás de usuario");
                e.Cancel = true; 
            }
        }

        private void conexionARedOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfigureOT CambioF = new FormConfigureOT();
            CambioF.Show();
        }

        private void zonaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormDeleteZone CambioF = new FormDeleteZone();
            CambioF.Show();
        }

        private void instalaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormDeleteInstallation CambioF = new FormDeleteInstallation();
            CambioF.Show();
        }

        private void equipoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormDeleteEquipament CambioF = new FormDeleteEquipament();
            CambioF.Show();
        }

        private void cPUToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormDeleteCPU CambioF = new FormDeleteCPU();
            CambioF.Show();
        }

        private void registroDeEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            ShowLogmain();
        }

        private void registroDeAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            ShowLogApp();
        }

        #endregion

        #region [TREE VIEW ]

        List<string[]> zones = new List<string[]>();
        List<string[]> installations = new List<string[]>();
        List<string[]> equipaments = new List<string[]>();
        List<string[]> cpus = new List<string[]>();
        private void updateTree()
        {
            groupBox1.Visible = false;
            int zoneLevel;
            int installationLevel;
            int equipamentLevel;
            int cpuLevel;

            Tree.Nodes.Clear();

            Tree.BeginUpdate();

            zones = Datos.GetZones();

            zoneLevel = 0;
            foreach (string[] zon in zones)
            {
                TreeNode zoneNode = new TreeNode();
                zoneNode.Tag = zon[0];
                zoneNode.Text = zon[1];
                Tree.Nodes.Add(zoneNode);

                int id_zona = Convert.ToInt32(zon[0]);
                installations = Datos.GetInstalations(id_zona);

                Tree.Nodes[zoneLevel].ImageIndex = 0;
                Tree.Nodes[zoneLevel].SelectedImageIndex = 0;
                installationLevel = 0;
                foreach (string[] ins in installations)
                {
                    TreeNode installationNode = new TreeNode();
                    installationNode.Tag = zon[0] + "|" + ins[0];
                    installationNode.Text = ins[1];

                    Tree.Nodes[zoneLevel].Nodes.Add(installationNode);


                    int id_installation = Convert.ToInt32(ins[0]);
                    equipaments = Datos.GetEquipaments(id_installation);

                    Tree.Nodes[zoneLevel].Nodes[installationLevel].ImageIndex = 1;
                    Tree.Nodes[zoneLevel].Nodes[installationLevel].SelectedImageIndex = 1;
                    equipamentLevel = 0;
                    foreach (string[] equ in equipaments)
                    {
                        TreeNode equipamentNode = new TreeNode();
                        equipamentNode.Tag = zon[0] + "|" + ins[0] + "|" + equ[0];
                        equipamentNode.Text = equ[1];

                        Tree.Nodes[zoneLevel].Nodes[installationLevel].Nodes.Add(equipamentNode);

                        int id_equipament = Convert.ToInt32(equ[0]);
                        cpus = Datos.GetCPUs(id_equipament);

                        Tree.Nodes[zoneLevel].Nodes[installationLevel].Nodes[equipamentLevel].ImageIndex = 2;
                        Tree.Nodes[zoneLevel].Nodes[installationLevel].Nodes[equipamentLevel].SelectedImageIndex = 2;
                        cpuLevel = 0;
                        foreach (string[] cpu in cpus)
                        {
                            TreeNode cpuNode = new TreeNode();
                            cpuNode.Tag = zon[0] + "|" + ins[0] + "|" + equ[0] + "|" + cpu[0];
                            cpuNode.Text = cpu[3];

                            Tree.Nodes[zoneLevel].Nodes[installationLevel].Nodes[equipamentLevel].Nodes.Add(cpuNode);

                            if (cpu[8] == "1") Tree.Nodes[zoneLevel].Nodes[installationLevel].Nodes[equipamentLevel].Nodes[cpuLevel].ImageIndex = 3;
                            if (cpu[8] == "2") Tree.Nodes[zoneLevel].Nodes[installationLevel].Nodes[equipamentLevel].Nodes[cpuLevel].ImageIndex = 4;
                            if (cpu[8] == "0") Tree.Nodes[zoneLevel].Nodes[installationLevel].Nodes[equipamentLevel].Nodes[cpuLevel].ImageIndex = 5;

                            Tree.Nodes[zoneLevel].Nodes[installationLevel].Nodes[equipamentLevel].Nodes[cpuLevel].SelectedImageIndex =
                                Tree.Nodes[zoneLevel].Nodes[installationLevel].Nodes[equipamentLevel].Nodes[cpuLevel].ImageIndex;

                            cpuLevel++;
                        }
                        equipamentLevel++;
                    }
                    installationLevel++;
                }
                zoneLevel++;
            }

            Tree.EndUpdate();

            if (treeSpanded)
            {
                Tree.ExpandAll();

            }
        }

        private bool treeSpanded=false;
        private void buttonTreeExpand_Click(object sender, EventArgs e)
        {
            if (!treeSpanded)
            {
                Tree.ExpandAll();
                buttonTreeExpand.Text = "▲";
                treeSpanded = true;
            }
            else
            {
                Tree.CollapseAll();
                buttonTreeExpand.Text = "▼";
                treeSpanded = false;
            }

        }


        #endregion

        #region [BUTTOM BARS]
        public void ConexionStateBD(string state)
        {
            BDConexionBox.Text = state;
        }

        public void ConexionStateOT(string state)
        {
            OTConexionBox.Text = state;
        }

        private void timerBottomBar_Tick(object sender, EventArgs e)
        {
            bool OT = Datos.conexionOT;
            bool BD =Datos.conexionBD;
            string Log = Datos.Log;

            if (OT)
            {
                OTConexionBox.Text = "Conexión Red OT OK";
                OTConexionBox.BackColor = Color.Green;
            }
            else
            {
                OTConexionBox.Text = "Error conexión Red OT";
                OTConexionBox.BackColor = Color.Red;
            }

            if (BD)
            {
                BDConexionBox.Text = "Conexión BD OK";
                BDConexionBox.BackColor = Color.Green;
            }
            else
            {
                BDConexionBox.Text = "Error conexión con BD";
                BDConexionBox.BackColor = Color.Red;
            }

            LogBox.Text = Log;

        }


        #endregion 

        #region [MAIN LOOP]

        DateTime timeStart =  new DateTime();
        private void timerMain_Tick(object sender, EventArgs e)
        {
            timerMain.Stop();
            //Test connection with RED OT
            Datos.conexionOT = Datos.pingState(Properties.Settings.Default.Red_port);
            Datos.ConexionStateOT(Datos.conexionOT);

            //Test connection with DB
            Datos.Connect();
            if (Datos.Connection != null && Datos.Connection.State.Equals(ConnectionState.Open))
            {
                Datos.ConexionStateBD(true);
            }
            else { Datos.ConexionStateBD(false); }
            Datos.Disconnect();

            if(Datos.conexionBD&& Datos.conexionOT)
            {
                groupBoxControl.Enabled = true;

                if (ButtomCase == 3) { 
                    Auto.Stop();
                    progressBar1.Value = 1000;
                    buttonMan.Enabled = true;
                    buttonAuto.Enabled = true;
                    buttonStop.Enabled = false;

                }
                if (ButtomCase == 2 || ButtomCase == 1)
                {
                    if(ButtomCase == 2) progressBar1.Value = Auto.CheckProgres(0); //escanea una nueva CPU cargada en  la base de datos
                    if (ButtomCase == 1) progressBar1.Value = Auto.CheckProgres(1);//escanea segun tiempo de ciclo definido en la cpu

                    if (progressBar1.Value == 1000 && ButtomCase == 2) { //detiene el ciclo una vez que se escanearon todos las cpus

                        ButtomCase = 3;
                        double totalSec = (DateTime.Now - timeStart).TotalSeconds;
                        string timeProcess = string.Format("{0:00}:{1:00}:{2:00}", totalSec / 3600, (totalSec / 60) % 60, totalSec % 60);
                        Datos.LogBox("Ciclo de supervición completo realizado en: "+ timeProcess);
                    }
                    if (progressBar1.Value == 1000)
                    { 
                        updateTree();
                        Auto.getListCpus();
                    }

                    if (ButtomCase == 1) //vuelve a escanear todas las cpus.
                    {
                        Auto.ContinuosCycle();
                    }

                }
            }else
            {
                groupBoxControl.Enabled = false;
            }

            
            timerMain.Start();


        }

        private void buttonMan_Click(object sender, EventArgs e)
        {
            Auto.getListCpus();
            ButtomCase = 2;
            buttonAuto.Enabled = false;
            buttonMan.Enabled = false;
            buttonStop.Enabled = true;
            progressBar1.Value = 5;
            groupBox1.Visible = false;
            timeStart = DateTime.Now; //.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {
            Auto.getListCpus();
            ButtomCase = 1;
            buttonMan.Enabled = false;
            buttonStop.Enabled = true;
            progressBar1.Value = 5;
            groupBox1.Visible = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonMan.Enabled = true;
            buttonMan.Enabled = true;
            buttonStop.Enabled = false;
            ButtomCase = 3;
            groupBox1.Visible = false;
            updateTree();
        }

        #endregion

        #region [MAIN WINDOW]

        string[] TreeSelectNodes = new string[4];
        int treeSelectedCpuId = 0;
        protected void Tree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
          
            string[] Nodes = e.Node.Tag.ToString().Split('|');

            if (Nodes.Length==4)
            {
                TreeSelectNodes = Nodes;
                treeSelectedCpuId =Convert.ToInt32(Nodes[3]);
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;

                ShowCPU(Nodes);
            }
            else
            {
                groupBox1.Visible = false;
            }
           
           // Datos.LogBox(e.Node.Tag.ToString());
        }

        //WINDOWS 1
        private void ShowCPU(string[] Nodes)
        {
            
            labelZone.Text = Datos.GetZoneName(Nodes[0]);
            labelInstallation.Text = Datos.GetInstallationName(Nodes[1]);
            labelEquipament.Text = Datos.GetEquipamentName(Nodes[2]);
            CPU Cpu = Datos.GetCpuData(Nodes[3]);

            labelModulo.Text = Cpu.name;
            textBoxName.Text = Cpu.name;
            textBoxIp.Text = Cpu.ip;
            textBoxRack.Text = Cpu.rack.ToString();
            textBoxSlot.Text = Cpu.slot.ToString();
            textBoxAdreese.Text = Cpu.adreess.ToString();
            textBoxId.Text = Cpu.id.ToString();
            textBoxType.Text = Datos.GetTypeName(Cpu.type);
            textBoxCycle.Text = StrCycle(Cpu.cycle);
            textBoxChecksum.Text ="$16x"+ Cpu.checksum.ToString("X");
            textBoxDate.Text = Cpu.checksumdate.ToString();

            switch (Cpu.state)
            {
                case 0:
                    labelN_0.Visible = true;
                    labelN_1.Visible = false;
                    labelN_2.Visible = false;
                    labelN_3.Visible = false;
                    textBoxChecksum.BackColor = Control.DefaultBackColor;
                    buttonValidate.Enabled = false;
                    break;
                case 1:
                    labelN_0.Visible = false;
                    labelN_1.Visible = true;
                    labelN_2.Visible = false;
                    labelN_3.Visible = false;
                    textBoxChecksum.BackColor = Color.Red;
                    buttonValidate.Enabled= true;
                    break;
                case 2:
                    labelN_0.Visible = false;
                    labelN_1.Visible = false;
                    labelN_2.Visible = true;
                    labelN_3.Visible = false;
                    textBoxChecksum.BackColor = Color.Green;
                    buttonValidate.Enabled = false;
                    break;
                default:
                    labelN_0.Visible = false;
                    labelN_1.Visible = false;
                    labelN_2.Visible = true;
                    labelN_3.Visible = false;
                    textBoxChecksum.BackColor = Control.DefaultBackColor;
                    break;
            }


            //LISTA DE EVENTOS DE LA CPU
            List<string[]> cpuLogs = new List<string[]>();

            cpuLogs = Datos.GetCpuLogs(Cpu.id);

            dataGridLogs.Rows.Clear();
            foreach (string[] item in cpuLogs)
            {
                string[] rowAdd = {item[0], item[1], item[2]};
                dataGridLogs.Rows.Add(rowAdd);

            }

            if (cpuLogs.Count > 0) buttonDeleteLog.Enabled = true;
            else buttonDeleteLog.Enabled = false;



        }
        string StrCycle(int c)
        {
            string dateTime;

            switch (c)
            {
                case 0:
                    dateTime = "30 segundos";
                    break;
                case 1:
                    dateTime = "1 minuto";
                    break;
                case 2:
                    dateTime = "10 minutos";
                    break;
                case 3:
                    dateTime = "30 minutos";
                    break;
                case 4:
                    dateTime = "1 hora";
                    break;
                case 5:
                    dateTime = "2 horas";
                    break;
                case 6:
                    dateTime = "6 horas";
                    break;
                case 7:
                    dateTime = "12 horas";
                    break;
                case 8:
                    dateTime = "1 dia";
                    break;
                case 9:
                    dateTime = "2 dias";
                    break;
                case 10:
                    dateTime = "7 dias";
                    break;
                case 11:
                    dateTime = "30 dias";
                    break;
                case 12:
                    dateTime = "Nunca";
                    break;
                default:
                    dateTime = "Nunca";
                    break;
            }

            return dateTime;
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma actualizar la suma de verificación?  ",
                    "Advertencia!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                CPU cpuTempData = Datos.GetCpuData(treeSelectedCpuId.ToString());

                int Result = 1;
                Result = Datos.UpdateChecksumCPU(treeSelectedCpuId, 0);
                Result = Result + Datos.UpdateStateCPU(treeSelectedCpuId, 0);
                Result = Result + Datos.AddEventLog(treeSelectedCpuId, "Se validó discordancia en la suma de verificación del módulo: "+ cpuTempData.name+ " con Ip: "+cpuTempData.ip, 2);
                if (Result == 0)
                {
                    textBoxChecksum.Text = "$0x0";
                    textBoxChecksum.BackColor = Control.DefaultBackColor;
                    textBoxDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    labelN_3.Visible = true;
                    buttonValidate.Enabled = false;
                }
            }


        }

        private void buttonNewRead_Click(object sender, EventArgs e)
        {
            string[] cpuData = new string[12];
            CPU Cpu = Datos.GetCpuData(TreeSelectNodes[3]);

            cpuData[0] = Cpu.id.ToString();
            cpuData[3] = Cpu.name.ToString();
            cpuData[4] = Cpu.ip.ToString();
            cpuData[5] = Cpu.rack.ToString();
            cpuData[6] = Cpu.slot.ToString();
            cpuData[2] = Cpu.type.ToString();
            cpuData[7] = Cpu.cycle.ToString();
            cpuData[8] = Cpu.state.ToString();
            cpuData[9] = Cpu.checksum.ToString();
            cpuData[10] = Cpu.checksumdate.ToString();
            cpuData[11] = Cpu.adreess.ToString();

            Auto.checkOnlyOneCpu(cpuData);
            ShowCPU(TreeSelectNodes);
           
        }

        //WINDOWS 2
        private void buttonDeleteLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma eliminar lista de eventos de este modulo?  ",
                                "Advertencia!",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int Result = 1;
                Result = Datos.EraseCpuEventLog(treeSelectedCpuId);
               
                if (Result == 0)
                {
                    ShowCPU(TreeSelectNodes);
                }
            }
        }

        private void ShowLogmain()
        {
            List<string[]> Logs = new List<string[]>();
            int index = 0;
            Logs = Datos.GetLogs();

            dataGridLogsMain.Rows.Clear();
            foreach (string[] item in Logs)
            {
                
                string[] rowAdd = { item[0], item[1], item[3], item[2] };

                dataGridLogsMain.Rows.Add(rowAdd);
                if (item[4] == "0") dataGridLogsMain.Rows[index].DefaultCellStyle.BackColor = Color.White;
                if (item[4] == "1") dataGridLogsMain.Rows[index].DefaultCellStyle.BackColor = Color.LightPink;
                if (item[4] == "2") dataGridLogsMain.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                if (item[4] == "3") dataGridLogsMain.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;

                index++;
            }

            if(Logs.Count>0) buttonEraseLogs.Enabled = true;
            else buttonEraseLogs.Enabled = false;
        }

        private void buttonEraseLogs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma eliminar todo el registro de eventos de los modulos?  ",
                    "Advertencia!",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int Result = 1;
                Result = Datos.EraseAllLog();

                if (Result == 0)
                {
                    Datos.LogBox("Se ha eliminado todo el registro de ventos de los módulos.");
                    ShowLogmain();
                }
            }
        }



        //WINDOWS 3
        private void ShowLogApp()
        {
            List<string[]> Logs = new List<string[]>();
  
            Logs = Datos.GetLogsApp();

            dataGridLogApp.Rows.Clear();
            foreach (string[] item in Logs)
            {
                string[] rowAdd = { item[0], item[1], item[2]};

                dataGridLogApp.Rows.Add(rowAdd);

            }

            if(Logs.Count>0) buttonEraseAppLog.Enabled = true;
            else buttonEraseAppLog.Enabled = false;
        }

        private void buttonEraseAppLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma eliminar el historial de eventos de la aplicación?  ",
                    "Advertencia!",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int Result = 1;
                Result = Datos.EraseLogApp();

                if (Result == 0)
                {
                    ShowLogApp();
                    Datos.LogBox("Se ha eliminado todo el historial de eventos de la aplicación.");
                }


            }
        }



        #endregion


    }
}
