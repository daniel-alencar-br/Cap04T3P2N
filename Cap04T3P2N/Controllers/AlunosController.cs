using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cap04T3P2N.Dados;

namespace Cap04T3P2N.Controllers
{
    // data source=PC_DO_GAB;   ===>   data source=MAQPESSOAL\sqlexpress;
    // user id=sa;password=sa;  ===>   integrated security=sspi;

    public class AlunosController : Controller
    {
        // site.com.br/alunos/index
        public ActionResult Index()
        {
            return View();
        }

        // site.com.br/alunos/listar
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

        [HttpGet]
        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Models.Alunos Novo)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                AlunosCRUD.NovoAluno(Novo);
                return RedirectToAction("Listar");
            }
            catch (Exception erro)
            {
                ViewBag.Mensagem = erro.Message;
                return View("_Erro");
            }
        }

        private ActionResult BuscarAluno(int Codigo, string Operacao)
        {
            try
            {
                var InfoAluno = AlunosCRUD.BuscarAluno(Codigo);
                return View(Operacao, InfoAluno);
            }
            catch (Exception erro)
            {
                ViewBag.Mensagem = erro.Message;
                return View("_Erro");
            }
        }
        // site.com.br/alunos/alterar/2
        public ActionResult Alterar(int id)
        {
            return BuscarAluno(id, "Alterar");
        }
        // site.com.br/alunos/Pesquisar/2
        public ActionResult Pesquisar(int id)
        {
            return BuscarAluno(id, "Pesquisar");
        }
        // site.com.br/alunos/apagar/2
        public ActionResult Apagar(int id)
        {
            return BuscarAluno(id, "Apagar");
        }

        [HttpPost]
        public ActionResult Alterar(Models.Alunos Aluno)
        {
            try
            {
                AlunosCRUD.AlterarAluno(Aluno);
                return RedirectToAction("Listar");
            }
            catch (Exception erro)
            {
                ViewBag.Mensagem = erro.Message;
                return View("_Erro");
            }
        }

        [HttpPost]
        public ActionResult Apagar(Models.Alunos Aluno)
        {
            try
            {
                AlunosCRUD.DeletarAluno(Aluno);
                return RedirectToAction("Listar");
            }
            catch (Exception erro)
            {
                ViewBag.Mensagem = erro.Message;
                return View("_Erro");
            }
        }
    }
}










