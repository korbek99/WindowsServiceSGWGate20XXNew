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
    public partial class ListaAlarmas : Form
    {
        public ListaAlarmas()
        {
            InitializeComponent();
            LoadDataAlarmas();
            LoadDataEmpresas();
            LoadDataRules();
            IniParameters();
            SetDataTypeRules();
            SetCheckOptions();
            

        }
        private void SetDataTypeRules()
        {
            CmdRules.Enabled = false;
        }
        private void SetCheckOptions()
        {
            checkAllRules.Checked = true;
        }
        private void IniParameters()
        {
            lblMensaje.Text = "";
        }
        private void LoadDataAlarmas()
        {
            try {
                DataNextivaBF Obj = new DataNextivaBF();
                DataSet ds = new DataSet();
                ds = Obj.GetAllDataProcessedNextivaBF();

                GridAlarmas.DataSource = ds.Tables[0];
            
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "ListaAlarmas/LoadDataAlarmas");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "ListaAlarmas/LoadDataAlarmas");

            }

        }
        private void LoadDataEmpresas()
        {
            try {
                CustomerCompanyBF Obj = new CustomerCompanyBF();
                DataSet ds = new DataSet();
                ds = Obj.AllCustomerCompanyListDropBF();
                cmdEmpresas.DataSource = ds.Tables[0];
            
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "ListaAlarmas/LoadDataEmpresas");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "ListaAlarmas/LoadDataEmpresas");

            }
        }
        private void LoadDataRules()
        {
            try {
                TypeRulesBF Obj = new TypeRulesBF();
                DataSet ds = new DataSet();
                ds = Obj.AllTypeRulesListDropBF();
                CmdRules.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "ListaAlarmas/LoadDataRules");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "ListaAlarmas/LoadDataRules");
            }
        }
        
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            try
            {
                DataNextivaBF Obj = new DataNextivaBF();
                DataSet ds = new DataSet();

                    dateTimeInicio.Format = DateTimePickerFormat.Custom;
                    dateTimeInicio.CustomFormat = "yyyy-MM-dd";

                    dateTimeFinal.Format = DateTimePickerFormat.Custom;
                    dateTimeFinal.CustomFormat = "yyyy-MM-dd";

                     string TextFechaInicio = dateTimeInicio.Text;
                     string TextFechaFin = dateTimeFinal.Text;


                DateTime FechaIn = Convert.ToDateTime(TextFechaInicio);
                DateTime FechaFin= Convert.ToDateTime(TextFechaFin);


                if (checkAllRules.Checked == false && CmdRules.Enabled == true)
                {
                    ds = Obj.GetDataProcessedNextivaByParametersBF(Convert.ToInt32(CmdRules.SelectedItem), Convert.ToInt32(cmdEmpresas.SelectedItem), FechaIn, FechaFin);
                }
                else
                {

                    ds = Obj.GetDataProcessedNextivaByParametersBF(-1, Convert.ToInt32(cmdEmpresas.SelectedItem), FechaIn, FechaFin);
                }
               
                GridAlarmas.DataSource = ds.Tables[0];
               
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "ListaAlarmas/btnProcesar_Click");

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "ListaAlarmas/btnProcesar_Click");

            }
        }

        private void checkAllRules_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAllRules.Checked == true)
            {
                CmdRules.Enabled = false;
            }
            else
            {
                CmdRules.Enabled = true;
            }

        }
    }
}
