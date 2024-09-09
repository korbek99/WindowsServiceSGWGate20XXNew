using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsServiceNextiva.Entities
{
   public  class AlarmNextiva
    {

      public   int  AlarmNexSentChannel { get; set; }
      public   int AlarmNexSentCustCompanyID { get; set; }
      public   string AlarmNexSentDateIng { get; set; }
      public   string AlarmNexSentDescription { get; set; }
      public   int AlarmNexSentEstado { get; set; }
      public   string AlarmNexSentIDE { get; set; }
      public   string AlarmNexSentrctTarget { get; set; }
      public   string AlarmNexSentRuleDescrip { get; set; }
      public   int AlarmNexSentRuleID { get; set; }
      public   int AlarmNexSentState { get; set; }
      public   int AlarmNexSentTargetDirection { get; set; }
      public   int AlarmNexSentTargetID { get; set; }
      public   int AlarmNexSentTargetSpeed  { get; set; }
      public   int AlarmNexSentTargetType  { get; set; }
      public   int AlarmNexSentventType { get; set; }
      public int AlarmNexSentStateTransac { get; set; }
    }
}
