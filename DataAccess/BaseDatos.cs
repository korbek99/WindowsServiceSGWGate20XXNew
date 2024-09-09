using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataAccess
{
    public class BaseDatos
    {
        public BaseDatos() { }

        public SqlConnection getConexion()
        {
            try
            {
                //string connetionString = null;
                //SqlConnection con;
                //connetionString = "Data Source=(local);Initial Catalog=SWG;Integrated Security=True";
                // SqlConnection con = new SqlConnection("SERVER=ID-WS2-PC\\JoseBustos;Initial Catalog=SWG;Integrated Security=True");
                SqlConnection con = new SqlConnection("Data Source=ID-W7-JB-PC\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=SWG1");
              //  con = new SqlConnection(connetionString);
                return con;

            }
            catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
            return null;
        }
    }
}
