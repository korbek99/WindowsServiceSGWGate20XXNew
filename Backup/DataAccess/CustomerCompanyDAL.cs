using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DataAccess
{
    public class CustomerCompanyDAL
    {
        BaseDatos dbm = new BaseDatos();
        public DataSet CustomerCompanyByCustomerIPDAL(string IP)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            DataSet ds = new DataSet();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Select_Camera_CostumerIP", con);
                parametros = cmd.Parameters.Add("@CameraIP", SqlDbType.VarChar);
                parametros.Value = IP;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                con.Close();
                return ds;
            }
            catch (SqlException e) { 
                Console.WriteLine("Error de SQL :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompany/CustomerCompanyByCustomerIPDAL");
            
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
                objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompany/CustomerCompanyByCustomerIPDAL");
            }
            return null;
        }

        //public DataSet GetAllCustomerCompanyDAL()
        //{
        //    SqlConnection con = new SqlConnection();
        //    SqlParameter parametros;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        con = dbm.getConexion();
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("SWG_Select_Camera_CostumerIP", con);
               
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //        ad.Fill(ds);
        //        con.Close();
        //        return ds;
        //    }
        //    catch (SqlException e)
        //    {
        //        Console.WriteLine("Error de SQL :" + e.Message);
        //        Console.WriteLine("Error :" + e.Message);
        //        ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
        //        objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompany/CustomerCompanyByCustomerIPDAL");

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error :" + e.Message);
        //        ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
        //        objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompany/CustomerCompanyByCustomerIPDAL");
        //    }
        //    return null;
        //}
    }
}
