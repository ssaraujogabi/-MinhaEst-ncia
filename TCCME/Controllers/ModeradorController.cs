using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCME.DAO;
using TCCME.Models;

namespace TCCME.Controllers
{
    public class ModeradorController : Controller
    {
        //
        // GET: /Moderador/

        public ActionResult Login()
        {
            Usuario usu = (Usuario)Session["usuario"];

            if (usu != null)
                return RedirectToAction("Index");

            return View();

        }




        [HttpPost]
        public ActionResult Login(string login, string senha)
        {
                    
             bdTCCEntities banco = new bdTCCEntities();

             Usuario usuario = banco.Usuario.ToList().Where(u => u.UsuLogin.Equals(login)
             && u.UsuSenha.Equals(senha)).FirstOrDefault();

             if (usuario != null)
             {
                 Session["usuario"] = usuario;
                 return RedirectToAction("Administracao","Patrimonio");
             }
             else
             {
                 ViewBag.mensagem = "Usuário ou senha incorretos!";
                 return View();
             }
         }
         

        }
    }
