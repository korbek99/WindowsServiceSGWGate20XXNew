using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entities;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Net.Sockets;


namespace DataAccess
{
    public class DataNextivaDAL
    {
        BaseDatos dbm = new BaseDatos();

        public ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
        public int ConvertToASCIIString(string var)
        {
            int int_ASCII = 0;

            string s = var;
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            int_ASCII = BitConverter.ToInt32(bytes, 0);

            return int_ASCII;

        }
        //private static void Linq2XmlCrearFicheroXml2()
        //{
        //    //             string strXml = @"<Prueba>
        //    //                      <Nombre>Juan</Nombre>
        //    //                      <EMail>juan@gmail.com</EMail>
        //    //                      <Telefono Tipo='Móvil'>666666666</Telefono>
        //    //                      <Telefono Tipo='Trabajo'>911111111</Telefono>
        //    //                    </Prueba>";

        //    //             XElement xml = XElement.Parse(strXml);

        //    //             XDocument pruebaXml = new XDocument(xml);
        //    //             pruebaXml.Save("Prueba.xml");

        //    //             string pathString = @"C:\Verint\AlarmInterface\";
        //    //             string fileName = "Prueba.xml";

        //    //             string pathStringFinal = System.IO.Path.Combine(pathString, fileName);
        //}

        private Boolean SendDataWithComunicationNextivaDAL(List<AlarmNextiva> ObjetoLista)
        {

            // when you receive an alarm from the camera, open a socket connection to 
            // 192.168.10.28, port 8081
            // When the connection is made, send the alarm text. that's all you need to do.


            Boolean res = false;
            string pathString = "";
            string stringAscii = "";
            string fileName = "";
            string CameraName = "";
            int cantidad = 1;
            int cantidad2 = 1;
            int Numerocantidad = 1;
            string str_match = "";

            NextivaXMLConfig objXMl = new NextivaXMLConfig();
            SWGParams objParams = new SWGParams();
            

            CameraName = "Domo PTZ";
            objXMl.XMLNextID = 1;
            objXMl.XMLNextNiveles = "DEBUG"; // "INFO";
            objXMl.XMLNextSiteName = "VM28S12N64SP3MS";
            objXMl.XMLNextSiteNameUrl = "tcp://192.168.10.28:5005";
            objXMl.XMLNextSiteUser = "Administrator";
            objXMl.XMLNextSitePass = "cctvware";
            objXMl.XMLNextAlarmSite = "VM28S12N64SP3MS";
            objXMl.XMLNextListenResponse = "OK10;";
            objXMl.XMLNextListenError = "ERROR10;";
            objXMl.XMLNextPathString = @"\\VM28N64SP3MS\Verint\AlarmInterface\";
            objXMl.XMLNextFileName = "config.xml";

            pathString = objXMl.XMLNextPathString; // @"\\VM28N64SP3MS\Verint\AlarmInterface\";
            fileName = objXMl.XMLNextFileName; // "config.xml";

            string pathStringFinal = System.IO.Path.Combine(pathString, fileName);

            //if (!System.IO.File.Exists(pathString))
            //{
            using (System.IO.FileStream fs = System.IO.File.Create(pathStringFinal))
            {
                for (byte i = 0; i < 100; i++)
                {
                    fs.WriteByte(i);
                }
            }
            //}
            //else
            //{
            //    Console.WriteLine("File \"{0}\" already exists.", fileName);
            //}
            string strTest = "";
            if (!String.IsNullOrEmpty(pathString) && !String.IsNullOrEmpty(fileName))
            {
                try
                {
                    //string str = "";
                    //string str_salto = "\r\n";
                    //str += "<config>" + str_salto;
                    //str += "<!-- Sample configuration file -->" + str_salto;
                    //str += str_salto;
                    //str += "<Logging filename='Logging/NextivaAlarmServer.log' level='" + objXMl.XMLNextNiveles + "' daysToLive='7'/>" + str_salto;
                    //str += str_salto;
                    //str += "<tcpPort name='tcp' port='8081'/>" + str_salto;
                    //str += "<comPort name='com' port='COM1' baud='9600' dataBits='8' parity='none' stopBits='1' handshake='none'/>" + str_salto;
                    //str += str_salto;
                    //str += "<site name='" + objXMl.XMLNextSiteName + "' url='" + objXMl.XMLNextSiteNameUrl + "' username='" + objXMl.XMLNextSiteUser + "' password='" + objXMl.XMLNextSitePass + "'/>" + str_salto;
                    //str += str_salto;
                    //str += "<alarm site='" + objXMl.XMLNextAlarmSite + "'/>" + str_salto;
                    //str += str_salto;
                    //str += "<listener input='tcp' separator='!' response='" + objXMl.XMLNextListenResponse + "' error='" + objXMl.XMLNextListenError + "'>" + str_salto;
                    //str += str_salto;

                    //foreach (AlarmNextiva objlista in ObjetoLista)
                    //{
                    //    str += str_salto;
                    //    str += "<rule response='" + objXMl.XMLNextListenResponse + "'>" + str_salto;
                    //    str += str_salto;
                    //    //str += "<match equals='match" + cantidad2 + "'/>" + str_salto;
                    //    str += "<match contains='AlarmMsg'/>" + str_salto;
                    //    str += str_salto;
                    //    str += "<event site='" + objXMl.XMLNextAlarmSite + "' id='1' argument='prueba de analitica  " + objlista.AlarmSentRuleDescrip + "'>" + str_salto;
                    //    //str += "<event site='" + objXMl.XMLNextAlarmSite + "' id='1' argument='No Hands!'>" + str_salto;
                    //    str += str_salto;
                    //    ////str += "<camera number='" + CameraName + "'/>" + str_salto;
                    //    str += "<camera number='" + CameraName + "' preset='" + VerifyVCAAlarmasRules(objlista.AlarmSentRuleID) + "'/>" + str_salto;
                    //    str += "</event>" + str_salto;
                    //    str += str_salto;
                    //    str += "</rule>" + str_salto;
                    //    cantidad2++;
                    //}

                    //str += str_salto;
                    //str += "</listener>" + str_salto;
                    //str += str_salto;
                    //str += "</config>";

                    string str = "";
                    str += "<config>";
                    str += "<!-- Sample configuration file -->" ;
                    str += "<Logging filename='Logging/NextivaAlarmServer.log' level='" + objXMl.XMLNextNiveles + "' daysToLive='7'/>";
                    str += "<tcpPort name='tcp' port='8081'/>";
                    str += "<comPort name='com' port='COM1' baud='9600' dataBits='8' parity='none' stopBits='1' handshake='none'/>";
                    str += "<site name='" + objXMl.XMLNextSiteName + "' url='" + objXMl.XMLNextSiteNameUrl + "' username='" + objXMl.XMLNextSiteUser + "' password='" + objXMl.XMLNextSitePass + "'/>";
                    str += "<alarm site='" + objXMl.XMLNextAlarmSite + "'/>";
                    str += "<listener input='tcp' separator='!' response='" + objXMl.XMLNextListenResponse + "' error='" + objXMl.XMLNextListenError + "'>";

                    foreach (AlarmNextiva objlista in ObjetoLista)
                    {
                        str += "<rule response='" + objXMl.XMLNextListenResponse + "'>" ;
                        str += "<match contains='AlarmMsg'/>" ;
                        str += "<event site='" + objXMl.XMLNextAlarmSite + "' id='1' argument='prueba de analitica  " + objlista.AlarmSentRuleDescrip + "'>" ;
                        str += "<camera number='" + CameraName + "' preset='" + VerifyVCAAlarmasRules(objlista.AlarmSentRuleID) + "'/>";
                        str += "</event>" ;
                        str += "</rule>";
                        cantidad2++;
                    }
                    str += "</listener>" ;
                    str += "</config>";


                    System.IO.File.WriteAllText(pathString + fileName, str);

                    string mensaje = str; // "prueba de analitica";

                    if (!String.IsNullOrEmpty(mensaje))
                    {
                        using (TcpClient clientSocket = new TcpClient())
                        {
                            clientSocket.Connect("192.168.10.28", 8081);
                            NetworkStream serverStream = clientSocket.GetStream();
                            byte[] arrayMsg = Encoding.ASCII.GetBytes(mensaje);
                            byte[] mensajeFinal = arrayMsg, enviarServidor;
                            serverStream.WriteTimeout = 2000;
                            serverStream.Write(mensajeFinal, 0, mensajeFinal.Length);
                            serverStream.Flush();
                            byte[] inStream = new byte[10025];
                            serverStream.ReadTimeout = 2000;
                            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                            int respuesta = int.Parse(returndata);
                        }
                        res = true;
                    }
                    else {
                        res = false;
                    }  
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error de SQL :" + e.Message);
                    ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                    objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DataNextivaDAL/SendDataWithComunicationNextivaDAL");
                }
                catch (SocketException ex)
                {
                    Console.WriteLine("Error :" + ex.Message);
                    ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                    objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/SendDataWithComunicationNextivaDAL");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error :" + e.Message);
                    ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                    objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DataNextivaDAL/SendDataWithComunicationNextivaDAL");
                }
            }
            return res;
        }

        public int GetLastIDE(int idchannel)
        {
            SqlConnection con = new SqlConnection();
		    SqlParameter parametros;
            int    int_lastID =0;
		    try
		    {
			    con = dbm.getConexion();
			    con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_LastAlarmSentNextiva_by_ID", con);
			    parametros = cmd.Parameters.Add("@AlarmSentChannel", SqlDbType.Int);
			    parametros.Value = idchannel;
			    cmd.CommandType = CommandType.StoredProcedure;
			    SqlDataReader dr = cmd.ExecuteReader();
			    while (dr.Read())
			    {
                    int_lastID = dr.GetInt32(0);
			    }
			    con.Close();
		    }
		    catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		    catch (Exception e) { Console.WriteLine("Error :" + e.Message); }

		    return int_lastID;
        }

        private string FormarCameraIde(int idchannel)
        {
            string resp = "";
            string idchannels = Convert.ToString(idchannel);
            if (idchannels.Length > 0)
            {
                resp = "000" + idchannels;
            }
            if (idchannels.Length > 1 && idchannels.Length < 3)
            {
                resp = "00" + idchannel;
            }
            if (idchannels.Length > 2 && idchannels.Length < 4)
            {
                resp = "0" + idchannels;
            }
            if (idchannels.Length > 3 && idchannels.Length == 4)
            {
                resp = idchannels;
            }
            return resp;

        }
        public Boolean SendDataCameraToNextivaDAL(List<AlarmNextiva> Objeto)
        {
            Boolean res = false;
            try
            {
                //VA A FUNCION QUE CREA XML
                res = SendDataWithComunicationNextivaDAL(Objeto);

                //if (res == true)
                //{
                    //RECORRE LISTA , LLENA ENTIDAD Y GRABA EN BASE DATOS
                    foreach (AlarmNextiva objlista in Objeto)
                    {
                        AlarmNextiva enti = new AlarmNextiva();
                        enti.AlarmSentIDE = objlista.AlarmSentIDE;
                        enti.AlarmSentChannel = objlista.AlarmSentChannel;
                        enti.AlarmSentState = objlista.AlarmSentState;
                        enti.AlarmSentventType = objlista.AlarmSentventType;
                        enti.AlarmSentRuleID = objlista.AlarmSentRuleID;
                        enti.AlarmSentTargetID = objlista.AlarmSentTargetID;
                        enti.AlarmSentTargetType = objlista.AlarmSentTargetType;
                        enti.AlarmSentrctTarget = objlista.AlarmSentrctTarget;
                        enti.AlarmSentTargetSpeed = objlista.AlarmSentTargetSpeed;
                        enti.AlarmSentTargetDirection = objlista.AlarmSentTargetDirection;
                        enti.AlarmSentDescription =  objlista.AlarmSentDescription;
                        enti.AlarmSentEstado = objlista.AlarmSentEstado;
                        enti.AlarmSentCustCompanyID = objlista.AlarmSentCustCompanyID;

                        if (IngrDataCameraToNextivaSQLDAL(enti) == true)
                        {

                        }else{
                            Console.WriteLine("Occurio un Error de Ingreso SQL");
                            ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                            objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :Occurio un Error de Ingreso SQL", 1, 1, "DataNextivaDAL/SendDataCameraToNextivaDAL");
                        }
                    }
                    res = true;
                //}else{
                //    res = false;
                //}
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DataNextivaDAL/SendDataCameraToNextivaDAL");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "DataNextivaDAL/SendDataCameraToNextivaDAL");
            }
            return res;
        }
        public Boolean IngrDataCameraToNextivaSQLDAL(AlarmNextiva ObjAlarm)
        {

            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {

                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Insert_AlarmSentNextiva", con);
                parametros = cmd.Parameters.Add("@AlarmSentIDE", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentIDE;
                parametros = cmd.Parameters.Add("@AlarmSentChannel", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentChannel;
                parametros = cmd.Parameters.Add("@AlarmSentState", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentState;
                parametros = cmd.Parameters.Add("@AlarmSentventType", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentventType;
                parametros = cmd.Parameters.Add("@AlarmSentRuleID", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentRuleID;
                parametros = cmd.Parameters.Add("@AlarmSentTargetID", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentTargetID;
                parametros = cmd.Parameters.Add("@AlarmSentTargetType", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentTargetType;
                parametros = cmd.Parameters.Add("@AlarmSentrctTarget", SqlDbType.VarChar);
                parametros.Value = ObjAlarm.AlarmSentrctTarget;
                parametros = cmd.Parameters.Add("@AlarmSentTargetSpeed", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentTargetSpeed;
                parametros = cmd.Parameters.Add("@AlarmSentTargetDirection", SqlDbType.VarChar);
                parametros.Value = ObjAlarm.AlarmSentTargetDirection;
                parametros = cmd.Parameters.Add("@AlarmSentDescription", SqlDbType.VarChar);
                parametros.Value = ObjAlarm.AlarmSentDescription;
                parametros = cmd.Parameters.Add("@AlarmSentEstado", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentEstado;
                parametros = cmd.Parameters.Add("@CustomerCompanyID", SqlDbType.Int);
                parametros.Value = ObjAlarm.AlarmSentCustCompanyID;

                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    esExito = true;
                }

                con.Close();
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/IngrDataCameraToNextivaSQLDAL");
            
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + ex.Message, 1, 1, "DataNextivaDAL/IngrDataCameraToNextivaSQLDAL");
                esExito = false;
            }
            return esExito;
        }

        public DataSet GetAllDataProcessedNextivaDAL()
        {

            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_select_DataNextiva", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
            return null;


        }

        public DataSet SearchDataNextivaByID_DAL(string IDECamera)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                ////cmd.Connection = new SqlConnection("Data Source=MOVTOSHIPAPA\\SQLSERVER2005;Initial Catalog=DB_DAWPECEI;User Id=sa;Password=lcdp");
                ////temporal conexion , se quita despues
                //string StrConn = "Data Source=MOVTOSHIPAPA\\SQLSERVER2005;Initial Catalog=DB_DAWPECEI;User Id=sa;Password=lcdp";

                //cmd.Connection = new SqlConnection(StrConn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "SWG_select_DataNextiva_by_ID";

                //cmd.Parameters.Add("@IDECamera", SqlDbType.VarChar, 15).Value = IDECamera;

                //cmd.Connection.Open();
                //cmd.ExecuteNonQuery();
                //sda.Fill(ds);
                //cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
            }
            return ds;
        }

        private int VerifyVCAAlarmasRules(int codigo)
        {
            int presentEvent = 0;
            int caseSwitch = codigo;
            switch (caseSwitch)
            {
                case 6:
                    presentEvent = 1;
                    break;
                case 7:
                    presentEvent = 1;
                    break;
                case 8:
                    presentEvent = 2;
                    break;
                case 12:
                    presentEvent = 3;
                    break;
                case 13:
                    presentEvent = 1;
                    break;
                case 14:
                    presentEvent = 2;
                    break;
                case 15:
                    presentEvent = 3;
                    break;
                case 16:
                    presentEvent = 1;
                    break;
                default:
                    presentEvent = 1;
                    break;
            }


            return presentEvent;
        }

    }
}
