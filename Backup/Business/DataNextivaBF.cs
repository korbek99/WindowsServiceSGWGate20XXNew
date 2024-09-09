
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Entities;
using System.Data.SqlClient;

namespace Business
{
    public class DataNextivaBF
    {
        public int GetLastIDBF(int idchannel)
        {
            int res = 0;
             DataNextivaDAL ObjData = new DataNextivaDAL();

             res = ObjData.GetLastIDE(idchannel);

            return res;
        }

        public Boolean SendDataCameraToNextivaBF(List<AlarmNextiva> Objeto)
        {
            Boolean res = false;
            try
            {
                DataNextivaDAL ObjData = new DataNextivaDAL();
                if (ObjData.SendDataCameraToNextivaDAL(Objeto) == true)
                {
                    res = true;
                }
            }
            catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
            return res;
        }

        public DataSet GetAllDataProcessedNextivaBF()
        {
            DataSet ds = new DataSet();

            try
            {
                DataNextivaDAL ObjData = new DataNextivaDAL();

                ds = ObjData.GetAllDataProcessedNextivaDAL();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
            }
            return ds;

        }
    }
}
