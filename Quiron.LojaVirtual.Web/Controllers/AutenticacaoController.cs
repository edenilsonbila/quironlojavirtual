using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AdministradoresRepositorio _repositorio;
        
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            return View(new Administrador());
        }

        [HttpPost]
        public ActionResult Login(Administrador administrador, string returnUrl)
        {
           _repositorio  = new AdministradoresRepositorio();

            //Verifica se os capos foram preenchidos
            if (ModelState.IsValid)
            {
                //Consulta no banco se o Administrador Existe
                var adm = _repositorio.ObterAdministrador(administrador);

                //Se existir
                if (adm != null)
                {
                    //Verifica se a senha coincide
                    if (!Equals(administrador.Senha, adm.Senha))
                    {
                        ModelState.AddModelError("", "Senha não confere");
                    }
                    else
                    {
                        //MArca como Autenticado, para poder acessar a pagina de login
                        FormsAuthentication.SetAuthCookie(adm.Login,false);

                        //Valida a Url e retorna
                        if (Url.IsLocalUrl(returnUrl)
                            && returnUrl.Length > 1
                            && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//")
                            && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                    }
                }
                //Se nao existir retorna uma mensagem
                else
                {
                    //Informa ao Modelo um erro personalizado
                    ModelState.AddModelError("","Administrador não existe");
                }
            }
            return View(new Administrador());
        }
    }
}