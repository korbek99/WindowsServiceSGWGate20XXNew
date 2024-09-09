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
    }
}
