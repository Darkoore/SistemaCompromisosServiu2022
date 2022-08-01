using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompromisoAlternativo.Models
{
    public class Compromisos
    {
        public int COMP_ID { get; set; }

        [Display(Name = "TAREA")]
        [Required(ErrorMessage = "Tarea es requerido.")]
        public string COMP_TAREA { get; set; }

        [Display(Name = "PLAZO")]
        [Required(ErrorMessage = "Plazo es requerido.")]
        public string COMP_PLAZO { get; set; }

        [Display(Name = "RESPONSABLE")]
        [Required(ErrorMessage = "Responsable es requerido.")]
        public string COMP_FUNCIONARIO_RESP { get; set; }
    }
}