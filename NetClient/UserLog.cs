using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetClient
{
    public partial class UserLog : Form
    {
        public UserLog()
        {
            InitializeComponent();
        }

        private void btningreso_Click_1(object sender, EventArgs e)
        {
            MDIMenu Obj = new MDIMenu();
            Obj.Show();
        }
    }
}
