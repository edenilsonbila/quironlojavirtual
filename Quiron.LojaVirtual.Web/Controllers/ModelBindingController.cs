using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ModelBindingController : Controller
    {
        // GET: ModelBinding
        public ActionResult Index()
        {
            return View(new Produto());
        }

        [HttpPost]
        public ActionResult Editar(Produto prod)
        {
            var produto = new Produto();

            string teste = prod.Nome;
            decimal preco = prod.Preco;


            produto.Nome = Request.Form["Nome"];
            produto.Preco = Decimal.Parse(Request.Form["Preco"]);

            



            return RedirectToAction("Index");
        }
    }
}