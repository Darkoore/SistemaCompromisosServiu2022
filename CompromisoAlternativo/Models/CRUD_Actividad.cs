using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CompromisoAlternativo.Models
{
    public class CRUD_Actividad
    {
        public List<Actividad> ActiLeer()
        {
            List<Actividad> lista = new List<Actividad>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("ActiLeer", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Actividad()
                                {

                                    ACTI_ID = Convert.ToInt32(dr["ACTI_ID"]),
                                    //ACTI_TIPO = Convert.ToInt32(dr["ACTI_TIPO"]),
                                    TACT_NOMBRE = dr["TACT_NOMBRE"].ToString(),
                                    ACTI_MOTIVO = dr["ACTI_MOTIVO"].ToString(),
                                    ACTI_DESARROLLO = dr["ACTI_DESARROLLO"].ToString()
                                    

                                }

                                );
                        }
                    }

                }


            }
            catch
            {
                lista = new List<Actividad>();
            }


            return lista;
        }



        public int ActiAñadir(Actividad obj, out string Mensaje)
        {
            int idAutoGenerado = 0;

            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("ActiAñadir", oconexion);


                    cmd.Parameters.AddWithValue("@ACTI_TIPO", obj.ACTI_TIPO);
                    cmd.Parameters.AddWithValue("@ACTI_MOTIVO", obj.ACTI_MOTIVO);
                    cmd.Parameters.AddWithValue("@ACTI_DESARROLLO", obj.ACTI_DESARROLLO);
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

        public bool ActiEditar(Actividad obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("PartEditar", oconexion);
                    cmd.Parameters.AddWithValue("@PART_ID", obj.ACTI_ID);
                    cmd.Parameters.AddWithValue("@PART_RUT", obj.ACTI_TIPO);
                    cmd.Parameters.AddWithValue("@PART_NOMBRE", obj.ACTI_MOTIVO);
                    cmd.Parameters.AddWithValue("@PART_FONO", obj.ACTI_DESARROLLO);
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






    }
}