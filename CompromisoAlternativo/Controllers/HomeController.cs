using CompromisoAlternativo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompromisoAlternativo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        //LOGIN DEL FUNCIONARIO VIA SESSION
        [HttpPost]
        public ActionResult Login(Funcionario lc)
        {
            if (ModelState.IsValid)
            {

                string mainconn = ConfigurationManager.ConnectionStrings["LOCAL_BD"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "select FUNC_ID, FUNC_UTRABAJO from [dbo].[FUNCIONARIO] where FUNC_ID=@FUNC_ID and FUNC_UTRABAJO=@FUNC_UTRABAJO";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                sqlcomm.Parameters.AddWithValue("FUNC_ID", lc.FUNC_ID);
                sqlcomm.Parameters.AddWithValue("FUNC_UTRABAJO", lc.FUNC_UTRABAJO);

                SqlDataReader sdr = sqlcomm.ExecuteReader();
                if (sdr.Read())
                {
                    Session["FUNC_ID"] = lc.FUNC_ID.ToString();
                    return RedirectToAction("Inicio");
                }
                else
                {
                    ViewData["Message"] = "Fallo el inicio de sesion !";
                }
                sqlconn.Close();
            }
            return View();
        }

        //PAGINA DE INICIO DESPUES DEL LOGIN
        public ActionResult Inicio()
        {
            return View();

        }

        //PAGINA DE ACTIVIDAD
        public ActionResult Actividad()
        {
            return View();

        }

        public ActionResult Registro()
        {
            return View();

        }


        //LISTAR PARTICIPANTES
        [HttpGet]
        public JsonResult ListarParticipantes()
        {
            List<Participantes> olista = new List<Participantes>();

            olista = new CN_Participantes().ListarParticipantes();

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        //LISTAR COMPROMISOS
        [HttpGet]
        public JsonResult ListarCompromisos()
        {
            List<Compromisos> olista = new List<Compromisos>();

            olista = new CN_Compromisos().ListarCompromisos();

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }


        //INTENTO DE AGREGAR PARTICIPANTES EXTERNOS
        [HttpPost]
        public JsonResult PartAñadir(Participantes objeto)
        {
            object resultado;
            string mensaje = string.Empty;

          if(objeto.PART_ID == 0)
            {
                resultado = new CN_Participantes().PartAñadir(objeto, out mensaje);
            }
            else
            {
                resultado= new CN_Participantes().PartEditar(objeto, out mensaje);
            }
          
               
                return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }




        [HttpGet]
        public JsonResult ActiLeer()
        {
            List<Actividad> olista = new List<Actividad>();

            olista = new CN_Actividad().ActiLeer();

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ActiAñadir(Actividad objeto)
        {
            object resultado;
            string mensaje = string.Empty;


            resultado = new CN_Actividad().ActiAñadir(objeto, out mensaje);

            //if (objeto.ACTI_ID == 0)
            //{
            //    resultado = new CN_Actividad().ActiAñadir(objeto, out mensaje);
            //}
            //else
            //{
            //    resultado = new CN_Actividad().ActiEditar(objeto, out mensaje);
            //}


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }









        //INTENTO GENERAR ARRAY FUNCIONARIO
        [HttpGet]
        public JsonResult ListarFuncionario()
        {
            List<Funcionario_test> olista = new List<Funcionario_test>();

            olista = new CN_Funcionario().ListarFuncionario();

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }
       

    }
}