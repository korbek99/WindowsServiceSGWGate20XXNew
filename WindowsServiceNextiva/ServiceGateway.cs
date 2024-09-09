using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
//using WindowsServiceNextiva.ServiceReference1;
using NetClient;
using System.IO;
using System.Security.Permissions;
using System.Xml.Linq;
using System.Xml;
using WindowsServiceNextiva.Entities;
using WindowsServiceNextiva.Log;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WindowsServiceNextiva.Transac;
using System.Timers;
using WindowsServiceNextiva.ServiceReference1;

namespace WindowsServiceNextiva
{
    public partial class ServiceGateway : ServiceBase
    {
        public const int MAX_RECURSIVE_CALLS = 1;
        static int ctr = 0;
        //public Service1SoapClient ObjSoap = new Service1SoapClient();
        public ServiceGateParameters ObjParams = new ServiceGateParameters();
        public List<Device> Lista = new List<Device>();
        public List<AlarmNextiva> ListNextiva = new List<AlarmNextiva>();
        
        public int companyIDTemp = 0;
        public Logger ObjLog = new Logger();
        //public string[] ArrayDevices;
        public int Param_CustomerCompanyID;
        public int int_LogonID = 0;
        public int LogonSystem = 0;
        public string IPCustomer = "";
        public int int_AlarmInfIDE = 0;
        public int int_AlarmInfChannel = 0;
        public int int_AlarmInfState = 0;
        public int int_AlarmInfEventType = 0;
        public int int_AlarmInfRuleID = 0;
        public string str_AlarmInfRuleDescrip = "";
        public int int_AlarmInTargetID = 0;
        public int int_AlarmInfTargetType = 0;
        public string str_AlarmInfrctTarget = "";
        public int int_AlarmInfTargetSpeed = 0;
        public int int_AlarmInfTargetDirection = 0;
        public int param_customercompanyID;
        public string param_customercompanyIDE;
        public string str_CustomerIDE;

        public string str_msgEmptyField = "";
        public string str_AlarmInfIDE_msg = "";
        public string str_AlarmInfChannel_msg = "";
        public string str_AlarmInfState_msg = "";
        public string str_AlarmInfEventType_msg = "";
        public string str_AlarmInfRuleID_msg = "";
        public string str_AlarmInTargetID_msg = "";
        public string str_AlarmInfTargetType_msg = "";
        public string str_AlarmInfrctTarget_msg = "";
        public string str_AlarmInfTargetSpeed_msg = "";
        public string str_AlarmInfTargetDirection_msg = "";
        public Boolean b_IniAplication;

        private const int T_AUDIO8 = 0;
        private const int T_YUV420 = 1;
        private const int T_YUV422 = 2;

        private RECVDATA_NOTIFY RecvDataNotify = null;
        private COMRECV_NOTIFY ComRecvNotify = null;
        private DECYUV_NOTIFY DecYuvNotify = null;

        private static MAIN_NOTIFY_V4 MainNotify_V40 = null;

        private static ALARM_NOTIFY_V4 AlarmNotify_V40 = null;

        //private static FileStream fsSdv = null;
        //private static FileStream fsYuv = null;
        //private static FileStream fsPcm = null;

        private const int FTP_CMD_SET_SNAPSHOT = 0;
        private const int FTP_CMD_GET_SNAPSHOT = 4;

        private string strContinuousSnapPath;
        private int m_iSnapCount = 0;
        private System.Timers.Timer tTimer;

        public String hourMinute;
        public String hourMinuteAux;
        public int int_filaMatrix = 0;
        public string[][] AlarmsArray = new string[20][];

        public string cDeviceType;
        public string cComFormat;
        public string str_VCARules;

        VideoWindow[] m_video;
        CONNECT_STATE[] m_conState;
        CLIENTINFO m_cltInfo;
        NVS_FILE_LPBUF m_lpbuf;
        VCA_TAlarmInfo m_lpbuf3;
        PNVS_LOG_QUERY m_logquery;

      //  PNVS_NFS_DEV m_storeDev;
        //PNVS_NFS_DEV_NEW m_storeDev2;

        int m_iCurrentFrame = 0;
        const int CONST_iFrameNum = 16;
        int m_iDBClick = 0;
        bool m_blNSClick = false;

        //private System.ComponentModel.IContainer components;
        private System.Diagnostics.EventLog eventLog1;
        //public string strProxy = "";
        //public string strIP = "192.168.10.225";
        //public string strUser = "admin";
        //public string strPwd = "1111";
        //public string strProxyID = "";
        //public int iPort = 3000;

        public string strProxy = "";
        public string strIP = "";
        public string strUser = "";
        public string strPwd = "";
        public string strProxyID = "";
        public int iPort = 0;

        public int CustomerID;

        public string[] ArrayDataCustomers = new string[10];
        public string[][] ArrayDevices = new string[500][];
        public string tempo_CustomerIDE;
        public List<Customer> ListCostumers = new List<Customer>();
        public List<Device> ListDevice = new List<Device>();

        public List<AlarmInfomation> ListStoreAlarms = new List<AlarmInfomation>();

       public System.Timers.Timer tm = new System.Timers.Timer();

        public ServiceGateway()
	    {
           
            ObjLog.createFile();
           // InitializeTimer();
            InitializeComponent();
            m_cltInfo.m_iServerID = -1;
            readXMLFile();
            // CopyDllsFilesToClient();
            // StartUp();
           // InitializeTimer();
            
        }

        private Boolean readXMLFile()
        {
            Boolean esExito = false;
            Boolean existData = false;
           
            try
            {
                string rutaxml = ObjParams.ServiceGateParamPath; // @"C:\XML\xmlconfig.xml";
                 XmlTextReader reader = new XmlTextReader(rutaxml);
                while (reader.Read()) 
                {
                    switch (reader.NodeType) 
                    {
                        case XmlNodeType.Element: // The node is an element.
                            Console.Write("<" + reader.Name);
                            Console.WriteLine(">");

                            if (string.Equals(reader.Name, "CustomerCompanyIDE"))
                            {
                                existData = true;
                            }
                            break;
                        case XmlNodeType.Text: //Display the text in each element.
                            Console.WriteLine (reader.Value);

                            if (existData == true)
                            {
                                param_customercompanyIDE = reader.Value.Replace("'", "");
                                existData = false;
                            }
                            break;
                        case XmlNodeType.EndElement: //Display the end of the element.
                            Console.Write("</" + reader.Name);
                            Console.WriteLine(">");
                            break;
                    }
                }


                ObjLog.LoggerWritter("reading XML");

                if (!String.IsNullOrEmpty(param_customercompanyIDE))
                { 
                     //Llenar listas con datos
                    DataSet dsCustomers = new DataSet();
                    DataSet dsDevice = new DataSet();
                    Service1SoapClient ObjSoap = new Service1SoapClient();
                  
                    dsCustomers = ObjSoap.ServiceCustomerCompanyByIDE(param_customercompanyIDE);
                    //dsCustomers = ObjSoap.ServiceCustomerCompanyAllByCustomer();
                    string tempo_CustomerIDE = param_customercompanyIDE.Replace(".", "");

                    if (dsCustomers.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dsCustomers.Tables[0].Rows)
                        {
                            Param_CustomerCompanyID = Convert.ToInt32(dataRow[0].ToString());
                            ObjLog.LoggerWritter("Param_CustomerCompanyID :" + Param_CustomerCompanyID);
                        } 
                    }

                    dsDevice = ObjSoap.ServiceAllDeviceByCompanyID(Param_CustomerCompanyID);

                    if (dsDevice.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dsDevice.Tables[0].Rows)
                        {
                            //ObjLog.LoggerWritter(" Read Device  :" + Convert.ToString(dataRow["IDE"].ToString()));
                            ListDevice.Add(new Device()
                                {
                                    DeviceID = Convert.ToInt32(dataRow["ID"].ToString()),
                                    DeviceIDE = Convert.ToString(dataRow["IDE"].ToString()),
                                    DeviceNameDescrip = dataRow["Name"].ToString(),
                                    TypeDeviceID = Convert.ToInt32(dataRow["TypeDeviceID"].ToString()),
                                    CustomerCompanyID = Convert.ToInt32(dataRow["CompanyID"].ToString()),
                                    DeviceChannel = Convert.ToInt32(dataRow["Channel"].ToString()),
                                    DeviceIDLogon = dataRow["Logon"].ToString(),
                                    DeviceIP = dataRow["IP"].ToString(),
                                    DeviceUser = dataRow["Users"].ToString(),
                                    DevicePass = dataRow["Pass"].ToString(),
                                    DevicePort = dataRow["Port"].ToString(),
                                    //DeviceDateIng = Convert.ToDateTime(dataRow["DeviceDateIng"].ToString()),
                                    DeviceEstado = Convert.ToInt32(dataRow["DeviceEstado"].ToString())
                                 //   SystemDeviceID = Convert.ToInt32(dataRow["SystemDeviceID"].ToString()),
                                    //TypeDeviceDescrip = dataRow["TypeDeviceDescrip"].ToString(),
                                    //SystemDeviceDescrip = dataRow["SystemDeviceDescrip"].ToString(),
                                    //CustomerCompanyDescrip = dataRow["CustomerCompanyDescrip"].ToString()
                                });
                        }
                    }
                    //Load parameters
                    ObjLog.LoggerWritter("Load parameters XML");
                }

            }catch (Exception ex){
                ObjLog.LoggerWritter("Load parameters Error :" + ex);
                WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "ERROR reading XML Data  : " + ex.ToString(), 1, 1, "WindowsServiceNextiva/readXMLFile");
            }
            return esExito;
        }
        public void OnDebug()
        {
            OnStart(null);
        }
        private void StartUpInicial()
        {
            string ParamIP;

            foreach (Device element in ListDevice)
            {
                ParamIP = element.DeviceIP; // "192.168.10.225";
                // establecer el puerto de red por defecto utilizado por el cliente y el maestro 
                NVSSDK.NetClient_SetPort(Convert.ToInt32(element.DevicePort), 6000);
                //establecer el identificador de notificación de mensajes
                NVSSDK.NetClient_SetMSGHandle(SDKConstMsg.WM_MAIN_MESSAGE, this.Handle, SDKConstMsg.MSG_PARACHG, SDKConstMsg.MSG_ALARM);
                //inicia SDK
                NVSSDK.NetClient_Startup();
                //Inicializar la biblioteca NSLook
                NVSSDK.NSLook_Startup();

                // Establece la entrega  de llamada de aterrizaje
                MainNotify_V40 = MyMAIN_NOTIFY_V4;
                AlarmNotify_V40 = MyAlarm_NOTIFY_V4;
                NVSSDK.NetClient_SetNotifyFunction_V4(MainNotify_V40, AlarmNotify_V40, null, null, null);

                m_conState = new CONNECT_STATE[16];
                m_video = new VideoWindow[16];
                for (int i = 0; i < 16; i++)
                {
                    m_conState[i].m_iChannelNO = -1;
                    m_conState[i].m_iLogonID = -1;
                    m_conState[i].m_uiConID = UInt32.MaxValue;
                    m_video[i] = new VideoWindow();
                    //  m_video[i].Hide();
                    m_video[i].pnlVideo.TabIndex = i;
                    //m_video[i].pnlVideo.Click += new EventHandler(Video_Click);
                    //m_video[i].pnlVideo.DoubleClick += new EventHandler(Video_DBClick);
                }

                strProxy = "";
                strIP = element.DeviceIP;
                strUser = element.DeviceUser;
                strPwd = element.DevicePass;
                CustomerID = element.CustomerCompanyID;
                strProxyID = "";
                iPort = Convert.ToInt32(element.DevicePort);
                IPCustomer =  element.DeviceIP;
                companyIDTemp  = element.CustomerCompanyID;
                 LogonAuto();

                //int iRet;
                //try
                //{
                //    iRet = NVSSDK.NetClient_Logon(strProxy, strIP, strUser, strPwd, strProxyID, iPort);
                //    if (iRet < 0)
                //    {
                //        m_cltInfo.m_iServerID = -1;
                //        WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "Error : Logon failed!", 1, 1, "WindowsServiceNextiva/LogonAuto");
                //        return;
                //    }
                //    m_cltInfo.m_iServerID = iRet;
                //    m_cltInfo.m_cRemoteIP = strIP;
                //}
                //catch (Exception ex)
                //{
                //    WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "Error : " + ex.ToString(), 1, 1, "WindowsServiceNextiva/LogonAuto");
                //}

                ConnectAuto();
                PlayAuto();


            }
           // InitializeTimer();
        }
        private void StartUp()
        {
           string ParamIP;
              
            try
            {

              //  ParamIP = "192.168.10.225";
                hourMinute = DateTime.Now.ToString("HH:mm");
                int_filaMatrix = 1;

                // establecer el puerto de red por defecto utilizado por el cliente y el maestro 
                NVSSDK.NetClient_SetPort(3000, 6000);
                //establecer el identificador de notificación de mensajes
                NVSSDK.NetClient_SetMSGHandle(SDKConstMsg.WM_MAIN_MESSAGE, this.Handle, SDKConstMsg.MSG_PARACHG, SDKConstMsg.MSG_ALARM);
                //inicia SDK
                NVSSDK.NetClient_Startup();
                //Inicializar la biblioteca NSLook
                NVSSDK.NSLook_Startup();

                // Establece la entrega  de llamada de aterrizaje
                MainNotify_V40 = new MAIN_NOTIFY_V4(MyMAIN_NOTIFY_V4);
                AlarmNotify_V40 = new ALARM_NOTIFY_V4(MyAlarm_NOTIFY_V4);
                //GC.KeepAlive(MainNotify_V40);
                //GC.KeepAlive(AlarmNotify_V40);

                NVSSDK.NetClient_SetNotifyFunction_V4(MainNotify_V40, AlarmNotify_V40, null, null, null);

                m_conState = new CONNECT_STATE[16];
                m_video = new VideoWindow[16];

                for (int i = 0; i < 16; i++)
                {
                    m_conState[i].m_iChannelNO = -1;
                    m_conState[i].m_iLogonID = -1;
                    m_conState[i].m_uiConID = UInt32.MaxValue;
                    m_video[i] = new VideoWindow();
                    //  m_video[i].Hide();
                    m_video[i].pnlVideo.TabIndex = i;
                    //m_video[i].pnlVideo.Click += new EventHandler(Video_Click);
                    //m_video[i].pnlVideo.DoubleClick += new EventHandler(Video_DBClick);
                }
                //this.Controls.AddRange(m_video);
                //cboChannel.SelectedIndex = 1;
                //cboMode.SelectedIndex = 1;
                //cboScreen.SelectedIndex = 1;
                //cboStream.SelectedIndex = 1;
                //DisplayWindows(2);
                //btnDSMLogon.Tag = -1;


               
               
            }
            catch (Exception ex)
            {
                //ObjLog.LoggerWritter(" Read Device  :" + Convert.ToString(dataRow["IDE"].ToString()));
                WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "Error : " + ex.ToString(), 1, 1, "WindowsServiceNextiva/StartUp");
            }
        }

        private void MyMAIN_NOTIFY_V4(UInt32 _ulLogonID, IntPtr _iWparam, IntPtr _iLParam, Int32 _iUser)
        {
            ObjLog.LoggerWritter("Load MyMAIN_NOTIFY_V4");
            switch (_iWparam.ToInt32())
            {
                case SDKConstMsg.WCM_LOGON_NOTIFY:
                    {
                        m_conState[m_iCurrentFrame].m_iLogonID = (int)_ulLogonID;
                        switch (_iLParam.ToInt32())
                        {
                            case SDKConstMsg.LOGON_SUCCESS:
                                //MessageBox.Show("LOGON_SUCCESS notify_v4");
                                break;
                            case SDKConstMsg.LOGON_TIMEOUT:
                                // MessageBox.Show("LOGON_TIMEOUT notify_v4");
                                WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "Error : LOGON_TIMEOUT notify_v4", 1, 1, "WindowsServiceNextiva/MyMAIN_NOTIFY_V4");
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        // Aca se reciven los eventos de alarmas
        private void MyAlarm_NOTIFY_V4(Int32 _ulLogonID, Int32 _iChan, Int32 _iAlarmState, Int32 _iAlarmType, Int32 _iUser)
        {

             StringBuilder sbAlarmMsg = new StringBuilder("AlarmMsg-", 128);
            sbAlarmMsg.Append(DateTime.Now.ToLocalTime().ToString());

            switch (_iAlarmType)
            {
                case AlarmConstMsgType.ALARM_VDO_MOTION:
                    sbAlarmMsg.Append("- MOTION");
                    break;
                case AlarmConstMsgType.ALARM_VDO_REC:
                    sbAlarmMsg.Append("- REC");
                    break;
                case AlarmConstMsgType.ALARM_VDO_LOST:
                    sbAlarmMsg.Append("- LOST");
                    break;
                case AlarmConstMsgType.ALARM_VDO_INPORT:
                    sbAlarmMsg.Append("- INPORT");
                    break;
                case AlarmConstMsgType.ALARM_VDO_OUTPORT:
                    sbAlarmMsg.Append("- OUTPORT");
                    break;
                case AlarmConstMsgType.ALARM_VDO_COVER:
                    sbAlarmMsg.Append("- COVER");
                    break;
                case AlarmConstMsgType.ALARM_VCA_INFO:
                    sbAlarmMsg.Append("- VCA");

                    {
                        VCA_TAlarmInfo info = new VCA_TAlarmInfo();
                        Int32 iRet = NVSSDK.NetClient_VCAGetAlarmInfo(_ulLogonID, _iAlarmState, ref info, Marshal.SizeOf(info));
                        sbAlarmMsg.Append("- VCA");
                        sbAlarmMsg.Append(" RuleID: " + info.iRuleID);
                        Int32 iVCAAlarmState = info.iState;
                        switch (iVCAAlarmState)
                        {
                            case 0:
                                sbAlarmMsg.Append("- OFF");
                                break;
                            case 1:
                                sbAlarmMsg.Append("- ON");
                                break;
                            default:
                                sbAlarmMsg.Append("-" + iVCAAlarmState.ToString());
                                break;
                        }

                        // Console.WriteLine("Loading received alerts : " + m_lpbuf.m_iRuleID, "MyAlarm_NOTIFY_V4" + " " + DateTime.Today.ToString());
                        //  ObjLog.LoggerWritter("Loading received alerts : " + m_lpbuf.m_iRuleID + "  MyAlarm_NOTIFY_V4" + " " + DateTime.Today.ToString());
                        string AlarmSentIDE = "";
                        string AlarmSentrctTarget = "";
                        string needle = _ulLogonID.ToString();
                         // ObjLog.LoggerWritter("Seaching Logon Devices : " + needle.ToString());
                        foreach (Device foo in Lista)
                        {
                            if (foo.DeviceIDLogon == needle)
                            {
                                AlarmSentIDE = foo.DeviceIP;
                                //  ObjLog.LoggerWritter("Get IP Devices of Alarm : " + AlarmSentIDE.ToString());
                            }
                        }

                       ListNextiva.Add(new AlarmNextiva()
                        {
                               AlarmNexSentChannel = m_lpbuf.m_iChannel,
                               AlarmNexSentCustCompanyID = CustomerID,
                               AlarmNexSentDateIng = Convert.ToString(DateTime.Today),
                               AlarmNexSentDescription = sbAlarmMsg.ToString(),
                               AlarmNexSentEstado  = _iAlarmState,
                               AlarmNexSentIDE = AlarmSentIDE,
                               AlarmNexSentrctTarget = AlarmSentrctTarget,
                               AlarmNexSentRuleDescrip = sbAlarmMsg.ToString(),
                               AlarmNexSentRuleID= m_lpbuf.m_iRuleID,
                               AlarmNexSentState = _iAlarmState,
                               AlarmNexSentTargetDirection = 0,
                               AlarmNexSentTargetID = 0,
                               AlarmNexSentTargetSpeed   = 0,
                               AlarmNexSentTargetType  = _iAlarmType,
                               AlarmNexSentventType = _iAlarmType,
                               AlarmNexSentStateTransac = 0
                        });

                          // ObjLog.LoggerWritter("Sending received alerts (SendAlarmsToNextivaSWG) to WebService Server from Device : " + AlarmSentIDE);
                    }
                    break;
                default:
                    sbAlarmMsg.Append("-" + _iAlarmType.ToString());
                    break;
            }
            // int estado_Alarma = 0;
            //switch (_iAlarmState)
            //{
            //    case 0:
            //        sbAlarmMsg.Append("- OFF");
            //        break;
            //    case 1:
            //        sbAlarmMsg.Append("- ON");
            //        //estado_Alarma = 1;
            //        break;
            //    default:
            //        sbAlarmMsg.Append("-" + _iAlarmState.ToString());
            //        break;
            //}
            // lbAlarmlistBox.Items.Insert(0, sbAlarmMsg.ToString());
            // ObjLog.LoggerWritter("Load MyAlarm_NOTIFY_V4");

          // ObjLog.LoggerWritter(sbAlarmMsg  + DateTime.Today.ToString());
        }

        public string GetiAlarmType(int _iAlarmType)
        {
            string retorno = "";
            VCARules ObjVca = new VCARules();

            int caseSwitch = _iAlarmType;

            if (ObjVca.VCA_CMD_SET_CHANNEL_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_CHANNEL_DESC;
            }

            if (ObjVca.VCA_CMD_SET_VIDEOSIZE_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_VIDEOSIZE_DESC;
            }

            if (ObjVca.VCA_CMD_SET_ADVANCE_PARAM_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_ADVANCE_PARAM_DESC;
            }

            if (ObjVca.VCA_CMD_SET_TARGET_PARAM_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_TARGET_PARAM_DESC;
            }

            if (ObjVca.VCA_CMD_SET_ALARM_STATISTIC_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_ALARM_STATISTIC_DESC;
            }

            if (ObjVca.VCA_CMD_SET_RULE_COMMON_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_RULE_COMMON_DESC;
            }

            if (ObjVca.VCA_CMD_SET_RULE0_TRIPWIRE_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_RULE0_TRIPWIRE_DESC;
            }

            if (ObjVca.VCA_CMD_SET_RULE1_DBTRIPWIRE_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_RULE1_DBTRIPWIRE_DESC;
            }

            if (ObjVca.VCA_CMD_SET_RULE2_PERIMETER_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_RULE2_PERIMETER_DESC;
            }

            if (ObjVca.VCA_CMD_SET_ALARM_SCHEDULE_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_ALARM_SCHEDULE_DESC;
            }

            if (ObjVca.VCA_CMD_SET_ALARM_LINK_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_ALARM_LINK_DESC;
            }

            if (ObjVca.VCA_CMD_SET_SCHEDULE_ENABLE_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_SCHEDULE_ENABLE_DESC;
            }

            if (ObjVca.VCA_CMD_SET_RULE9_FACEREC_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_RULE9_FACEREC_DESC;
            }

            if (ObjVca.VCA_CMD_SET_RULE10_VIDEODETECT_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_RULE10_VIDEODETECT_DESC;
            }

            if (ObjVca.VCA_CMD_SET_RULE8_ABANDUM_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_RULE8_ABANDUM_DESC;

            }

            if (ObjVca.VCA_CMD_SET_RULE7_OBJSTOLEN_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_RULE7_OBJSTOLEN_DESC;
            }

            if (ObjVca.VCA_CMD_SET_RULE11_TRACK_ID == caseSwitch)
            {
                retorno = ObjVca.VCA_CMD_SET_RULE11_TRACK_DESC;
            }

            return retorno;
        }

        public string ByteToString(byte[] bytes)
        {
            string response = string.Empty;

            foreach (byte b in bytes)
                response += (Char)b;

            return response;
        }
        private void InitializeTimer()
        {
            // Call this procedure when the application starts.
            // Set to 1 second.
            //try
            //{
            // this.timer1 = new System.Timers.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Enabled = true;
            //}
            //catch (Exception ex)
            //{ 
            
            //}

            // label1.Text = _counter.ToString();
            // Enable timer.
            //Button1.Text = "Stop";
            //Button1.Click += new EventHandler(Button1_Click);
        }
       
        private void Timer1_Tick(object Sender, EventArgs e)
        {
            if (ListNextiva.Count > 0)
            {
                foreach (var items in ListNextiva)
                {
                    SendAlarmsToNextivaSWGService(items.AlarmNexSentChannel,
                                                  items.AlarmNexSentCustCompanyID,
                                                  items.AlarmNexSentDateIng,
                                                  items.AlarmNexSentDescription ,
                                                  items.AlarmNexSentEstado ,
                                                  items.AlarmNexSentIDE,
                                                  items.AlarmNexSentrctTarget,
                                                  items.AlarmNexSentRuleDescrip,
                                                  items.AlarmNexSentRuleID,
                                                  items.AlarmNexSentState,
                                                  items.AlarmNexSentTargetDirection,
                                                  items.AlarmNexSentTargetID,
                                                  items.AlarmNexSentTargetSpeed,
                                                  items.AlarmNexSentTargetType,
                                                  items.AlarmNexSentventType);
                }
                ListNextiva.Clear();
            }
        }

        public void ListStoreAlarmas(AlarmInfomation objeto)
        {
            int int_canti_trips = 0;
            //if (objeto.AlarmInTargetID == 0)
            //{
            try
            {
                ListStoreAlarms.Add(new AlarmInfomation()
                {
                    AlarmInfChannel = objeto.AlarmInfChannel,// m_lpbuf.m_iChannel;
                    AlarmInfEventType = objeto.AlarmInfEventType,//_iAlarmType,
                    AlarmInfID = int_canti_trips++, //cantidadtrips++, // m_lpbuf.m_iID;
                    AlarmInfIDE = objeto.AlarmInfIDE,//cantidadtrips++,
                    AlarmInfrctTarget = "",
                    AlarmInfRuleID = objeto.AlarmInfRuleID, //AlarmConstMsgType.ALARM_VCA_INFO; // VCAConfiguration.VCA_RULE0_TRIPWIRE; //m_lpbuf.m_iRuleID; 
                    AlarmInfRuleDescrip = objeto.AlarmInfRuleDescrip,
                    AlarmInfState = objeto.AlarmInfState,
                    AlarmInfTargetDirection = 0,
                    AlarmInfTargetSpeed = 0,
                    AlarmInfTargetType = objeto.AlarmInfEventType,
                    AlarmInTargetID = Convert.ToInt32(objeto.AlarmInfState),
                    AlarmInfDescription = str_VCARules.ToString(),// sbAlarmMsg.ToString();
                    AlarmInfCostuCompany = objeto.AlarmInfCostuCompany,
                    AlarmInfDateEvent = objeto.AlarmInfDateEvent

                      
                });
            }
            catch (Exception ex)
            { 
            
            
            }
                
           // }
        }
        public static void SendAlarmsToNextivaSWGService(int AlarmSentChannel,
                                                int AlarmSentCustCompanyID,
                                                string AlarmSentDateIng,
                                                string AlarmSentDescription,
                                                int AlarmSentEstado,
                                                string AlarmSentIDE,
                                                string AlarmSentrctTarget,
                                                string AlarmSentRuleDescrip,
                                                int AlarmSentRuleID,
                                                int AlarmSentState,
                                                int AlarmSentTargetDirection,
                                                int AlarmSentTargetID,
                                                int AlarmSentTargetSpeed,
                                                int AlarmSentTargetType,
                                                int AlarmSentventType)
        {

            Boolean esExito = false;
            //Logger ObjLog1 = new Logger();
            Service1SoapClient ObjSoap = new Service1SoapClient();
            try
            {
                esExito = ObjSoap.ServiceSendDataCameraToNextiva(AlarmSentChannel,
                                                      AlarmSentCustCompanyID,
                                                     AlarmSentDateIng,
                                                     AlarmSentDescription,
                                                     AlarmSentEstado,
                                                     AlarmSentIDE,
                                                     AlarmSentrctTarget,
                                                     AlarmSentRuleDescrip,
                                                     AlarmSentRuleID,
                                                     AlarmSentState,
                                                     AlarmSentTargetDirection,
                                                     AlarmSentTargetID,
                                                     AlarmSentTargetSpeed,
                                                     AlarmSentTargetType,
                                                     AlarmSentventType);
                ObjSoap.Close();
                // retorna un true o false de la transaccion WebService
                if (esExito == false)
                {
                   // ObjLog1.LoggerWritter("Excepcion WindowsServiceNextiva/SendAlarmsToNextivaSWG Error :  Data was not sent to nextiva " + DateTime.Today.ToString());
                    Console.WriteLine("Excepcion WindowsServiceNextiva/SendAlarmsToNextivaSWG : {0}", "Error :  Data was not sent to nextiva " + DateTime.Today.ToString());
                    // WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "Error :  Data was not sent to nextiva ", 1, 1, "WindowsServiceNextiva/SendAlarmsToNextivaSWG");
                }
                else
                {
                    Console.WriteLine("Alarm event was successfully sent to Nextiva : {0}", "Alarm event was sent" + DateTime.Today.ToString());
                   // ObjLog1.LoggerWritter("Alarm event was successfully sent to Nextiva WebService " + DateTime.Today.ToString());
                }
            }
            catch (Exception ex)
            {
                esExito = false;
                Console.WriteLine("Excepcion WindowsServiceNextiva/SendAlarmsToNextivaSWG : {0}", "Error : " + ex.ToString() + " " + DateTime.Today.ToString());
                // WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "Error : " + ex.ToString(), 1, 1, "WindowsServiceNextiva/SendAlarmsToNextivaSWG");
            }
            //  return esExito;
        }
        protected override void OnStart(string[] args)
	    {
		    //eventLog1.WriteEntry("In OnStart");
            DataSet dsCustomers = new DataSet();
            CreateFileClient();
            dsCustomers = GetDataClient(Param_CustomerCompanyID);
            //LogonAuto();
            //ConnectAuto();
            //PlayAuto();

            System.Timers.Timer T1 = new System.Timers.Timer();
            T1.Interval = (1000);
            T1.AutoReset = true;
            T1.Enabled = true;
            T1.Start();
            T1.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Tick);

            StartUpInicial();
	    }
        private void ConnectAuto()
        {
            m_cltInfo.m_iChannelNo = 1; // cboChannel.SelectedIndex;
            m_cltInfo.m_iNetMode = 1; //cboMode.SelectedIndex + 1;
            m_cltInfo.m_iStreamNO = 1; //cboStream.SelectedIndex;

            m_cltInfo.m_cNetFile = new char[255];
            m_cltInfo.m_cRemoteIP = new char[16];
            Array.Copy(strIP.ToCharArray(), m_cltInfo.m_cRemoteIP, strIP.Length);
            UInt32 uiConID = m_conState[m_iCurrentFrame].m_uiConID;

            //获得当前窗口对应的视频播放状态
            int iRet = NVSSDK.NetClient_GetPlayingStatus(uiConID);

            //如果正在播放视频，不进行连接操作
            if (iRet != SDKConstMsg.PLAYER_PLAYING)
            {
                int iChannelNum = 0;

                //获得当前窗口连接的网络视频服务器最大通道数
                NVSSDK.NetClient_GetChannelNum(m_cltInfo.m_iServerID, ref iChannelNum);

                //判断是否超过最大通道号
                if (m_cltInfo.m_iChannelNo >= iChannelNum)
                {
                     //  MessageBox.Show("Max Channel is " + iChannelNum);
                     // ACA Channel
                     // cboChannel.SelectedIndex = iChannelNum - 1;
                    return;
                }
                //开始接收一路视频数据	
                iRet = NVSSDK.NetClient_StartRecv(ref uiConID, ref m_cltInfo, null);

                //操作失败，清除结构体m_conState的信息
                if (iRet < 0)
                {
                    m_conState[m_iCurrentFrame].m_iLogonID = -1;
                    m_conState[m_iCurrentFrame].m_uiConID = UInt32.MaxValue;
                    m_conState[m_iCurrentFrame].m_iChannelNO = -1;
                    //MessageBox.Show("Connect failed !");
                    return;
                }
                //操作成功，更新结构体m_conState的信息
                m_conState[m_iCurrentFrame].m_iLogonID = m_cltInfo.m_iServerID;
                m_conState[m_iCurrentFrame].m_iChannelNO = m_cltInfo.m_iChannelNo;
                m_conState[m_iCurrentFrame].m_uiConID = uiConID;
                m_conState[m_iCurrentFrame].m_iStreamNO = m_cltInfo.m_iStreamNO;

                //开始导出收到的数据
                NVSSDK.NetClient_StartCaptureData(uiConID);
                if (iRet == 1)
                {
                    RECT rect = new RECT();

                    //开始播放某路视频
                    NVSSDK.NetClient_StartPlay(uiConID, m_video[m_iCurrentFrame].pnlVideo.Handle, rect, 0);
                   // btnPlay.Text = "Stop";

                  //  GetWindowStates();
                }
               // btnConnect.Text = "Disconnect";
            }
        
        }

        private void PlayAuto()
        {
            //当前窗口没有连接，退出
            if (m_conState[m_iCurrentFrame].m_uiConID == UInt32.MaxValue)
            {
                return;
            }
            //string strCaption = btnPlay.Text;
            int iRet;
            //if (strCaption == "Play") //显示视频
            //{
                RECT rect = new RECT();

                //开始播放视频
                iRet = NVSSDK.NetClient_StartPlay
                (
                    m_conState[m_iCurrentFrame].m_uiConID,
                    m_video[m_iCurrentFrame].pnlVideo.Handle,
                    rect,
                    0
                );
                if (iRet == 0)
                {
                   // btnPlay.Text = "Stop";
                }
            //}
            //else //停止播放
            //{
            //    //停止接受视频数据
            //    iRet = NVSSDK.NetClient_StopCaptureData(m_conState[m_iCurrentFrame].m_uiConID);

            //    //停止播放某路视频
            //    iRet = NVSSDK.NetClient_StopPlay(m_conState[m_iCurrentFrame].m_uiConID);
            //    m_video[m_iCurrentFrame].Invalidate(true);
            //    btnPlay.Text = "Play";
            //}
        }

        private void LogonAuto()
        {
            int iRet;
            try
            {
                iRet = NVSSDK.NetClient_Logon(strProxy, strIP, strUser, strPwd, strProxyID, iPort);
                if (iRet < 0)
                {
                    m_cltInfo.m_iServerID = -1;
                    WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "Error : Logon failed!", 1, 1, "WindowsServiceNextiva/LogonAuto");
                    return;
                }

                m_cltInfo.m_iServerID = iRet;



                if (Lista.Count == 0)
                {
                    Lista.Add(new Device()
                    {
                        // DeviceID = 0,
                        DeviceIDE = strIP,
                        DeviceNameDescrip = "Camera :" + strIP,
                        TypeDeviceID = 0,
                        CustomerCompanyID = companyIDTemp,
                        DeviceChannel = 0,
                        DeviceIDLogon = iRet.ToString(),
                        DeviceIP = strIP,
                        DeviceUser = strUser,
                        DevicePass = strPwd,
                        DevicePort = iPort.ToString(),
                        DeviceDateIng = DateTime.Today,
                        DeviceEstado = 1,
                        SystemDeviceID = 0,
                        TypeDeviceDescrip = "",
                        SystemDeviceDescrip = ""
                    });

                }
                else
                {
                    Boolean existe = false;
                    string needle = strIP;
                    foreach (Device foo in Lista)
                    {
                        if (foo.DeviceIP == needle)
                        {
                            existe = true;
                        }
                    }

                    if (existe == false)
                    {
                        Lista.Add(new Device()
                        {
                            //  DeviceID = 0,
                            DeviceIDE = strIP,
                            DeviceNameDescrip = "Camera :" + strIP,
                            TypeDeviceID = 0,
                            CustomerCompanyID = 1,
                            DeviceChannel = 0,
                            DeviceIDLogon = iRet.ToString(),
                            DeviceIP = strIP,
                            DeviceUser = strUser,
                            DevicePass = strPwd,
                            DevicePort = iPort.ToString(),
                            DeviceDateIng = DateTime.Today,
                            DeviceEstado = 1,
                            SystemDeviceID = 0,
                            TypeDeviceDescrip = "",
                            SystemDeviceDescrip = ""
                        });
                        // MessageBox.Show("New device item added to list : " + DeviceIP);
                    }
                    else
                    {
                        // MessageBox.Show("There is already a record with Data : " + DeviceIP);
                    }
                }

            }
            catch (Exception ex)
            {
                WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "Error : " + ex.ToString(), 1, 1, "WindowsServiceNextiva/LogonAuto");
            }
        }
        protected override void OnStop()
	    {
		   // eventLog1.WriteEntry("In onStop.");
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStop File " + DateTime.Now.Date.ToString());
            WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "Error : Remote Windows Service ('" + Environment.MachineName + "') Stopped ", 1, 1, "WindowsServiceNextiva/OnStop");
	    }


        private void CreateFileClient()
        {
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "FileClientTest.txt");
        }
        private DataSet GetDataClient(int CompanyID)
        {
            DataSet ds = new DataSet();
            Service1SoapClient ObjSoap1 = new Service1SoapClient();

            try
            {
                ds = ObjSoap1.ServiceCustomerCompanyByCustomerID(CompanyID);
               // ds = ObjSoap1.ServiceCustomerCompanyByCustomerID(CompanyID);
                Console.WriteLine("Satisfactory WebService Conection : {0} ", "GetDataClient" + " " + DateTime.Today.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion WindowsServiceNextiva/GetDataClient : {0}", "Error : " + ex.ToString() + " " + DateTime.Today.ToString());
                WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "Error : " + ex.ToString(), 1, 1, "WindowsServiceNextiva/GetDataClient");
            }

            return ds;
        }
        private Boolean WebServiceConectionsSWG()
        {

            Boolean esExito = false;

            try
            {
                esExito = true;
            }
            catch (Exception ex)
            {

                esExito = false;
                WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "Error : WebService Conection failed", 1, 1, "WindowsServiceNextiva/WebServiceConectionsSWG");
            }
            return esExito;
        }

        private void WinServiceTrackingErrorSWG(DateTime Fecha,
                  string MachineName,
                  string UserName,
                  int IdSistema,
                  string Mensaje,
                  int Resuelto,
                  int NumeroError,
                  string Modulo)
        {
            Console.WriteLine("Sending bugs found : {0} ", "WinServiceTrackingErrorSWG" + " " + DateTime.Today.ToString());

            string ErrorGlobal = "MachineName :" + MachineName + " UserName :" + UserName + " IdSistema :" + IdSistema + " Mensaje :" + Mensaje + " Modulo :" + Modulo;
            ObjLog.LoggerWritter("Error bugs found WinServiceTrackingErrorSWG : " + ErrorGlobal);

           // Service1SoapClient ObjSoap = new Service1SoapClient();
          //  ObjSoap.ServiceTrackingErrorSWG(Fecha, MachineName, UserName, IdSistema, Mensaje, Resuelto, NumeroError, Modulo);

        }

        public IntPtr Handle { get; set; }
    }
}
