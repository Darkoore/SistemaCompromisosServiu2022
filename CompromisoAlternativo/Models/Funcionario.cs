using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompromisoAlternativo.Models
{
    public class Funcionario
    {
        [Required(ErrorMessage = "Please enter Your Username !")]
        [Display(Name = "Usuario")]
        public string FUNC_ID { get; set; }

        [Display(Name = "FUNCIONARIO")]
        public string FUNC_NOMBRE { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese su password !")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string FUNC_UTRABAJO { get; set; }
    }
}