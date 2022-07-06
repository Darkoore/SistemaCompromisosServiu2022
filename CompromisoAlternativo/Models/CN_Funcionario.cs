using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompromisoAlternativo.Models
{
    public class CN_Funcionario
    {
        private CRUD_Funcionario objObjeto = new CRUD_Funcionario();
        public List<Funcionario_test> ListarFuncionario()
        {
            return objObjeto.ListarFuncionario();
        }

    }
}