using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.HtmlHelpers;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class MenuController : Controller
    {
        private MenuRepositorio _repositorio;


        //Monsta um menu que retorna uma categoria
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterEsportes()
        {
            _repositorio = new MenuRepositorio();

            var cat = _repositorio.ObterCategorias();

            var categoria = from c in cat
                            select new
                            {
                                c.CategoriaDescricao,
                                categoriaDescricaoSeo = c.CategoriaDescricao.ToSeoUrl(),
                                c.CategoriaCodigo
                            };


            return Json(categoria, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterMarcas()
        {
            _repositorio = new MenuRepositorio();

            var listaMarcas = _repositorio.ObterMarcas();

            var marcas = from m in listaMarcas
                         select new
                         {
                             m.MarcaDescricao,
                             MarcaDescricaoSeo = m.MarcaDescricao.ToSeoUrl(),
                             m.MarcaCodigo
                         };

            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesInternacionais()
        {
            _repositorio = new MenuRepositorio();

            var listaMarcas = _repositorio.ObterClubesInternacionais();

            var linhaClubeI = from l in listaMarcas
                         select new
                         {
                             l.LinhaDescricao,
                             LinhaDescricaoSeo = l.LinhaDescricao.ToSeoUrl(),
                             l.LinhaCodigo
                         };

            return Json(linhaClubeI, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesNacionais()
        {
            _repositorio = new MenuRepositorio();

            var listaClubes = _repositorio.ObterClubesNacionais();

            var linhaClubeN = from l in listaClubes
                              select new
                              {
                                  ClubeCodigo = l.LinhaCodigo,
                                  ClubeSeo = l.LinhaDescricao.ToSeoUrl(),
                                  Clube = l.LinhaDescricao
                                  
                              };

            return Json(linhaClubeN, JsonRequestBehavior.AllowGet);
        }


    }
}