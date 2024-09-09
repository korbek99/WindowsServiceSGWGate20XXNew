using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsServiceNextiva.Log;
using WindowsServiceNextiva.ServiceReference1;
namespace WindowsServiceNextiva.Transac
{
   public class TransaNextivaData
    {
       
        public void SendAlarmsToNextivaSWG(int AlarmSentChannel,
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
            Logger ObjLog1 = new Logger();
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
                    ObjLog1.LoggerWritter("Excepcion WindowsServiceNextiva/SendAlarmsToNextivaSWG Error :  Data was not sent to nextiva " + DateTime.Today.ToString());
                    Console.WriteLine("Excepcion WindowsServiceNextiva/SendAlarmsToNextivaSWG : {0}", "Error :  Data was not sent to nextiva " + DateTime.Today.ToString());
                    // WinServiceTrackingErrorSWG(DateTime.Today, Environment.MachineName, "Remote Windows Service Nextiva", 6, "Error :  Data was not sent to nextiva ", 1, 1, "WindowsServiceNextiva/SendAlarmsToNextivaSWG");
                }
                else
                {
                    Console.WriteLine("Alarm event was successfully sent to Nextiva : {0}", "Alarm event was sent" + DateTime.Today.ToString());
                    ObjLog1.LoggerWritter("Alarm event was successfully sent to Nextiva WebService " + DateTime.Today.ToString());
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
    }
}
