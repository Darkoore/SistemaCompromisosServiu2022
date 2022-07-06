using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace CompromisoAlternativo.Models
{
    public class CRUD_Funcionario
    {
        public List<Funcionario_test> ListarFuncionario()
        {
            List<Funcionario_test> lista = new List<Funcionario_test>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("FuncLeer", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Funcionario_test()
                                {
                                    FUNC_NOMBRE = dr["FUNC_NOMBRE"].ToString(),
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Funcionario_test>();
            }
            return lista;
        }
    }
}