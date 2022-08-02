using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CompromisoAlternativo.Models
{
    public class CRUD_Compromisos
    {
        //METODO PARA LISTAR COMPROMISOS
        public List<Compromisos> ListarCompromisos()
        {
            List<Compromisos> lista = new List<Compromisos>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("CompromisosLeer", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Compromisos()
                                {
                                    COMP_ID = Convert.ToInt32(dr["COMP_ID"]),
                                    COMP_TAREA = dr["COMP_TAREA"].ToString(),
                                    COMP_PLAZO = dr["COMP_PLAZO"].ToString(),
                                    COMP_FUNCIONARIO_RESP= dr["COMP_FUNCIONARIO_RESP"].ToString()
                                }

                                );
                        }
                    }

                }


            }
            catch
            {
                lista = new List<Compromisos>();
            }


            return lista;
        }

        public int CompromisosAñadir(Compromisos obj, out string Mensaje)
        {
            int idAutoGenerado = 0;

            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("CompromisosAñadir", oconexion);

                    cmd.Parameters.AddWithValue("@COMP_TAREA", obj.COMP_TAREA);
                    cmd.Parameters.AddWithValue("@COMP_PLAZO", obj.COMP_PLAZO);
                    cmd.Parameters.AddWithValue("@COMP_FUNCIONARIO_RESP", obj.COMP_FUNCIONARIO_RESP);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idAutoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idAutoGenerado = 0;
                Mensaje = ex.Message;
            }
            return idAutoGenerado;
        }
        public bool CompromisosEditar(Compromisos obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("PartEditar", oconexion);
                    cmd.Parameters.AddWithValue("@COMP_ID", obj.COMP_ID);
                    cmd.Parameters.AddWithValue("@COMP_TAREA", obj.COMP_TAREA);
                    cmd.Parameters.AddWithValue("@COMP_PLAZO", obj.COMP_PLAZO);
                    cmd.Parameters.AddWithValue("@COMP_FUNCIONARIO_RESP", obj.COMP_FUNCIONARIO_RESP);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;

            }
            return resultado;
        }
        public bool CompromisosEliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top(1) from usuario where COMP_ID = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }



    }
}