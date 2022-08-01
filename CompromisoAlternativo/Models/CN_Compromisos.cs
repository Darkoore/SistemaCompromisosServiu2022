using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompromisoAlternativo.Models
{
    public class CN_Compromisos
    {
        private CRUD_Compromisos objObjeto = new CRUD_Compromisos();

        public List<Compromisos> ListarCompromisos()
        {
            return objObjeto.ListarCompromisos();
        }

        public int CompromisosAñadir(Compromisos obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.COMP_TAREA) || string.IsNullOrWhiteSpace(obj.COMP_TAREA))
            {
                Mensaje = "El Rut no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.COMP_PLAZO) || string.IsNullOrWhiteSpace(obj.COMP_PLAZO))
            {
                Mensaje = "El nombre no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.COMP_FUNCIONARIO_RESP) || string.IsNullOrWhiteSpace(obj.COMP_FUNCIONARIO_RESP))
            {
                Mensaje = "Debe ingresar una institucion";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objObjeto.CompromisosAñadir(obj, out Mensaje);
            }
            else
            {
                return 0;
            }



        }

        public bool CompromisosEditar(Compromisos obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.COMP_TAREA) || string.IsNullOrWhiteSpace(obj.COMP_TAREA))
            {
                Mensaje = "La tarea no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.COMP_PLAZO) || string.IsNullOrWhiteSpace(obj.COMP_PLAZO))
            {
                Mensaje = "El plazo no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.COMP_FUNCIONARIO_RESP) || string.IsNullOrWhiteSpace(obj.COMP_FUNCIONARIO_RESP))
            {
                Mensaje = "Debe ingresar un responsable";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objObjeto.CompromisosEditar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool CompromisosEliminar(int id, out string Mensaje)
        {
            return objObjeto.CompromisosEliminar(id, out Mensaje);
        }


    }
}