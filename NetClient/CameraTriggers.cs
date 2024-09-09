using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Business;

using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Entities;
using System.Data.SqlClient;

namespace NetClient
{
public class CameraTriggers
{
    public List<Cameras> listCameras = new List<Cameras>();
    public List<Cameras> listCamerasTriggers = new List<Cameras>();
    List<AlarmBoxTrigger> listatriggers = new List<AlarmBoxTrigger>();
    public Cameras ObjCamera = new Cameras();
    public string EstadoProceso="";
    public string str_IPGlobal = "";
    public int int_iChannelNo = 0;
    public int int_Mode = 0;
    public int int_iStreamNO = 0;

    public int int_LogonID = 0;
    public int LogonSystem = 0;

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

    private MAIN_NOTIFY_V4 MainNotify_V40 = null;

    private ALARM_NOTIFY_V4 AlarmNotify_V40 = null;

    private static FileStream fsSdv = null;
    private static FileStream fsYuv = null;
    private static FileStream fsPcm = null;

    private const int FTP_CMD_SET_SNAPSHOT = 0;
    private const int FTP_CMD_GET_SNAPSHOT = 4;

    private string strContinuousSnapPath;
    private int m_iSnapCount = 0;
    private System.Timers.Timer tTimer;

   
    VideoWindow[] m_video;


    CONNECT_STATE[] m_conState;

  
    CLIENTINFO m_cltInfo;

    NVS_FILE_LPBUF m_lpbuf;

    PNVS_LOG_QUERY m_logquery;

    int m_iCurrentFrame = 0;


    const int CONST_iFrameNum = 16;

    int m_iDBClick = 0;


    bool m_blNSClick = false;
        
    public  void inicializate()
    {
        StartUp();
        if (iniLogon() == true)
        {
            iniConnect();
            IniPlay();
            iniAllCameras();

        } else { 
        
        
        }
        
    }

    private void IniPlay()
    {
        //当前窗口没有连接，退出
        if (m_conState[m_iCurrentFrame].m_uiConID == UInt32.MaxValue)
        {
            return;
        }
       // string strCaption = btnPlay.Text;
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
    private void StartUp()
    {

        str_IPGlobal = "192.168.10.225";

        NVSSDK.NetClient_SetPort(3000, 6000);

        
        //NVSSDK.NetClient_SetMSGHandle(SDKConstMsg.WM_MAIN_MESSAGE, this.Handle, SDKConstMsg.MSG_PARACHG, SDKConstMsg.MSG_ALARM);

        
        NVSSDK.NetClient_Startup();

       
        NVSSDK.NSLook_Startup();

        
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
            m_video[i].Hide();
            m_video[i].pnlVideo.TabIndex = i;
            //m_video[i].pnlVideo.Click += new EventHandler(Video_Click);
            //m_video[i].pnlVideo.DoubleClick += new EventHandler(Video_DBClick);
        }
       
        //this.Controls.AddRange(m_video);
        //cboChannel.SelectedIndex = 0;
        //cboMode.SelectedIndex = 0;
        //cboScreen.SelectedIndex = 1;
        //cboStream.SelectedIndex = 0;

        
      //  DisplayWindows(2);

    
      //  btnDSMLogon.Tag = -1;
    
    }


    private void MyMAIN_NOTIFY_V4(UInt32 _ulLogonID, IntPtr _iWparam, IntPtr _iLParam, Int32 _iUser)
    {
        switch (_iWparam.ToInt32())
        {
            //登陆状态消息 
            //param1 登陆IP
            //param2 登陆ID
            //param3 登陆状态
            case SDKConstMsg.WCM_LOGON_NOTIFY:
                {
                    m_conState[m_iCurrentFrame].m_iLogonID = (int)_ulLogonID;
                    switch (_iLParam.ToInt32())
                    {
                        case SDKConstMsg.LOGON_SUCCESS:
                           // MessageBox.Show("LOGON_SUCCESS notify_v4");
                            break;
                        case SDKConstMsg.LOGON_TIMEOUT:
                           // MessageBox.Show("LOGON_TIMEOUT notify_v4");
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

    private void MyAlarm_NOTIFY_V4(Int32 _ulLogonID, Int32 _iChan, Int32 _iAlarmState, Int32 _iAlarmType, Int32 _iUser)
    {

        int cantidadtrips = 0;
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
                break;
            default:
                sbAlarmMsg.Append("-" + _iAlarmType.ToString());
                break;
        }

        int estado_Alarma = 0;
        switch (_iAlarmState)
        {
            case 0:
                sbAlarmMsg.Append("- OFF");
                break;
            case 1:

                sbAlarmMsg.Append("- ON");
                estado_Alarma = 1;
                break;
            default:
                sbAlarmMsg.Append("-" + _iAlarmState.ToString());
                break;
        }
        

      //  lbAlarmlistBox.Items.Insert(0, sbAlarmMsg.ToString());


        switch (_iAlarmType)
        {

            case AlarmConstMsgType.ALARM_VCA_INFO:
                sbAlarmMsg.Append("- VCA");
                // Get Channels camera
                int iChannelNumber = 0;
                int iretu = NVSSDK.NetClient_GetChannelNum(_ulLogonID, ref iChannelNumber);
                int channelCamera = iChannelNumber;
                //if (estado_Alarma == 1)
                //{
                AlarmInfomation objeto = new AlarmInfomation();

                objeto.AlarmInfChannel = channelCamera; // m_lpbuf.m_iChannel;
                objeto.AlarmInfEventType = _iAlarmType;
                objeto.AlarmInfID = cantidadtrips++; // m_lpbuf.m_iID;
                objeto.AlarmInfIDE = cantidadtrips++;
                objeto.AlarmInfrctTarget = "";
                objeto.AlarmInfRuleID = AlarmConstMsgType.ALARM_VCA_INFO; // VCAConfiguration.VCA_RULE0_TRIPWIRE; //m_lpbuf.m_iRuleID; 
                objeto.AlarmInfRuleDescrip = sbAlarmMsg.ToString();
                objeto.AlarmInfState = _iAlarmState;
                objeto.AlarmInfTargetDirection = 0;
                objeto.AlarmInfTargetSpeed = 0;
                objeto.AlarmInfTargetType = _iAlarmType;
                objeto.AlarmInTargetID = Convert.ToInt32(_iAlarmState.ToString());
                objeto.AlarmInfDescription = sbAlarmMsg.ToString();
                if (objeto.AlarmInTargetID > 0)
                {
                    if (SentNextivaAutomatico(objeto) == true)
                    {
                        sbAlarmMsg.Append(" - enviado a  Nextiva");
                    }
                    else
                    {
                       // lblMensaje.Text = "Ocurrio un error envio alarma";
                        sbAlarmMsg.Append(" - Error envio a Nextiva");
                        // MessageBox.Show("Ocurrio un error envio alarma");
                    }
                }
                  //sbAlarmMsg.Append(" - Ocurrio un error envio alarma");
                  //ListSentNextiva.Items.Insert(0, sbAlarmMsg.ToString());

                

                listatriggers.Add(new AlarmBoxTrigger()
                {
                    AlarmBoxTriggerIndex = 1,
                    AlarmBoxTriggerDescrip = sbAlarmMsg.ToString(),
                    AlarmBoxTriggerState = 1,
                });
                // }
                break;
            default:
                sbAlarmMsg.Append("-" + _iAlarmType.ToString());
                break;
        }


    }
    //public List<AlarmBoxTrigger> ListaTriggersCamera();
    //{
    //     List<AlarmBoxTrigger> lista = new List<AlarmBoxTrigger>();

    //     return lista ;
    //}

    private Boolean SentNextivaAutomatico(AlarmInfomation objeto)
    {
        Boolean exito = false;

        DataNextivaBF ObtData = new DataNextivaBF();

        List<AlarmNextiva> lista = new List<AlarmNextiva>();

        int int_AlarmIdeTempo = ObtData.GetLastIDBF(objeto.AlarmInfChannel);

        if (int_AlarmIdeTempo == 0)
        {
            int_AlarmIdeTempo = 1;
        }
        else
        {

            int_AlarmIdeTempo = int_AlarmIdeTempo + 1;
        }

        lista.Add(new AlarmNextiva()
        {


            AlarmSentIDE = int_AlarmIdeTempo, //objeto.AlarmInfIDE,
            AlarmSentChannel = objeto.AlarmInfChannel,
            AlarmSentState = objeto.AlarmInfState,
            AlarmSentventType = objeto.AlarmInfTargetType,
            AlarmSentRuleID = objeto.AlarmInfRuleID,
            AlarmSentRuleDescrip = VerifyVCAAlarms(6) + " - " + objeto.AlarmInfRuleDescrip,
            AlarmSentTargetID = objeto.AlarmInTargetID,
            AlarmSentTargetType = objeto.AlarmInfTargetType,
            AlarmSentrctTarget = "",
            AlarmSentTargetSpeed = objeto.AlarmInfTargetSpeed,
            AlarmSentTargetDirection = objeto.AlarmInfTargetDirection,
            AlarmSentDescription = objeto.AlarmInfDescription,
            AlarmSentEstado = 1
        });

        if (ObtData.SendDataCameraToNextivaBF(lista) == true)
        {
            exito = true;
        }
        else
        {
            exito = false;
        }
        return exito;

    }

    private string VerifyVCAAlarms(int codigo)
    {
        string str_textAlarm = "";
        int caseSwitch = codigo;

        switch (caseSwitch)
        {
            case 0:
                str_textAlarm = VCAConfiguration.VCA_CHANNEL_DESCRIP;
                break;
            case 1:
                str_textAlarm = VCAConfiguration.VCA_VIDEOSIZE_DESCRIP;
                break;
            case 2:
                str_textAlarm = VCAConfiguration.VCA_ADVANCE_PARAM_DESCRIP;
                break;
            case 3:
                str_textAlarm = VCAConfiguration.VCA_TARGET_PARAM_DESCRIP;
                break;
            case 4:
                str_textAlarm = VCAConfiguration.VCA_ALARM_STATISTIC_DESCRIP;
                break;
            case 5:
                str_textAlarm = VCAConfiguration.VCA_RULE_COMMON_DESCRIP;
                break;
            case 6:
                str_textAlarm = VCAConfiguration.VCA_RULE0_TRIPWIRE_DESCRIP;
                break;
            case 7:
                str_textAlarm = VCAConfiguration.VCA_RULE1_DBTRIPWIRE_DESCRIP;
                break;
            case 8:
                str_textAlarm = VCAConfiguration.VCA_RULE2_PERIMETER_DESCRIP;
                break;
            case 9:
                str_textAlarm = VCAConfiguration.VCA_ALARM_SCHEDULE_DESCRIP;
                break;
            case 10:
                str_textAlarm = VCAConfiguration.VCA_ALARM_LINK_DESCRIP;
                break;
            case 11:
                str_textAlarm = VCAConfiguration.VCA_SCHEDULE_ENABLE_DESCRIP;
                break;
            case 12:
                str_textAlarm = VCAConfiguration.VCA_RULE9_FACEREC_DESCRIP;
                break;
            case 13:
                str_textAlarm = VCAConfiguration.VCA_RULE10_VIDEODETECT_DESCRIP;
                break;
            case 14:
                str_textAlarm = VCAConfiguration.VCA_RULE8_ABANDUM_DESCRIP;
                break;
            case 15:
                str_textAlarm = VCAConfiguration.VCA_RULE7_OBJSTOLEN_DESCRIP;
                break;
            case 16:
                str_textAlarm = VCAConfiguration.VCA_RULE11_TRACK_DESCRIP;
                break;

        }

        return str_textAlarm;
    }
    private void iniConnect()
    {
         int_Mode = 1;
         int_iStreamNO = 0;
         int_iChannelNo = 1;

         m_cltInfo.m_iChannelNo = int_iChannelNo; //cboChannel.SelectedIndex;
        m_cltInfo.m_iNetMode = int_Mode + 1;
        m_cltInfo.m_iStreamNO = int_iStreamNO;

        m_cltInfo.m_cNetFile = new char[255];
        m_cltInfo.m_cRemoteIP = new char[16];
        Array.Copy(str_IPGlobal.ToCharArray(), m_cltInfo.m_cRemoteIP, str_IPGlobal.Length);

        UInt32 uiConID = m_conState[m_iCurrentFrame].m_uiConID;

        int iRet = NVSSDK.NetClient_GetPlayingStatus(uiConID);

        if (iRet != SDKConstMsg.PLAYER_PLAYING)
        {
            int iChannelNum = 0;


            NVSSDK.NetClient_GetChannelNum(m_cltInfo.m_iServerID, ref iChannelNum);

            if (m_cltInfo.m_iChannelNo >= iChannelNum)
            {
                // MessageBox.Show("Max Channel is " + iChannelNum);
                int_iChannelNo = iChannelNum - 1;
                return;
            }

            iRet = NVSSDK.NetClient_StartRecv(ref uiConID, ref m_cltInfo, null);


            if (iRet < 0)
            {
                m_conState[m_iCurrentFrame].m_iLogonID = -1;
                m_conState[m_iCurrentFrame].m_uiConID = UInt32.MaxValue;
                m_conState[m_iCurrentFrame].m_iChannelNO = -1;
                MessageBox.Show("Connect failed !");
                return;
            }

            m_conState[m_iCurrentFrame].m_iLogonID = m_cltInfo.m_iServerID;
            m_conState[m_iCurrentFrame].m_iChannelNO = m_cltInfo.m_iChannelNo;
            m_conState[m_iCurrentFrame].m_uiConID = uiConID;
            m_conState[m_iCurrentFrame].m_iStreamNO = m_cltInfo.m_iStreamNO;


            NVSSDK.NetClient_StartCaptureData(uiConID);
            if (iRet == 1)
            {
                RECT rect = new RECT();


                NVSSDK.NetClient_StartPlay(uiConID, m_video[m_iCurrentFrame].pnlVideo.Handle, rect, 0);
                // btnPlay.Text = "Stop";
                GetWindowStates();
            }
            // btnConnect.Text = "Disconnect";
        }
        //b_IniAplication = true;
    }

    private void GetWindowStates()
    {
        //btnLogon.Text = "Logoff";
        //btnConnect.Text = "Disconnect";
        //btnPlay.Text = "Stop";
        UInt32 uiConID = m_conState[m_iCurrentFrame].m_uiConID;

        //正在录像
        if (NVSSDK.NetClient_GetCaptureStatus(uiConID) == 1)
        {
            //btnRecord.Text = "Stop";
        }
        Int32 iLogonID = m_conState[m_iCurrentFrame].m_iLogonID;
        Int32 iComPortCounts = 2;
        Int32 iComPortEnabledStatus = 0;

       
        NVSSDK.NetClient_GetComPortCounts(iLogonID, ref iComPortCounts, ref iComPortEnabledStatus);

       
        //if (cboComNo.Items.Count < iComPortCounts)
        //{
        //    for (int i = cboComNo.Items.Count; i < iComPortCounts; i++)
        //    {
        //        cboComNo.Items.Add("COM" + (i + 1));
        //        cboComSend.Items.Add("COM" + (i + 1));
        //    }
        //}
       
        GetOSD();
        GetOSDType();
        //GetDeviceType();
        //GetVideoParam();
        //GetFTPUploadConfig();//new add
    }

    //获得并显示字符叠加参数
    private void GetOSD()
    {
        byte[] btOSD = new byte[32];
        UInt32 uiColor = 0;

        //获得视频源上叠加的字符串
        NVSSDK.NetClient_GetOsdText
        (
            m_conState[m_iCurrentFrame].m_iLogonID,
            m_conState[m_iCurrentFrame].m_iChannelNO,
            btOSD,
            ref uiColor
        );

        //将byte型数组转化为字符串
      //  textOSD.Text = Encoding.ASCII.GetString(btOSD);
    }

    //设置字符叠加参数
    private void SetOSD()
    {
      //  string strOSD = textOSD.Text;

        //判断是否为空字符串
       // strOSD = strOSD == "" ? " " : strOSD;
        UInt32 uiColor = 0;

        //在视频源上叠加一个字符串
        //NVSSDK.NetClient_SetOsdText
        //(
        //    m_conState[m_iCurrentFrame].m_iLogonID,
        //    m_conState[m_iCurrentFrame].m_iChannelNO,
        //  //  Encoding.ASCII.GetBytes(strOSD),//将字符串转化为byte型数组
        //    uiColor
        //);
       // textOSD.Text = strOSD;
    }

    //获取字符叠加状态
    private void GetOSDType()
    {
       // Int32 iType = cboOSDType.SelectedIndex;

        //转化为字符叠加类型码,0x01 叠加时间,0x02 叠加字符串,0x04 叠加LOGO标志 
        //switch (iType)
        //{
        //    case 0:
        //        iType = 0x01;
        //        break;
        //    case 1:
        //        iType = 0x02;
        //        break;
        //    case 2:
        //        iType = 0x04;
        //        break;
        //    default:
        //        iType = 0x02;
        // //       cboOSDType.SelectedIndex = 1;
        //        break;
        //}
        int iX = 0;
        int iY = 0;
        int iEnable = 0;


        //获得网络视频服务器某一路的字符叠加状态
        //NVSSDK.NetClient_GetOsdType
        //(
        //    m_conState[m_iCurrentFrame].m_iLogonID,
        //    m_conState[m_iCurrentFrame].m_iChannelNO,
        //  //  iType,
        //    ref iX,
        //    ref iY,
        //    ref iEnable
        //);
        //cboOSDX.Text = iX.ToString();
        //cboOSDY.Text = iY.ToString();
        //cboOSDEnable.SelectedIndex = iEnable;
    }

    //设置字符叠加状态
    private void SetOSDType()
    {
      //  Int32 iType = cboOSDType.SelectedIndex;

        //转化为字符叠加类型码,0x01 叠加时间,0x02 叠加字符串,0x04 叠加LOGO标志 
        //switch (iType)
        //{
        //    case 0:
        //       // iType = 0x01;
        //        break;
        //    case 2:
        //        iType = 0x04;
        //        break;
        //    default:
        //        iType = 0x02;
        //        break;
        //}
        int iX = 0;
        int iY = 0;
        int iEnable = 0;
        try
        {
            //iX = Int32.Parse(cboOSDX.Text);
            //iY = Int32.Parse(cboOSDY.Text);
            //iEnable = cboOSDEnable.SelectedIndex;
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }

        //开始或停止字符叠加操作，同时指定字符叠加的位置。
        //int iRet = NVSSDK.NetClient_SetOsdType
        //(
        //    m_conState[m_iCurrentFrame].m_iLogonID,
        //    m_conState[m_iCurrentFrame].m_iChannelNO,
        //    iX,
        //    iY,
        //    //iType,
        //    iEnable
        //);
        //if (iRet < 0)
        //{
        //    MessageBox.Show("NetClient_SetOsdType Failed! USER_ERROR+" + (Marshal.GetLastWin32Error() - SDKConstMsg.USER_ERROR));
        //}
    }
    private Boolean iniLogon()
    {
        Boolean init = false;
        string strProxy = "";
        string strIP ="192.168.10.225";
        string strUser = "admin";
        string strPwd = "1111";
        string strProxyID = "";
        int iPort = 3000;
        int iRet;

        iRet = NVSSDK.NetClient_Logon(strProxy, strIP, strUser, strPwd, strProxyID, iPort);
        int_LogonID = NVSSDK.NetClient_Logon(strProxy, strIP, strUser, strPwd, strProxyID, iPort);

        if (iRet < 0)
        {
              m_cltInfo.m_iServerID = -1;
            // MessageBox.Show("Logon failed !");
            init = false;

        }else{
            init = true;
        }
        //m_cltInfo.m_iServerID = iRet;
        //btnLogon.Text = "Logoff";

        return init;
    }
    private void iniAllCameras()
    {
        DataSet ds = new DataSet();

        listCameras.Add(new Cameras()
        {
            CameraID =1,
            CameraIDE ="",
            CameraChannel = 1,
            CameraIDLogon = "",
            CameraIP = "",
            CameraUser = "",
            CameraPass = "",
            CameraPort = "",
            CameraEstado = 1
        });
    }

    private void iniVerifiCamerasConections()
    {
        foreach (Cameras listadoCameras in listCameras)
        {
              EstadoProceso="Activa";

            listCamerasTriggers.Add(new Cameras()
            {
                CameraID = 1,
                CameraIDE = "",
                CameraChannel = 1,
                CameraIDLogon = "",
                CameraIP = "",
                CameraUser = "",
                CameraPass = "",
                CameraPort = "",
                CameraEstado = 1,
                CameraObservacion = EstadoProceso
            });
        }
    }

    private Boolean ConectionCamera(string strProxy,string strIP,string strUser,string strPwd,string strProxyID,int iPort)
    {
        Boolean exito = false; 
                //string strProxy = "";
                //string strIP = cboIP.Text;
                //string strUser = textUser.Text;
                //string strPwd = textPwd.Text;
                //string strProxyID = "";
                //int iPort = 3000;
                //int iRet;

                int iRet = NVSSDK.NetClient_Logon(strProxy, strIP, strUser, strPwd, strProxyID, iPort);
                int int_LogonID = NVSSDK.NetClient_Logon(strProxy, strIP, strUser, strPwd, strProxyID, iPort);
                if (iRet < 0)
                {
                    exito = false;
                }
                else { 
                    exito = true;
                }

                return exito;
    }

}

    
}
