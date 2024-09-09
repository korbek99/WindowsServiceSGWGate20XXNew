using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Business;

using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Entities;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NetClient
{
    public partial class TriggersCamera : Form
    {
        public TriggersCamera()
        {
            InitializeComponent();
            CameraTriggers obt = new CameraTriggers();

            obt.inicializate();
            GetAllttrigs();
        }

        private void GetAllttrigs()
        {
            StringBuilder sbAlarmMsg = new StringBuilder("AlarmMsg-", 128);

            sbAlarmMsg.Append(DateTime.Now.ToLocalTime().ToString());



            lbAlarmlistBox.Items.Insert(0, sbAlarmMsg.ToString());

        }

    }
}
