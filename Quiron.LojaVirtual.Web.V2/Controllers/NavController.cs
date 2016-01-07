using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.V2.Models;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        public ActionResult Index()
        {
            return View();
        }

        [Route("nav/{categoria}/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarcas(string categoria, string id, string marca)
        {
            var model = new ProdutosViewModel {Produtos = null};

            return View("Index", model);
        }








    }
}