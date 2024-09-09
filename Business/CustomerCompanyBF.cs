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
   public class CustomerCompanyBF
    {
       public DataSet CustomerCompanyByCustomerIPBF(string IP)
       {
           CustomerCompanyDAL Obj = new CustomerCompanyDAL();

           DataSet ds = new DataSet();
           try
           {
               ds = Obj.CustomerCompanyByCustomerIPDAL(IP);
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPBF");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPBF");
           }
           return null;
       }

       public DataSet CustomerCompanyByCustomerIDBF(int ID)
       {
           CustomerCompanyDAL Obj = new CustomerCompanyDAL();

           DataSet ds = new DataSet();
           try
           {
               ds = Obj.CustomerCompanyByCustomerIDDAL(ID);
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPDAL");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPDAL");
           }
           return null;
       }
       public DataSet AllCustomerCompanyByCustomerBF()
       {
           CustomerCompanyDAL Obj = new CustomerCompanyDAL();

           DataSet ds = new DataSet();
           try
           {
               ds = Obj.AllCustomerCompanyByCustomerDAL();
               
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPDAL");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPDAL");
           }
           return null;


       }

       public DataSet AllCustomerCompanyListDropBF()
       {
            CustomerCompanyDAL Obj = new CustomerCompanyDAL();
           DataSet ds = new DataSet();
           try
           {

               ds = Obj.AllCustomerCompanyListDropDAL();
               
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPDAL");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCustomerIPDAL");
           }
           return null;
       }

       public DataSet SearchCustomerCompanyByNameCustomerBF(string str_name)
       {
            CustomerCompanyDAL Obj = new CustomerCompanyDAL();
           DataSet ds = new DataSet();
           try
           {
               ds = Obj.SearchCustomerCompanyByNameCustomerDAL(str_name);
               
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/SearchCustomerCompanyByNameCustomerBF");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/SearchCustomerCompanyByNameCustomerBF");
           }
           return null;
       }

       public DataSet CustomerCompanyByCiudadIDBF(int CiudadID)
       {
           CustomerCompanyDAL Obj = new CustomerCompanyDAL();
           DataSet ds = new DataSet();
           try
           {
               ds = Obj.CustomerCompanyByCiudadIDDAL(CiudadID);
           
               return ds;
           }
           catch (SqlException e)
           {
               Console.WriteLine("Error de SQL :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCiudadIDBF");

           }
           catch (Exception e)
           {
               Console.WriteLine("Error :" + e.Message);
               ErrorSWGNextivaDAL objErrorDal = new ErrorSWGNextivaDAL();
               objErrorDal.TrackingErrorSWGNextivaDAL(DateTime.Today, Environment.MachineName, "Core Nextiva", 1, "Error :" + e.Message, 1, 1, "CustomerCompanyBF/CustomerCompanyByCiudadIDBF");
           }
           return null;
       }
    }
}
