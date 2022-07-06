using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CompromisoAlternativo.Models
{
    public class ConexionBD
    {
        public static string cn = ConfigurationManager.ConnectionStrings["LOCAL_BD"].ToString();
    }
}