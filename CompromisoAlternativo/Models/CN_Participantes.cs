using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace CompromisoAlternativo.Models
{
    public class CN_Participantes
    {
        private CRUD_Participantes objObjeto = new CRUD_Participantes();

        public List<Participantes> ListarParticipantes()
        {
            return objObjeto.ListarParticipantes();
        }

    public int PartAñadir(Participantes obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.PART_RUT) || string.IsNullOrWhiteSpace(obj.PART_RUT))
            {
                Mensaje = "El Rut no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.PART_NOMBRE) || string.IsNullOrWhiteSpace(obj.PART_NOMBRE))
            {
                Mensaje = "El nombre no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.PART_INSTITUCION) || string.IsNullOrWhiteSpace(obj.PART_INSTITUCION))
            {
                Mensaje = "Debe ingresar una institucion";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objObjeto.PartAñadir(obj, out Mensaje);
            }
            else
            {
                return 0;
            }


            
        }

        public bool PartEditar(Participantes obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.PART_RUT) || string.IsNullOrWhiteSpace(obj.PART_RUT))
            {
                Mensaje = "El Rut no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.PART_NOMBRE) || string.IsNullOrWhiteSpace(obj.PART_NOMBRE))
            {
                Mensaje = "El nombre no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.PART_INSTITUCION) || string.IsNullOrWhiteSpace(obj.PART_INSTITUCION))
            {
                Mensaje = "Debe ingresar una institucion";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objObjeto.PartEditar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool PartEliminar(int id, out string Mensaje)
        {
            return objObjeto.PartEliminar(id, out Mensaje);
        }


    }
}