using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;
using System.Data.SqlClient;
namespace NetClient
{
    public partial class MapaNextiva : Form
    {
        public MapaNextiva()
        {
            InitializeComponent();
            LoadDataEmpresas();
            LoadDataRules();
            LoadDataGeneralMapa();
            IniParameters();
        }
        private void LoadDataMapaByCustomer(int CustomerId)
        {
            try
            {
                //CustomerCompanyBF Obj = new CustomerCompanyBF();
                //DataSet ds = new DataSet();
                
                //ds = Obj.AllCustomerCompanyListDropBF();
                //cmdEmpresas.DataSource = ds.Tables[0];

            }
            catch (SqlException ex)
            {
                lblMensaje.Text = "Error Capturado : LoadDataMapaByCustomer";
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "MapaNextiva/LoadDataMapaByCustomer");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error Capturado : LoadDataMapaByCustomer";
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "MapaNextiva/LoadDataMapaByCustomer");

            }
        }
        private void LoadImageMapaByCustomer(int CustomerId)
        {
            try
            {
                //CustomerCompanyBF Obj = new CustomerCompanyBF();
                //DataSet ds = new DataSet();
                //ds = Obj.AllCustomerCompanyListDropBF();
                //cmdEmpresas.DataSource = ds.Tables[0];

            }
            catch (SqlException ex)
            {
                lblMensaje.Text = "Error Capturado : LoadImageMapaByCustomer";
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "MapaNextiva/LoadImageMapaByCustomer");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error Capturado : LoadImageMapaByCustomer";
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "MapaNextiva/LoadImageMapaByCustomer");

            }
        }
        private void IniParameters()
        {
            lblMensaje.Text = "";
        }
        private void LoadDataEmpresas()
        {
            try
            {
                CustomerCompanyBF Obj = new CustomerCompanyBF();
                DataSet ds = new DataSet();
                ds = Obj.AllCustomerCompanyListDropBF();
                cmdEmpresas.DataSource = ds.Tables[0];

            }
            catch (SqlException ex)
            {
                lblMensaje.Text = "Error Capturado : LoadDataEmpresas";
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "MapaNextiva/LoadDataEmpresas");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error Capturado : LoadDataEmpresas";
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "MapaNextiva/LoadDataEmpresas");

            }

        }
        private void LoadDataRules()
        {
            try
            {

                TypeRulesBF Obj = new TypeRulesBF();
                DataSet ds = new DataSet();
                ds = Obj.AllTypeRulesListDropBF();
                CmdRules.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {
                lblMensaje.Text = "Error Capturado : LoadDataRules";
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "MapaNextiva/LoadDataRules");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error Capturado : LoadDataRules";
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "MapaNextiva/LoadDataRules");

            }

        }
        private void LoadDataGeneralMapa()
        {
            try {

            }
            catch (SqlException ex)
            {
                lblMensaje.Text = "Error Capturado : LoadDataGeneralMapa";
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "MapaNextiva/LoadDataGeneralMapa");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error Capturado : LoadDataGeneralMapa";
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "MapaNextiva/LoadDataGeneralMapa");

            }
        
        }

       

       
    }
}
