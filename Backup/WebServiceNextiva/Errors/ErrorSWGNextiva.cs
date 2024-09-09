using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace WebServiceNextiva
{
    public class ErrorSWGNextiva
    {
        BaseDatos dbm = new BaseDatos();

        public Boolean TrackingErrorSWGNextivaDAL(DateTime Fecha,
                string MachineName,
                string UserName,
                int IdSistema,
                string Mensaje,
                int Resuelto,
                int NumeroError,
                string Modulo)
        {
            SqlConnection con = new SqlConnection();
            Boolean esExito = false;
            SqlParameter parametros;
            try
            {
                con = dbm.getConexion();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("SWG_Insert_Errores", con);

                parametros = cmd.Parameters.Add("@Fecha", SqlDbType.DateTime);
                parametros.Value = Fecha;

                parametros = cmd.Parameters.Add("@MachineName", SqlDbType.VarChar);
                parametros.Value = MachineName;

                parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
                parametros.Value = UserName;

                parametros = cmd.Parameters.Add("@IdSistema", SqlDbType.Int);
                parametros.Value = IdSistema;

                parametros = cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar);
                parametros.Value = Mensaje;

                parametros = cmd.Parameters.Add("@Resuelto", SqlDbType.Int);
                parametros.Value = Resuelto;

                parametros = cmd.Parameters.Add("@NumeroError", SqlDbType.Int);
                parametros.Value = NumeroError;

                parametros = cmd.Parameters.Add("@Modulo", SqlDbType.VarChar);
                parametros.Value = Modulo;

                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    esExito = true;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                esExito = false;
            }
            return esExito;
            
        }
    }
}
