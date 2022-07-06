using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CompromisoAlternativo.Models;


namespace CompromisoAlternativo.Models
{
    public class CRUD_Participantes
    {

        //METODO PARA LISTAR PARTICIPANTES
        public List<Participantes> ListarParticipantes()
        {
            List<Participantes> lista = new List<Participantes>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("PartLeer", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Participantes()
                                {
                                    PART_ID = Convert.ToInt32(dr["PART_ID"]),
                                    PART_RUT = dr["PART_RUT"].ToString(),
                                    PART_NOMBRE = dr["PART_NOMBRE"].ToString(),
                                    PART_FONO = dr["PART_FONO"].ToString(),
                                    PART_EMAIL = dr["PART_EMAIL"].ToString(),
                                    PART_INSTITUCION = dr["PART_INSTITUCION"].ToString()
                                }

                                );
                        }
                    }

                }
            

            }
            catch
            {
                lista = new List<Participantes>();
            }


            return lista;
        }

        public int PartAñadir(Participantes obj, out string Mensaje)
        {
            int idAutoGenerado = 0;

            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("PartAñadir", oconexion);
                    

                    cmd.Parameters.AddWithValue("@PART_RUT", obj.PART_RUT);
                    cmd.Parameters.AddWithValue("@PART_NOMBRE", obj.PART_NOMBRE);
                    cmd.Parameters.AddWithValue("@PART_FONO", obj.PART_FONO);
                    cmd.Parameters.AddWithValue("@PART_EMAIL", obj.PART_EMAIL);
                    cmd.Parameters.AddWithValue("@PART_INSTITUCION", obj.PART_INSTITUCION);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idAutoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch(Exception ex)
            {
                idAutoGenerado = 0;
                Mensaje = ex.Message;
            }
            return idAutoGenerado;
        }
        public bool PartEditar(Participantes obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("PartEditar", oconexion);
                    cmd.Parameters.AddWithValue("@PART_ID", obj.PART_ID);
                    cmd.Parameters.AddWithValue("@PART_RUT", obj.PART_RUT);
                    cmd.Parameters.AddWithValue("@PART_NOMBRE", obj.PART_NOMBRE);
                    cmd.Parameters.AddWithValue("@PART_FONO", obj.PART_FONO);
                    cmd.Parameters.AddWithValue("@PART_EMAIL", obj.PART_EMAIL);
                    cmd.Parameters.AddWithValue("@PART_INSTITUCION", obj.PART_INSTITUCION);
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
        public bool PartEliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top(1) from usuario where PART_ID = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch(Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }



    }
}