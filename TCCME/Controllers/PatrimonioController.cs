using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCME.DAO;
using TCCME.Models;

namespace TCCME.Controllers
{
    public class PatrimonioController : Controller
    {

        public ActionResult IndexP()
        {
            PatrimonioDAO dao = new PatrimonioDAO();
            List<Patrimonio> lista = new List<Patrimonio>();           

            lista = dao.getTodosPatrimonios();

            return View(lista);
        }


        public ActionResult Administracao()
        {

            PatrimonioDAO dao = new PatrimonioDAO();
            List<Patrimonio> lista = new List<Patrimonio>();
            lista = dao.getTodosPatrimonios();
            return View(lista);
        }

        public ActionResult Create()
        {

            Usuario usu = (Usuario)Session["usuario"];

            if (usu == null)
                return RedirectToAction("Login", "Moderador");

            CategoriaDAO dao = new CategoriaDAO();
            ViewBag.categorias = dao.getTodasCategorias();

            return View();
        }
        [HttpPost]
        public ActionResult Create(string PatNome, string PatHistoria, string PatEndereco,  string PatFoto1, string PatAcessos)
        {
            PatrimonioDAO dao = new PatrimonioDAO();
            Patrimonio novoPatrimonio = new Patrimonio();

            novoPatrimonio.PatNome = PatNome;
            novoPatrimonio.PatHistoria = PatHistoria;
            novoPatrimonio.PatEndereco = PatEndereco;
            novoPatrimonio.PatFoto1 = PatFoto1;
            novoPatrimonio.PatAcessos = 0;

            dao.AddPatrimonio(novoPatrimonio);

            novoPatrimonio = dao.getTodosPatrimonios().Last();

            HttpFileCollectionBase arquivos = Request.Files;

            if (arquivos.Count > 0)
            {
                string nomeArquivo = novoPatrimonio.PatCodigo + "_" + "Foto1.jpg";
                novoPatrimonio.PatFoto1 = nomeArquivo;
                dao.Alterar(novoPatrimonio);


                string path = Path.Combine(Server.MapPath("~/Uploads/Imagens"), nomeArquivo);
                HttpPostedFileBase file = arquivos[0];
                file.SaveAs(path);
            }

            return RedirectToAction("Administracao");
        }





        public ActionResult Excluir(int? id)

        {
            Usuario usu = (Usuario)Session["usuario"];

            if (usu == null)
                return RedirectToAction("Login", "Moderador");

            PatrimonioDAO dao = new PatrimonioDAO();
            Patrimonio patAtual = dao.getTodosPatrimonios().Find(x => x.PatCodigo == id);

            dao.Remover(patAtual);

            return RedirectToAction("Administracao");

        }





        public ActionResult Edit(int? id)
        {
            Usuario usu = (Usuario)Session["usuario"];

            if (usu == null)
                return RedirectToAction("Login", "Moderador");

            PatrimonioDAO dao = new PatrimonioDAO();
            Patrimonio patAtual = dao.getTodosPatrimonios().Find(x => x.PatCodigo == id);

            return View(patAtual);
        }
        [HttpPost]
        public ActionResult Edit(string PatCodigo, string PatNome, string PatHistoria, string PatEndereco, string PatFoto1)
        {
            PatrimonioDAO dao = new PatrimonioDAO();
            Patrimonio atualPatrimonio = dao.getTodosPatrimonios().Find(x => x.PatCodigo == Convert.ToInt32(PatCodigo));

            atualPatrimonio.PatNome = PatNome;
            atualPatrimonio.PatHistoria = PatHistoria;
            atualPatrimonio.PatEndereco = PatEndereco;
            atualPatrimonio.PatFoto1 = PatFoto1;
            atualPatrimonio.PatAcessos = 0;

            dao.Alterar(atualPatrimonio);

            return RedirectToAction("Administracao");
        }

        public ActionResult Perfil ()
        {
            return View();
        }

	}
}