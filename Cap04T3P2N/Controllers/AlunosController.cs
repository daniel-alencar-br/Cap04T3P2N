using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cap04T3P2N.Dados;

namespace Cap04T3P2N.Controllers
{
    public class AlunosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            try
            {
                return View(AlunosCRUD.ListarAlunos());
            }
            catch (Exception erro)
            {
                ViewBag.Mensagem = erro.Message;
                return View("_Erro");
            }
        }
    }
}







