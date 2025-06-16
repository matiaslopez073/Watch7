using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Globalization;

namespace Watch7
{
    public class Datos
    {

        #region [CONECT]
        public static bool conexionOT, conexionBD;
        public static string Log;

        // public static String Cadena = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=WATCH7;Data Source=DESKTOP-DP23DE4; Connection Timeout=2";
        // public static String Cadena = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=WATCH7;Data Source=ARMCL044506\\SQLEXPRESS; Connection Timeout=2";
        public static String Cadena = Properties.Settings.Default.DB_Chain;
        public static SqlConnection Connection = new SqlConnection(Cadena);
        

        public static  SqlConnection Connect()
        {
            try
            {
                Connection.Open();
                return Connection;
            }catch 
            {
                return null;
            }       
        }

        public static SqlConnection Disconnect()
        {
            Connection.Close();
            return Connection;
        }

        public static void ConexionStateBD(bool state)
        {
            Datos.conexionBD = state;

        }

        public static void ConexionStateOT(bool state)
        {
            Datos.conexionOT = state;

        }

        public static bool pingState(string ip)
        {
            bool state = false;
            Ping Pings = new Ping();
            int timeout = 1;
            try
            {
                if (Pings.Send(ip, timeout).Status == IPStatus.Success)
                {
                    state = true;
                }
                else state = false;
            }
            catch (Exception ex) { Datos.LogBox("Error conexion red " + ex.Message); }

            return state;
        }
        #endregion

        #region [ZONES]
        public static int AddZone(string zoneName)
        {
            
            int Result = 1;
            if(!string.IsNullOrEmpty(zoneName))
            {
                string query = "INSERT INTO ZONAS (NOMBRE_ZONA) VALUES ('" + zoneName + "')";
                SqlCommand command = new SqlCommand(query, Connection);
                try
                {
                    Datos.Connect();
                    command.ExecuteNonQuery();
                    Datos.Disconnect();
                    Result = 0;
                }
                catch
                {
                    Datos.Disconnect();
                    Result = 1;
                    Datos.LogBox("Error ejecutar AddZone()");
                }
            }

            return Result;   
        }

        public static List<string[]> GetZones()
        {
            List<string[]> result = new List<string[]>();   

        
            string query = "SELECT * FROM ZONAS ORDER BY ID_ZONA ASC";
            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();
                while (registros.Read())
                {
                    string[] strTemp = new string[2];
                    strTemp[0] = registros["ID_ZONA"].ToString();
                    strTemp[1] = registros["NOMBRE_ZONA"].ToString();
                    result.Add(strTemp);

                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetZonez() " + ex.Message);
            }
            
            return result;
        }

        public static string GetZoneName(string id_zona)
        {
            string result="Error.";

            string query = "SELECT NOMBRE_ZONA FROM ZONAS WHERE ID_ZONA='" + id_zona + "' ";
            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();
               
                if (registros.Read()) 
                {
                    result = registros["NOMBRE_ZONA"].ToString();
                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetZoneName() " + ex.Message);
            }


            return result;
        }

        public static int DeleteZona(int id_zona)
        {
            int Result = 1;

            string query = "DELETE FROM ZONAS WHERE ID_ZONA='" + id_zona + "'";
            SqlCommand command = new SqlCommand(query, Connection);
            try
            {
                Datos.Connect();
                command.ExecuteNonQuery();
                Datos.Disconnect();
                Result = 0;
            }
            catch (Exception e)
            {
                Datos.Disconnect();
                Result = 1;
                Datos.LogBox("Error ejecutar DeleteZona() " + e.Message);
            }

            return Result;
        }
        #endregion

        #region [INSTALLATIONS]
        public static int AddInstallation(int id_Zona, string installName)
        {
            int Result = 1;
            if (!string.IsNullOrEmpty(installName))
            {
                string query = "INSERT INTO INSTALACIONES (ID_ZONA, NOMBRE_INSTALACION) values ('" + id_Zona+"','" + installName + "')";
                SqlCommand command = new SqlCommand(query, Connection);

                try
                {
                    Datos.Connect();
                    command.ExecuteNonQuery();
                    Datos.Disconnect();
                    Result = 0;
                }
                catch (Exception ex)
                {
                    Datos.Disconnect();
                    Result = 1;
                    Datos.LogBox("Error ejecutar AddInstallation() " + ex.Message);
                }
            }

            return Result;
        }

        public static List<string[]> GetInstalations(int id_zona)
        {
            List<string[]> result = new List<string[]>();

            string query = "SELECT * FROM INSTALACIONES WHERE ID_ZONA='"+ id_zona+"' ORDER BY ID_INSTALACION ASC";

            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();
                while (registros.Read())
                {
                    string[] strTemp = new string[2];
                    strTemp[0] = registros["ID_INSTALACION"].ToString();
                    strTemp[1] = registros["NOMBRE_INSTALACION"].ToString();
                    result.Add(strTemp);

                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetInstalations() " + ex.Message);
            }

            return result;

        }


        public static string GetInstallationName(string id_inst)
        {
            string result = "Error.";

            string query = "SELECT NOMBRE_INSTALACION FROM INSTALACIONES WHERE ID_INSTALACION='" + id_inst + "' ";
            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();

                if (registros.Read())
                {
                    result = registros["NOMBRE_INSTALACION"].ToString();
                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetInstallationName() " + ex.Message);
            }

            return result;
        }

        public static int DeleteInstallation(int id_installation)
        {
            int Result = 1;

            string query = "DELETE FROM INSTALACIONES WHERE ID_INSTALACION='" + id_installation + "'";
            SqlCommand command = new SqlCommand(query, Connection);
            try
            {
                Datos.Connect();
                command.ExecuteNonQuery();
                Datos.Disconnect();
                Result = 0;
            }
            catch (Exception e)
            {
                Datos.Disconnect();
                Result = 1;
                Datos.LogBox("Error ejecutar DeleteInstallation() " + e.Message);
            }

            return Result;
        }
        #endregion

        #region [EQUIPAMENTS]
        public static int AddEquipament(int id_Installation, string equipamentName)
        {
            int Result = 1;
            if (!string.IsNullOrEmpty(equipamentName))
            {
                string query = "INSERT INTO EQUIPOS (ID_INSTALACION, NOMBRE_EQUIPO) values ('" + id_Installation + "','" + equipamentName + "')";
                SqlCommand command = new SqlCommand(query, Connection);

                try
                {
                    Datos.Connect();
                    command.ExecuteNonQuery();
                    Datos.Disconnect();
                    Result = 0;
                }
                catch (Exception ex)
                {
                    Datos.Disconnect();
                    Result = 1;
                    Datos.LogBox("Error ejecutar AddEquipament() "+ ex.Message);
                }
            }

            return Result;
        }


        public static List<string[]> GetEquipaments(int id_installation)
        {
            List<string[]> result = new List<string[]>();

            string query = "SELECT * FROM EQUIPOS WHERE ID_INSTALACION='" + id_installation + "' ORDER BY ID_EQUIPO ASC";

            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();
                while (registros.Read())
                {
                    string[] strTemp = new string[2];
                    strTemp[0] = registros["ID_EQUIPO"].ToString();
                    strTemp[1] = registros["NOMBRE_EQUIPO"].ToString();
                    result.Add(strTemp);

                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetEquipaments() " + ex.Message);
            }


            return result;

        }

        public static string GetEquipamentName(string id_equi)
        {
            string result = "Error.";

            string query = "SELECT NOMBRE_EQUIPO FROM EQUIPOS WHERE ID_EQUIPO='" + id_equi + "' ";
            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();

                if (registros.Read())
                {
                    result = registros["NOMBRE_EQUIPO"].ToString();
                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetEquipamentName() " + ex.Message);
            }

            return result;
        }

        public static int DeleteEquipament(int id_equipament)
        {
            int Result = 1;

            string query = "DELETE FROM EQUIPOS WHERE ID_EQUIPO='" + id_equipament + "'";
            SqlCommand command = new SqlCommand(query, Connection);
            try
            {
                Datos.Connect();
                command.ExecuteNonQuery();
                Datos.Disconnect();
                Result = 0;
            }
            catch (Exception e)
            {
                Datos.Disconnect();
                Result = 1;
                Datos.LogBox("Error ejecutar DeleteEquipament() " + e.Message);
            }

            return Result;
        }
        #endregion

        #region [CPUS]
        public static int AddCPU(int id_equipo, CPU cpuData)
        {
            int Result = 1;

            
            if (!string.IsNullOrEmpty(cpuData.name) &&
                !string.IsNullOrEmpty(cpuData.ip) && 
                cpuData.rack >= 0 && 
                cpuData.rack <= 16 && 
                cpuData.slot >= 0 && 
                cpuData.slot <= 16
                )
            {
                string query = "INSERT INTO CPUS (ID_EQUIPO, ID_TIPO, NOMBRE_CPU, IP_CPU, RACK_CPU, SLOT_CPU, DIRECCION_CPU, PERIODO_CPU, ESTADO_CPU, CHECKSUM_CPU, CHECKSUMDATE_CPU) values ('" + id_equipo + "','" + cpuData.type + "','"+cpuData.name+ "','" + cpuData.ip + "','" + cpuData.rack + "','" + cpuData.slot + "', '" + cpuData.adreess + "','" + cpuData.cycle + "','" + cpuData.state + "','" + cpuData.checksum + "','" + cpuData.checksumdate + "')";
                SqlCommand command = new SqlCommand(query, Connection);

                try
                {
                    Datos.Connect();
                    command.ExecuteNonQuery();
                    Datos.Disconnect();
                    Result = 0;
                }
                catch (Exception e)
                {
                    Datos.Disconnect();
                    Result = 1;
                    Datos.LogBox("Error ejecutar AddCPU() " + e.Message);
                }
            }else Datos.LogBox("Error al ingresar parametros.");

            return Result;  
        }


        public static List<string[]> GetCPUs(int id_equipament)
        {
            List<string[]> result = new List<string[]>();

            string query = "SELECT * FROM CPUS WHERE ID_EQUIPO='" + id_equipament + "' ORDER BY ID_CPU ASC";

            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();
                while (registros.Read())
                {
                    string[] strTemp = new string[9];
                    strTemp[0] = registros["ID_CPU"].ToString();
                    strTemp[1] = registros["ID_EQUIPO"].ToString();
                    strTemp[2] = registros["ID_TIPO"].ToString();
                    strTemp[3] = registros["NOMBRE_CPU"].ToString();
                    strTemp[4] = registros["IP_CPU"].ToString();
                    strTemp[5] = registros["RACK_CPU"].ToString();
                    strTemp[6] = registros["SLOT_CPU"].ToString();
                    strTemp[7] = registros["PERIODO_CPU"].ToString();
                    strTemp[8] = registros["ESTADO_CPU"].ToString();
                    result.Add(strTemp);

                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetCPUs() " + ex.Message);
            }

            return result;

        }


        public static List<string[]> GetAllsCPUs()
        {
            List<string[]> result = new List<string[]>();

            string query = "SELECT * FROM CPUS ORDER BY ID_CPU ASC";

            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();
                while (registros.Read())
                {
                    string[] strTemp = new string[12];
                    strTemp[0] = registros["ID_CPU"].ToString();
                    strTemp[1] = registros["ID_EQUIPO"].ToString();
                    strTemp[2] = registros["ID_TIPO"].ToString();
                    strTemp[3] = registros["NOMBRE_CPU"].ToString();
                    strTemp[4] = registros["IP_CPU"].ToString();
                    strTemp[5] = registros["RACK_CPU"].ToString();
                    strTemp[6] = registros["SLOT_CPU"].ToString();
                    strTemp[7] = registros["PERIODO_CPU"].ToString();
                    strTemp[8] = registros["ESTADO_CPU"].ToString();
                    strTemp[9] = registros["CHECKSUM_CPU"].ToString();
                    strTemp[10] = registros["CHECKSUMDATE_CPU"].ToString();
                    strTemp[11] = registros["DIRECCION_CPU"].ToString();
                    result.Add(strTemp);

                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetAllsCPUs() " + ex.Message);
            }

            return result;

        }

        public static CPU GetCpuData(string id_cpu)
        {
            CPU CPUresult = new CPU();

            string query = "SELECT * FROM CPUS WHERE ID_CPU='" + id_cpu + "' ";
            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();

                if (registros.Read())
                {
                    CPUresult.id = Convert.ToInt32(registros["ID_CPU"]);
                    CPUresult.type = Convert.ToInt32(registros["ID_TIPO"]);
                    CPUresult.name = registros["NOMBRE_CPU"].ToString();
                    CPUresult.ip = registros["IP_CPU"].ToString();
                    CPUresult.rack = Convert.ToInt32(registros["RACK_CPU"]);
                    CPUresult.slot = Convert.ToInt32(registros["SLOT_CPU"]);
                    CPUresult.cycle = Convert.ToInt32(registros["PERIODO_CPU"]);
                    CPUresult.state = Convert.ToInt32(registros["ESTADO_CPU"]);
                    CPUresult.checksum = Convert.ToInt32(registros["CHECKSUM_CPU"]);
                    CPUresult.checksumdate = Convert.ToDateTime(registros["CHECKSUMDATE_CPU"]);
                    CPUresult.adreess = Convert.ToInt32(registros["DIRECCION_CPU"]);
                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetEquipamentName() " + ex.Message);
            }

            return CPUresult;
        }


        public static int UpdateStateCPU(int id_cpu, int value)
        {
            int Result = 1;
            string dateTimeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string query = "UPDATE CPUS SET ESTADO_CPU='" + value + "', CHECKSUMDATE_CPU='" + dateTimeNow + "' WHERE ID_CPU='" + id_cpu + "'";
            SqlCommand command = new SqlCommand(query, Connection);
            try
            {
                Datos.Connect();
                command.ExecuteNonQuery();
                Datos.Disconnect();
                Result = 0;
            }
            catch (Exception e)
            {
                Datos.Disconnect();
                Result = 1;
                Datos.LogBox("Error ejecutar UpdateStateCPU() " + e.Message);
            }
        
            return Result;
        }

        public static int UpdateChecksumCPU(int id_cpu, int value)
        {
            int Result = 1;
            string dateTimeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string query = "UPDATE CPUS SET ESTADO_CPU='2', CHECKSUM_CPU='" + value + "', CHECKSUMDATE_CPU='" + dateTimeNow + "' WHERE ID_CPU='" + id_cpu + "'";
            SqlCommand command = new SqlCommand(query, Connection);
            try
            {
                Datos.Connect();
                command.ExecuteNonQuery();
                Datos.Disconnect();
                Result = 0;
            }
            catch (Exception e)
            {
                Datos.Disconnect();
                Result = 1;
                Datos.LogBox("Error ejecutar UpdateChecksumCPU() " + e.Message);
            }

            return Result;
        }

        public static int DeleteCPU(int id_cpu)
        {
            int Result = 1;

            string query = "DELETE FROM CPUS  WHERE ID_CPU='" + id_cpu + "'";
            SqlCommand command = new SqlCommand(query, Connection);
            try
            {
                Datos.Connect();
                command.ExecuteNonQuery();
                Datos.Disconnect();
                Result = 0;
            }
            catch (Exception e)
            {
                Datos.Disconnect();
                Result = 1;
                Datos.LogBox("Error ejecutar DeleteCPU() " + e.Message);
            }

            return Result;
        }

        public static List<string[]> GetTypes()
        {
            List<string[]> result = new List<string[]>();

            string query = "SELECT * FROM TIPOS  ORDER BY ID_TIPO ASC";

            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();
                while (registros.Read())
                {
                    string[] strTemp = new string[2];
                    strTemp[0] = registros["ID_TIPO"].ToString();
                    strTemp[1] = registros["MODELO_HARD"].ToString();
                    result.Add(strTemp);

                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetTypes() " + ex.Message);
            }

            return result;

        }

        public static string GetTypeName(int id_type)
        {
            string result = "Error.";

            string query = "SELECT MODELO_HARD FROM TIPOS WHERE ID_TIPO='" + id_type + "' ";
            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();

                if (registros.Read())
                {
                    result = registros["MODELO_HARD"].ToString();
                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetTypeName() " + ex.Message);
            }

            return result;
        }

        #endregion

        #region [LOGS]

        public static void LogBox(string data)
        {
            Datos.Log = data;


            string dateTimeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string query = "INSERT INTO LOGAPP ( FECHA_LOGAPP, TEXT_LOGAPP) values ('" + dateTimeNow + "','" + data + "')";
            SqlCommand command = new SqlCommand(query, Connection);

            try
            {
                Datos.Connect();
                command.ExecuteNonQuery();
                Datos.Disconnect();

            }
            catch (Exception ex)
            {
                Datos.Disconnect();
            }

        }


        public static int AddEventLog(int id_cpu, string message, int clas)
        {
            int Result = 1;
            string dateTimeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            /* CLASE DE MENSAJE
             * 0-Sin dato (BLANCO)
             * 1-Error de concordancia (ROJO)
             * 2-Se elimino error de discordancia (VERDE)
             * 3-Error de sistema (AMARILLO)
             */

            string query = "INSERT INTO LOGS (ID_CPU, FECHA_LOG, TEXT_LOG, CLASE_LOG) values ('" + id_cpu + "','" + dateTimeNow + "','" + message + "','" + clas + "')";
            SqlCommand command = new SqlCommand(query, Connection);

            try
            {
                Datos.Connect();
                command.ExecuteNonQuery();
                Datos.Disconnect();
                Result = 0;
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Result = 1;
                Datos.LogBox("Error ejecutar AddEventLog() " + ex.Message);
            }
            

            return Result;
        }

        public static List<string[]> GetCpuLogs(int id_cpu)
        {
            List<string[]> result = new List<string[]>();


            string query = "SELECT * FROM LOGS WHERE ID_CPU='" + id_cpu + "' ORDER BY FECHA_LOG DESC";
            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();
                while (registros.Read())
                {
                    string[] strTemp = new string[3];

                  
                    string format1 = "dd/MM/yyyy";
                    string format2 = "HH:mm:ss";

                    DateTime dateTime = Convert.ToDateTime(registros["FECHA_LOG"].ToString());
                    

                    strTemp[0] = dateTime.ToString(format1);
                    strTemp[1] = dateTime.ToString(format2);
                    strTemp[2] = registros["TEXT_LOG"].ToString();
                    result.Add(strTemp);

                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetCpuLogs() " + ex.Message);
            }

            return result;
        }

        public static List<string[]> GetLogs()
        {
            List<string[]> result = new List<string[]>();


            string query = "SELECT * FROM LOGS ORDER BY FECHA_LOG DESC";
            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();
                while (registros.Read())
                {
                    string[] strTemp = new string[5];

                    string format1 = "dd/MM/yyyy";
                    string format2 = "HH:mm:ss";

                    DateTime dateTime = Convert.ToDateTime(registros["FECHA_LOG"].ToString());

                    strTemp[0] = dateTime.ToString(format1);
                    strTemp[1] = dateTime.ToString(format2);
                    strTemp[2] = registros["TEXT_LOG"].ToString();
                    strTemp[3] = registros["ID_CPU"].ToString();
                    strTemp[4] = registros["CLASE_LOG"].ToString();
                    result.Add(strTemp);

                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetLogs() " + ex.Message);
            }

            return result;
        }

        public static List<string[]> GetLogsApp()
        {
            List<string[]> result = new List<string[]>();


            string query = "SELECT * FROM LOGAPP ORDER BY FECHA_LOGAPP DESC";
            try
            {
                Datos.Connect();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader registros = command.ExecuteReader();
                while (registros.Read())
                {
                    string[] strTemp = new string[3];

                    string format1 = "dd/MM/yyyy";
                    string format2 = "hh:mm:ss";

                    DateTime dateTime = Convert.ToDateTime(registros["FECHA_LOGAPP"].ToString());

                    strTemp[0] = dateTime.ToString(format1);
                    strTemp[1] = dateTime.ToString(format2);
                    strTemp[2] = registros["TEXT_LOGAPP"].ToString();

                    result.Add(strTemp);

                }
                Datos.Disconnect();
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Datos.LogBox("Error ejecutar GetLogsApp() " + ex.Message);
            }

            return result;
        }

        public static int EraseAllLog()
        {
            int Result = 1;

            string query = "TRUNCATE TABLE LOGS";
            SqlCommand command = new SqlCommand(query, Connection);

            try
            {
                Datos.Connect();
                command.ExecuteNonQuery();
                Datos.Disconnect();
                Result = 0;
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Result = 1;
                Datos.LogBox("Error ejecutar EraseAllLog() " + ex.Message);
            }

            return Result;
        }

        public static int EraseCpuEventLog(int id_cpu)
        {
            int Result = 1;
            
            string query = "DELETE FROM LOGS WHERE ID_CPU='" + id_cpu + "'";
            SqlCommand command = new SqlCommand(query, Connection);

            try
            {
                Datos.Connect();
                command.ExecuteNonQuery();
                Datos.Disconnect();
                Result = 0;
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Result = 1;
                Datos.LogBox("Error ejecutar EraseCpuEventLog() " + ex.Message);
            }


            return Result;
        }


        public static int EraseLogApp()
        {
            int Result = 1;

            string query = "TRUNCATE TABLE LOGAPP";
            SqlCommand command = new SqlCommand(query, Connection);

            try
            {
                Datos.Connect();
                command.ExecuteNonQuery();
                Datos.Disconnect();
                Result = 0;
            }
            catch (Exception ex)
            {
                Datos.Disconnect();
                Result = 1;
                Datos.LogBox("Error ejecutar EraseLogApp() " + ex.Message);
            }

            return Result;
        }

        #endregion
    }

    public class CPU
    {
        public int id { get; set; }
        public string name { get; set; }
        public string ip { get; set; }
        public int rack { get; set; }   
        public int slot { get; set;}
        public int type { get; set; } // 1- S7300, 2- S7400, 3- S71200, 4- S71500
        public int cycle { get; set; }
        public int state { get; set; }
        public int checksum { get; set; }
        public DateTime checksumdate { get; set; }
        public int adreess { get; set; }

        public CPU()
        {

        }



    }
  

}
