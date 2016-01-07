using System;
using System.Collections.Generic;
using System.EnterpriseServices;
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

        private ProdutoModeloRepositorio _repositorio;
        private ProdutosViewModel _model;

        // GET: Nav
        public ActionResult Index()
        {
            _repositorio = new ProdutoModeloRepositorio();

            var produtos = _repositorio.ObterProdutoVitrine();

            _model = new ProdutosViewModel { Produtos = produtos};
            



            return View(_model);
        }


        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult TesteMetodoVitrine()
        {
           _repositorio = new ProdutoModeloRepositorio();


            var produtos = _repositorio.ObterProdutoVitrine(categoria: "0083", marca: "1106");


            return Json(produtos, JsonRequestBehavior.AllowGet);
        }


        //Obtem os produtos pela merca, Faz uma query pela merca obtida pelo parametro da rota
        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarcas(string id, string marca)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutoVitrine(marca: id);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = marca };
            return View("Navegacao", _model);
        }


        [Route("nav/times/{id}/{clube}")]
        public ActionResult ObterProdutosPorClubes(string id, string clube)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutoVitrine(linha: id);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = clube };
            return View("Navegacao", _model);
        }



        [Route("nav/genero/{id}/{genero}")]
        public ActionResult ObterProdutosPorGenero(string id, string genero)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutoVitrine(genero: id);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = genero };
            return View("Navegacao", _model);
        }









    }
}