using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsServiceNextiva.Entities
{
   public class Customer
    {
           public int CustomerCompanyID { get; set; }
           public string CustomerCompanyIDE { get; set; }
           public string CustomerCompanyName  {get; set;}
           public string CustomerCompanyDir  {get; set;}
           public string CustomerCompanyPhone  {get; set;}
           public string CustomerCompanyCelPhone  {get; set;}
           public string CustomerCompanyEmail  {get; set;}
           public string CustomerCompanyFax  {get; set;}
           public string  CustomerCompanyWebSite {get; set;}
           public int CiudadID {get; set;}
           public DateTime CustomerCompanyDateIng {get; set;}
           public int CustomerCompanyState {get; set;}
           public string CustomerCompanyShortName {get; set;}
    }
}
