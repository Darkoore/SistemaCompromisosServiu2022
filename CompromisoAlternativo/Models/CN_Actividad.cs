using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompromisoAlternativo.Models
{
    public class CN_Actividad
    {
        
        private CRUD_Actividad objObjeto = new CRUD_Actividad();

        public List<Actividad> ActiLeer()
        {
            return objObjeto.ActiLeer();
        }


        public int ActiAñadir(Actividad obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.ACTI_TIPO == 0)
            {
                Mensaje = "Seleccione un tipo de actividad";
            }
            else if (string.IsNullOrEmpty(obj.ACTI_MOTIVO) || string.IsNullOrWhiteSpace(obj.ACTI_MOTIVO))
            {
                Mensaje = "Debe ingresar un motivo";
            }
            else if (string.IsNullOrEmpty(obj.ACTI_DESARROLLO) || string.IsNullOrWhiteSpace(obj.ACTI_DESARROLLO))
            {
                Mensaje = "Debe ingresar un desarrollo";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objObjeto.ActiAñadir(obj, out Mensaje);
            }
            else
            {
                return 0;
            }



        }
        public bool ActiEditar(Actividad obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.ACTI_TIPO == 0)
            {
                Mensaje = "Seleccione un tipo de actividad";
            }
            else if (string.IsNullOrEmpty(obj.ACTI_MOTIVO) || string.IsNullOrWhiteSpace(obj.ACTI_MOTIVO))
            {
                Mensaje = "Debe ingresar un motivo";
            }
            else if (string.IsNullOrEmpty(obj.ACTI_DESARROLLO) || string.IsNullOrWhiteSpace(obj.ACTI_DESARROLLO))
            {
                Mensaje = "Debe ingresar un desarrollo";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objObjeto.ActiEditar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }
    }
}