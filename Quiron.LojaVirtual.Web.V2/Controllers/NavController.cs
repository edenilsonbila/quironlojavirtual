using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Quiron.LojaVirtual.Dominio.Repositorio;
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


        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult TesteMetodoVitrine()
        {
            ProdutoModeloRepositorio repositorio = new ProdutoModeloRepositorio();


            var produtos = repositorio.ObterProdutoVitrine(categoria: "0083", marca: "1106");


            return Json(produtos, JsonRequestBehavior.AllowGet);
        }


        [Route("nav/{categoria}/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarcas(string categoria, string id, string marca)
        {
            ProdutoModeloRepositorio repositorio = new ProdutoModeloRepositorio();

         //   repositorio.ObterProdutoVitrine(linha: id, );

          //  var model = new ProdutosViewModel {Produtos = null};

            return View("Index");
        }








    }
}