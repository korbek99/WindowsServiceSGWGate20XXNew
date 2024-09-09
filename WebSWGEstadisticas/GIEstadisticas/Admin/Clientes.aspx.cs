using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using System.Data;

namespace WebSWGEstadisticas.GIEstadisticas.Admin
{
    public partial class Clientes : System.Web.UI.Page
    {
        public CustomerCompanyBF ObjCustomer = new CustomerCompanyBF();
        public DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenadogrilla();
        }
        private void llenadogrilla()
        { 
            ds = ObjCustomer.AllCustomerCompanyByCustomerBF();
            GridData.DataSource = ds;
            GridData.DataBind();

           // hidecolumns();
        }
        private void hidecolumns()
        {
            //GridData.Columns(0).Visible = false;
            //GridData.Columns[5].Visible = false;
        }
        //protected void GridData_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    e.Row.Cells[0].Visible = false;
        //    e.Row.Cells[4].Visible = false;
        //    e.Row.Cells[5].Visible = false;
        //}
    }
}