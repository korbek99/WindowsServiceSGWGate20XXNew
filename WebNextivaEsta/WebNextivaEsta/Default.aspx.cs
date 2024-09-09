using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using System.Data;

namespace WebNextivaEsta
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDataCustomers();
        }

        private void LoadDataCustomers()
        {
            CustomerCompanyBF ObjCustomer = new CustomerCompanyBF();
            DataSet ds = new DataSet();
            DDlCustomers.DataSource = ds;
            DDlCustomers.DataBind();
        }
    }
}