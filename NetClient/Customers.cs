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
    public partial class Customers : Form
    {
        public string str_validTexto;
        public Customers()
        {
            InitializeComponent();
            IniParameters();
            LoadDataCustomers();
        }
        private void IniParameters()
        {
            lblMensaje.Text = "";
        }
        private void LoadDataCity()
        {
            try
            {
                CiudadBF Obj = new CiudadBF();
                DataSet ds = new DataSet();
                ds = Obj.GetAllCityBF();

                CmbCiudad.DataSource = ds.Tables[0];

            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "Customers/LoadDataCity");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "Customers/LoadDataCity");

            }

        }
        private void LoadDataCustomers()
        {
            try
            {
                CustomerCompanyBF Obj = new CustomerCompanyBF();
                DataSet ds = new DataSet();
                ds = Obj.AllCustomerCompanyByCustomerBF();

                GridData.DataSource = ds.Tables[0];

            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "Customers/LoadDataCustomers");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "Customers/LoadDataCustomers");

            }

        }
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                if (Convert.ToInt32(CmbCiudad.SelectedItem) > 0)
                {
                    SearchDataCustomersByCiudad(Convert.ToInt32(CmbCiudad.SelectedItem));
                }else{ 

                    if( ValidField()==true)
                    {
                        SearchDataCustomersByName(textName.Text);
                    }else{
                        lblMensaje.Text = str_validTexto;
                    
                    }
                   
                }
                 
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "Customers/btnProcesar_Click");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "Customers/btnProcesar_Click");

            }
        }

        private Boolean ValidField()
        {
            bool valid = true;

            if (String.IsNullOrEmpty(textName.Text))
            {
                str_validTexto = "Campo texto vacio , favor llenar campo antes de consulta";
                valid = false;
                return valid;
            }
            return valid;

        }
        private void SearchDataCustomersByCiudad(int CiudadID)
        { 
        //CustomerCompanyByCiudadIDBF
            try
            {
                CustomerCompanyBF Obj = new CustomerCompanyBF();
                DataSet ds = new DataSet();
                ds = Obj.CustomerCompanyByCiudadIDBF(CiudadID);

                GridData.DataSource = ds.Tables[0];

            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "Customers/SearchDataCustomersByCiudad");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "Customers/SearchDataCustomersByCiudad");

            }
        
        }
        private void SearchDataCustomersByName(string str_name)
        {
            try
            {
                CustomerCompanyBF Obj = new CustomerCompanyBF();
                DataSet ds = new DataSet();
                ds = Obj.SearchCustomerCompanyByNameCustomerBF(str_name);

                GridData.DataSource = ds.Tables[0];

            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "Customers/SearchDataCustomersByName");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "Customers/SearchDataCustomersByName");

            }
        }

       
    }
}
