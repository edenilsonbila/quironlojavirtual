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
    public class CategoriasController : Controller
    {

        private CategoriaRepositorio _repositorio;


        //Monsta um menu que retorna uma categoria
     [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "")]
        public JsonResult ObterEsportes()
        {
            _repositorio = new CategoriaRepositorio();

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

    }
}