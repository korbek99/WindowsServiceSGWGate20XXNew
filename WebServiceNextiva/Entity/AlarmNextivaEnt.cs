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

namespace WebServiceNextiva.Entity
{
    public class AlarmNextivaEnt
    {

        public int AlarmSentChannel { get; set; }
        public DateTime AlarmSentDateIng { get; set; }
        public string AlarmSentDescription { get; set; }
        public int AlarmSentEstado { get; set; }
        public int AlarmSentIDE { get; set; }
        public string AlarmSentrctTarget { get; set; }
        public string AlarmSentRuleDescrip { get; set; }
        public int AlarmSentRuleID { get; set; }
        public int AlarmSentState { get; set; }
        public int AlarmSentTargetDirection { get; set; }
        public int AlarmSentTargetID { get; set; }
        public int AlarmSentTargetSpeed { get; set; }
        public int AlarmSentTargetType { get; set; }
        public int AlarmSentventType { get; set; }
    }
}
