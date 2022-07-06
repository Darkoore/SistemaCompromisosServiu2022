using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CompromisoAlternativo.Models
{
    public class Actividad
    {
        public int ACTI_ID { get; set; }

        [Display(Name = "TIPO")]
        public int ACTI_TIPO { get; set; }

        [Display(Name = "MOTIVO")]
        public string ACTI_MOTIVO { get; set; }

        [Display(Name = "DESARROLLO")]
        public string ACTI_DESARROLLO { get; set; }


        public string TACT_NOMBRE { get; set; }

    }
}