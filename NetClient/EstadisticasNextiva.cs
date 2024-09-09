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
    public partial class EstadisticasNextiva : Form
    {
        public EstadisticasNextiva()
        {
            InitializeComponent();
            LoadDataCustomers();
            LoadDataTypeRules();
            LoadCaptionTabs();
            SetCheckOptions();
            SetDataTypeRules();
          
        }
        private void SetDataTypeRules()
        {
            DDlTypeRules.Enabled = false;
        }
        private void SetCheckOptions()
        {
            checkAllRules.Checked = true;
        }
        private void LoadCaptionTabs()
        {
            tabPage1.Text = @"Types Rules Graphic";
            tabPage2.Text = @"Types Rules Graphic Circular";
            tabPage4.Text = "DashBoard"; //@"Total Sum all Rules Comparing By Customer ";
            tabPage3.Text = @"Total Selected Rules Comparing By Customer ";
        }
        private void LoadDataCustomers()
        {
            try {
                CustomerCompanyBF Obj = new CustomerCompanyBF();
                DataSet ds = new DataSet();

                //DDlCustomers.Items.Add(-1,"Seleccionar");
                //DDlCustomers.AppendDataBoundItems = true;

                ds = Obj.AllCustomerCompanyListDropBF();
                DDlCustomers.DataSource = ds.Tables[0];
            
                DDlCustomers.DisplayMember = "Nombre";
                DDlCustomers.ValueMember = "ID";
               // DDlCustomers.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "EstadisticasNextiva/LoadDataCustomers");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "EstadisticasNextiva/LoadDataCustomers");

            }
           
        }
        private void LoadDataTypeRules()
        {
            try
            {
                TypeRulesBF Obj = new TypeRulesBF();
                DataSet ds = new DataSet();
                ds = Obj.AllTypeRulesListDropBF();
                DDlTypeRules.DataSource = ds.Tables[0];
                DDlTypeRules.DisplayMember = "Nombre";
                DDlTypeRules.ValueMember = "ID";
                // DDlTypeRules.Items.Insert(-1, "Seleccionar");

                //  DDlTypeRules.Items.Insert(0, new ListItem("Seleccionar", "-1"));
            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "EstadisticasNextiva/LoadDataTypeRules");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "EstadisticasNextiva/LoadDataTypeRules");

            }
        }

        private void btnprocesar_Click(object sender, EventArgs e)
        {

            DataSet dsGrafico = new DataSet();
            DataSet dsGraficoAll = new DataSet();
            DataSet dsGraficoAllTypes = new DataSet();
            DataSet dsGrafAllByTypesRules = new DataSet();
            NextivaStatisticsBF ObjNextivaStatistics = new NextivaStatisticsBF();

            dateTimeInicio.Format = DateTimePickerFormat.Custom;
            dateTimeInicio.CustomFormat = "yyyy-MM-dd";

            dateTimeFin.Format = DateTimePickerFormat.Custom;
            dateTimeFin.CustomFormat = "yyyy-MM-dd";

            string TextFechaInicio = dateTimeInicio.Text;
            string TextFechaFin = dateTimeFin.Text;

            chartBarras.Series["Barras"].Points.Clear();
            chartCircular.Series["Circular"].Points.Clear();
            chartAllCostumers.Series["Todos"].Points.Clear();
            chartAllRules.Series["AllRules"].Points.Clear();
            listDatosGraficos.Items.Clear();

            try
            {
                if (checkAllRules.Checked == false && DDlTypeRules.Enabled == true)
                {
                    dsGraficoAll = ObjNextivaStatistics.AllCostumersAndTypeRulesNextivaStatisticsBF(Convert.ToInt32(DDlTypeRules.SelectedValue));
                    tabPage3.Text = @"Total Selected Rule Comparing By Customer ";
                }else {

                    dsGraficoAll = ObjNextivaStatistics.AllCostumersAndTypeRulesNextivaStatisticsBF(-1);
                    tabPage3.Text = @"Total Rules Comparing By Customer ";
                }
                


                //dsGrafAllByTypesRules = ObjNextivaStatistics.AllCostumersByTypeRulesNextivaStatisticsBF();
               
               

                if (checkAllRules.Checked == false && DDlTypeRules.Enabled == true)
                {
                    dsGrafico = ObjNextivaStatistics.AllNextivaStatisticsBF(Convert.ToInt32(DDlCustomers.SelectedValue), Convert.ToInt32(DDlTypeRules.SelectedValue), Convert.ToDateTime(TextFechaInicio), Convert.ToDateTime(TextFechaFin));
                }
                else
                {
                    dsGrafico = ObjNextivaStatistics.AllNextivaStatisticsBF(Convert.ToInt32(DDlCustomers.SelectedValue), 0, Convert.ToDateTime(TextFechaInicio), Convert.ToDateTime(TextFechaFin));
                }

             
                
                if (dsGrafico.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dsGrafico.Tables[0].Rows)
                    {
                        //chartBarras.Series["Barras"].Points.AddXY("Jaqueline", 1200);
                        //chartBarras.Series["Barras"].Points.AddXY("Joana", 900);

                        chartBarras.Series["Barras"].Points.AddXY(dataRow["Regla"].ToString(), Convert.ToInt32(dataRow["Cantidad"].ToString()));
                        chartCircular.Series["Circular"].Points.AddXY(dataRow["Regla"].ToString(), Convert.ToInt32(dataRow["Cantidad"].ToString()));
                        listDatosGraficos.Items.Add(dataRow["Regla"].ToString() + ":" + Convert.ToInt32(dataRow["Cantidad"].ToString()));
                   
                    }
                }else{

                    MessageBox.Show("No se encontraron Datos relacionados a la consulta");
                    return;
                }

                if (dsGraficoAll.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dsGraficoAll.Tables[0].Rows)
                    {

                        chartAllCostumers.Series["Todos"].Points.AddXY(dataRow["Customer"].ToString(), Convert.ToInt32(dataRow["Cantidad"].ToString()));

                    }
                }
                else {

                    //MessageBox.Show("No se encontraron Datos relacionados a la consulta");
                }


                //if (dsGraficoAllTypes.Tables[0].Rows.Count > 0)
                //{
                //    foreach (DataRow dataRow in dsGraficoAllTypes.Tables[0].Rows)
                //    {

                //        chartAllRules.Series["AllRules"].Points.AddXY(dataRow["Customer"].ToString(), Convert.ToInt32(dataRow["Cantidad"].ToString()));

                //    }
                //}

            }
            catch (SqlException ex)
            {
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "EstadisticasNextiva/btnprocesar_Click");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion Capturada : {0}", ex);
                ErrorSWGNextivaBF objErrorDal = new ErrorSWGNextivaBF();
                objErrorDal.TrackingErrorSWGNextivaBF(DateTime.Today, Environment.MachineName, "Aplication SWG (VB)", 1, "Error :" + ex.Message, 1, 1, "EstadisticasNextiva/btnprocesar_Click");

            }
            
        }

        private void checkAllRules_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAllRules.Checked == true)
            {
                DDlTypeRules.Enabled = false;
            } else {
                DDlTypeRules.Enabled = true;
            }

              
        }

        

    }
}
