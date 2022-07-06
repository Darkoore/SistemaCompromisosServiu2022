using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompromisoAlternativo.Models
{
    public class Participantes
    {

        public int PART_ID { get; set; }

        [Display(Name = "RUT")]
        public string PART_RUT { get; set; }

        [Display(Name = "NOMBRE")]
        [Required(ErrorMessage = "Name is required.")]
        public string PART_NOMBRE { get; set; }

        [Display(Name = "FONO")]
        [Required(ErrorMessage = "Fono is required.")]
        public string PART_FONO { get; set; }

        [Display(Name = "EMAIL")]
        [Required(ErrorMessage = "Email is required.")]
        public string PART_EMAIL { get; set; }

        [Display(Name = "INSTITUCION")]
        [Required(ErrorMessage = "Institucion is required.")]
        public string PART_INSTITUCION { get; set; }
    }
}