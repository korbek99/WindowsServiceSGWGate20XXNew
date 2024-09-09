using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using WebServiceNextiva.Entity;
using System.Data.SqlClient;

namespace WebServiceNextiva
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        public string str_Message = "";
        public ErrorSWGNextiva objErrorDal = new ErrorSWGNextiva();
        public int int_AlarmSentChannel;
        public DateTime d_AlarmSentDateIng;
        public string str_AlarmSentDescription;
        public int int_AlarmSentEstado;
        public int int_AlarmSentIDE;
        public string str_AlarmSentrctTarget;
        public string str_AlarmSentRuleDescrip;
        public int int_AlarmSentRuleID;
        public int int_AlarmSentState;
        public int int_AlarmSentTargetDirection;
        public int int_AlarmSentTargetID;
        public int int_AlarmSentTargetSpeed;
        public int int_AlarmSentTargetType;
        public int int_AlarmSentventType;

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}
  
        [WebMethod]
        public Boolean SendDataCameraToNextivaRecepcion(int AlarmSentChannel,
                                                        DateTime AlarmSentDateIng,
                                                        string AlarmSentDescription,
                                                        int AlarmSentEstado,
                                                        int AlarmSentIDE,
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
            Boolean res = false;


             int int_AlarmSentChannel=AlarmSentChannel;
             DateTime d_AlarmSentDateIng =AlarmSentDateIng;
             string str_AlarmSentDescription=AlarmSentDescription;
             int int_AlarmSentEstado=AlarmSentEstado;
             int int_AlarmSentIDE=AlarmSentIDE;
             string str_AlarmSentrctTarget=AlarmSentrctTarget;
             string str_AlarmSentRuleDescrip=AlarmSentRuleDescrip;
             int int_AlarmSentRuleID=AlarmSentRuleID;
             int int_AlarmSentState=AlarmSentState;
             int int_AlarmSentTargetDirection=AlarmSentTargetDirection;
             int int_AlarmSentTargetID=AlarmSentTargetID;
             int int_AlarmSentTargetSpeed=AlarmSentTargetSpeed;
             int int_AlarmSentTargetType=AlarmSentTargetType;
             int int_AlarmSentventType = AlarmSentventType;


            try
            {
                if (ValidField() == true)
                {
                 //// DataNextivaDAL ObjData = new DataNextivaDAL();
                //if (ObjData.SendDataCameraToNextivaDAL(Objeto) == true)
                //{
                   res = true;
                //}
                }else {

                    objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "WebService Nextiva", 4, "Error Valid Field :" + str_Message, 1, 1, "WebServiceNextiva/SendDataCameraToNextivaRecepcion");
                    res = false;
                }
                
            }

            catch (SqlException e)
            {
              
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "WebService Nextiva", 1, "Error :" + e.Message, 1, 1, "WebServiceNextiva/SendDataCameraToNextivaRecepcion");
            }
            catch (Exception e)
            {
              
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "WebService Nextiva", 1, "Error :" + e.Message, 1, 1, "WebServiceNextiva/SendDataCameraToNextivaRecepcion");
            }
            return res;
        }

        private Boolean ValidField()
        {
            Boolean validField = false;


            if (int_AlarmSentChannel == 0 || int_AlarmSentChannel < 0)
            {
                str_Message = "Empty Field AlarmSentChannel";
                validField = false;
                return validField;
            }
            if (Convert.ToString(d_AlarmSentDateIng) =="")
            {
                str_Message = "Empty Field AlarmSentDateIng";
                validField = false;
                return validField;
            }

            if (String.IsNullOrEmpty(str_AlarmSentDescription))
            {
                str_Message = "Empty Field str_AlarmSentDescription";
                validField = false;
                return validField;
            }
            if (int_AlarmSentEstado == 0 || int_AlarmSentEstado < 0)
            {
                str_Message = "Empty Field int_AlarmSentEstado";
                validField = false;
                return validField;
            }

            if (int_AlarmSentIDE == 0 || int_AlarmSentIDE < 0)
            {
                str_Message = "Empty Field int_AlarmSentIDE";
                validField = false;
                return validField;
            }

            if (String.IsNullOrEmpty(str_AlarmSentrctTarget))
            {
                str_Message = "Empty Field str_AlarmSentrctTarget";
                validField = false;
                return validField;
            }
            if (String.IsNullOrEmpty(str_AlarmSentRuleDescrip))
            {
                str_Message = "Empty Field str_AlarmSentRuleDescrip";
                validField = false;
                return validField;
            }

            if (int_AlarmSentState == 0 || int_AlarmSentState < 0)
            {
                str_Message = "Empty Field int_AlarmSentState";
                validField = false;
                return validField;
            }

            if (int_AlarmSentTargetDirection == 0 || int_AlarmSentTargetDirection < 0)
            {
                str_Message = "Empty Field int_AlarmSentTargetDirection";
                validField = false;
                return validField;
            }

            if (int_AlarmSentTargetID == 0 || int_AlarmSentTargetID < 0)
            {
                str_Message = "Empty Field AlarmSentTargetID";
                validField = false;
                return validField;
            }


            if (int_AlarmSentTargetSpeed == 0 || int_AlarmSentTargetSpeed < 0)
            {
                str_Message = "Empty Field int_AlarmSentTargetSpeed";
                validField = false;
                return validField;
            }

            if (int_AlarmSentTargetType == 0 || int_AlarmSentTargetType < 0)
            {
                str_Message = "Empty Field int_AlarmSentTargetType";
                validField = false;
                return validField;
            }
            if (int_AlarmSentventType == 0 || int_AlarmSentventType < 0)
            {
                str_Message = "Empty Field int_AlarmSentventType";
                validField = false;
                return validField;
            }
            
            return validField;
        }
        
    }
}
