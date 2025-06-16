using Snap7;
using System;
using static Snap7.S7Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Watch7
{
    public class Automatismo
    {
        List<string[]> cpusList = new List<string[]>();
        CPU cpu1 = new CPU();

        private int progress;
        public Automatismo() {
            progress = 0;           
        }

        //Lee la lista completa de CPUs independientemente de la instalación
        public int getListCpus()
        {
            int result = 1;
            try
            {
                this.cpusList = Datos.GetAllsCPUs();
                result = 0;
            }catch(Exception ex) {
                Datos.LogBox("Error leer lista de CPUS en automatico " + ex.Message); 
                result=1;
            }
            progress = 0;
            return result;
        }

        // Carga los datos de un item de la lista al objeto CPU
        private void ChargeCpuData(string[] cpuData)
        {
            cpu1.id = Int32.Parse(cpuData[0]);
            cpu1.name= cpuData[3];
            cpu1.ip = cpuData[4];
            cpu1.rack = Int32.Parse(cpuData[5]);
            cpu1.slot = Int32.Parse(cpuData[6]);
            cpu1.type = Int32.Parse(cpuData[2]);
            cpu1.cycle = Int32.Parse(cpuData[7]);
            cpu1.state = Int32.Parse(cpuData[8]);
            cpu1.checksum = Int32.Parse(cpuData[9]);
            cpu1.checksumdate = DateTime.Parse(cpuData[10]);
            cpu1.adreess = Int32.Parse(cpuData[11]);


        }

        //Agrega el dateTime a la ultima actualización según el item de tiempo seleccionado para la cpu
        private DateTime AddDateTime(DateTime dateTime, int item)
        {
                 
            switch (item)
            {
                case 0:
                    dateTime=dateTime.AddSeconds(30);
                    break;
                case 1:
                    dateTime=dateTime.AddMinutes(1);
                    break;
                case 2:
                    dateTime=dateTime.AddMinutes(10);
                    break;
                case 3:
                    dateTime=dateTime.AddMinutes(30);
                    break;
                case 4:
                    dateTime=dateTime.AddHours(1);
                    break;
                case 5:
                    dateTime=dateTime.AddHours(2);
                    break;
                case 6:
                    dateTime=dateTime.AddHours(6);
                    break;
                case 7:
                    dateTime=dateTime.AddHours(12);
                    break;
                case 8:
                    dateTime=dateTime.AddDays(1);
                    break;
                case 9:
                    dateTime=dateTime.AddDays(2);
                    break;
                case 10:
                    dateTime=dateTime.AddDays(7);
                    break;
                case 11:
                    dateTime=dateTime.AddDays(30);
                    break;
                case 12:
                    dateTime=dateTime.AddYears(100);
                    break;
                default:
                    dateTime=dateTime.AddYears(100);
                    break;

            }
        
            return dateTime;
        }

        //Cada vez que se ejecuta, testea una nueva CPU si es que corresponde segun el tiempo de ciclo de vigilancia
        public int CheckProgres(int mode) //0=sin cyclo de lectura, 1=con cyclo definido en la cpu, 2=lee solo una sola cpu
        {
            int porcent = 0;

                if (mode != 2 && cpusList.Count > 0) ChargeCpuData(cpusList[progress]);

                DateTime localTime = DateTime.Now;

                if (DateTime.Compare(AddDateTime(cpu1.checksumdate, cpu1.cycle), localTime) < 0 || mode == 0 || mode == 2)
                {

                    string connState;
                    Int32 gettingChecksum = 0;

                    ChecksumCalc Calc1 = new ChecksumCalc(cpu1);

                    try
                    {
                        Datos.LogBox("Descargando y calculando checksum de: " + cpu1.name + ", IP: " + cpu1.ip + "  Espere...");
                        connState = Calc1.Conect();
                        gettingChecksum = Calc1.Calc();


                    }
                    catch (Exception e) { Datos.LogBox(e.Message); }

                    if (cpu1.checksum != 0) //Debe al menos haberse cargado alguna vez el checksum, si no hacerlo manualmente.
                    {
                        if (gettingChecksum != 0) //Si la adquisición fue correcta
                        {
                            if (gettingChecksum == cpu1.checksum) //Si los checksum son iguales
                            {
                                Datos.UpdateStateCPU(cpu1.id, 2); //Circulo verde, checksum OK
                            }
                            else
                            {
                                if (cpu1.state == 2)
                                {
                                    Datos.AddEventLog(cpu1.id, "Detectados cambios en el modulo " + cpu1.name + " con IP: " + cpu1.ip, 1);
                                }
                                Datos.UpdateStateCPU(cpu1.id, 1); //Circulo rojo, checksum NOK
                            }
                        }
                        else Datos.UpdateStateCPU(cpu1.id, 0);//Circulo gris, error o no conexion.
                    }
                    else
                    {
                        if (gettingChecksum != 0)
                        {
                            Datos.UpdateChecksumCPU(cpu1.id, gettingChecksum);  //Actualiza el checksum automaticamente
                            Datos.UpdateStateCPU(cpu1.id, 2);
                        }
                        else Datos.UpdateStateCPU(cpu1.id, 0);
                    }

                }


                if (mode != 2)
                {
                    progress++;
                    porcent = (progress * 1000) / cpusList.Count;
                }
                else porcent = 1000;
            

            return porcent;
        }

        public int checkOnlyOneCpu(string[] cpuData)
        {
            int Result = 1;
            cpu1.id = Int32.Parse(cpuData[0]);
            cpu1.name = cpuData[3];
            cpu1.ip = cpuData[4];
            cpu1.rack = Int32.Parse(cpuData[5]);
            cpu1.slot = Int32.Parse(cpuData[6]);
            cpu1.type = Int32.Parse(cpuData[2]);
            cpu1.cycle = Int32.Parse(cpuData[7]);
            cpu1.state = Int32.Parse(cpuData[8]);
            cpu1.checksum = Int32.Parse(cpuData[9]);
            cpu1.checksumdate = DateTime.Parse(cpuData[10]);
            cpu1.adreess = Int32.Parse(cpuData[11]);

            CheckProgres(2);

            return Result;
        }

        public void Stop()
        {
            if(progress != cpusList.Count)
            {
                progress = cpusList.Count;
            }          
        }

        public void ContinuosCycle()
        {
            if (progress == cpusList.Count)
            {
                progress = 0;
            }
        }



    }

    public class ChecksumCalc
    {
        CPU CPUdata = new CPU();
        private Int32 Checksum = 0;
        private string stateText;
        private S7Client Client;

        private S7Client.S7BlocksList bloques;
        private S7Client.S7BlockInfo Info;
        ushort[] ListaBloques = new ushort[0x1000];
        Byte[] TIAChecksums = new Byte[24];
        int ItemsCount = 0x0;
        public int Result = 0;


        public ChecksumCalc(CPU CPUdata)
        {
            this.CPUdata = CPUdata;
            Client = new S7Client();
        }

        public string Conect()
        {
           
            int Result = Client.ConnectTo(CPUdata.ip, CPUdata.rack, CPUdata.slot);
            return Client.ErrorText(Result);
        }

        public Int32 Calc()
        {
            Int32 checkSum = 0;

            
            if (CPUdata.type==1 || CPUdata.type == 2) //Calculo para CPUs S7-300 y S7-400
            {
                //Lee la cantidad de bloques de cada tipo
                Result = Result + Client.ListBlocks(ref bloques);

                //Lista los bloques de tipo OB y suma al checksum
                if (bloques.OBCount > 0)
                {
                    ItemsCount = bloques.OBCount;
                    Result = Result + Client.ListBlocksOfType(S7Client.Block_OB, ListaBloques, ref ItemsCount);
                    for (int num = 0; num < ItemsCount; num++)
                    {
                        Result = Result + Client.GetAgBlockInfo(S7Client.Block_OB, ListaBloques[num], ref Info);
                        checkSum = AddCheckSum(checkSum, Info.CheckSum);
                    }
                }

                //Lista los bloques de tipo FB y suma al checksum
                if (bloques.FBCount > 0)
                {
                    ItemsCount = bloques.FBCount;
                    Result = Result + Client.ListBlocksOfType(S7Client.Block_FB, ListaBloques, ref ItemsCount);
                    for (int num = 0; num < ItemsCount; num++)
                    {
                        Result = Result + Client.GetAgBlockInfo(S7Client.Block_FB, ListaBloques[num], ref Info);
                        checkSum = AddCheckSum(checkSum, Info.CheckSum);
                    }
                }

                //Lista los bloques de tipo FC y suma al checksum
                if (bloques.FCCount > 0)
                {
                    ItemsCount = bloques.FCCount;
                    Result = Result + Client.ListBlocksOfType(S7Client.Block_FC, ListaBloques, ref ItemsCount);
                    for (int num = 0; num < ItemsCount; num++)
                    {
                        Result = Result + Client.GetAgBlockInfo(S7Client.Block_FC, ListaBloques[num], ref Info);
                        checkSum = AddCheckSum(checkSum, Info.CheckSum);
                    }
                }

                //Lista los bloques de tipo DB y suma al checksum
                if (bloques.DBCount > 0)
                {
                    ItemsCount = bloques.DBCount;
                    Result = Result + Client.ListBlocksOfType(S7Client.Block_DB, ListaBloques, ref ItemsCount);
                    for (int num = 0; num < ItemsCount; num++)
                    {
                        Result = Result + Client.GetAgBlockInfo(S7Client.Block_DB, ListaBloques[num], ref Info);
                        checkSum = AddCheckSum(checkSum, Info.CheckSum);
                    }

                }

                //Lista los bloques de tipo SFB y suma al checksum
                if (bloques.SFBCount > 0)
                {
                    ItemsCount = bloques.SFBCount;
                    Result = Result + Client.ListBlocksOfType(S7Client.Block_SFB, ListaBloques, ref ItemsCount);
                    for (int num = 0; num < ItemsCount; num++)
                    {
                        Result = Result + Client.GetAgBlockInfo(S7Client.Block_SFB, ListaBloques[num], ref Info);
                        checkSum = AddCheckSum(checkSum, Info.CheckSum);
                    }
                }

                //Lista los bloques de tipo SFC y suma al checksum
                if (bloques.SFCCount > 0)
                {
                    ItemsCount = bloques.SFCCount;
                    Result = Result + Client.ListBlocksOfType(S7Client.Block_SFC, ListaBloques, ref ItemsCount);
                    for (int num = 0; num < ItemsCount; num++)
                    {
                        Result = Result + Client.GetAgBlockInfo(S7Client.Block_SFC, ListaBloques[num], ref Info);
                        checkSum = AddCheckSum(checkSum, Info.CheckSum);
                    }
                }

                //Lista los bloques de tipo SDB Configuracion de Hardware y Netpro
                if (bloques.SDBCount > 0)
                {
                    ItemsCount = bloques.SDBCount;
                    Result = Result + Client.ListBlocksOfType(S7Client.Block_SDB, ListaBloques, ref ItemsCount);
                    for (int num = 0; num < ItemsCount; num++)
                    {
                        Client.GetAgBlockInfo(S7Client.Block_SDB, ListaBloques[num], ref Info);
                        checkSum = AddCheckSum(checkSum, Info.CheckSum);
                    }
                }

            }
            if (CPUdata.type == 3 || CPUdata.type == 4) //Calculo para CPUs S7-1200 y S7-1500
            {
                int r;
                r = Client.MBRead(CPUdata.adreess, 24, TIAChecksums);
                if (r == 0)
                {
                    foreach (byte b in TIAChecksums)
                    {
                        checkSum = AddCheckSum(checkSum, b);
                    }
                    Result = 0;
                }
                else Result = 1;

            }

            if (Result == 0)
            {
                Datos.LogBox("Función CalcChecksum( ) a: " + CPUdata.ip + " realizado OK");
                return checkSum;

            }
            else
            {
                Datos.LogBox("ERROR Función CalcChecksum( ) a: " + CPUdata.ip + " NOK - Diag: " + Client.ErrorText(Result));
                return 0;// Checksum = 0 indica un error al calcular el checksum.
            }
            
        }

        private Int32 AddCheckSum(Int32 ChkSm, Int32 num)
        {
            
            ChkSm = ChkSm + num;
            if (ChkSm >= 100000000)
            {
                ChkSm = ChkSm - 100000000;
            }
            return ChkSm;
        }




    }

    



    
}
