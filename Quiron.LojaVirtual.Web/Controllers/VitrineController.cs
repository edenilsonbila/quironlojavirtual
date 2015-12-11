using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        //Cria o repositorio de produtos, Isto é uma copia do BD, em cima deste é feito as queryes
        private ProdutosRepositorio _repositorio;

        int ProdutosPorPagina = 10;

        // GET: Vitrine
        public ActionResult ListaProdutos(int pagina = 1)
        {
            //Atribui as info inicias ao Repositorio
            _repositorio = new ProdutosRepositorio();

            //Esta variavel recebera o resultado da query do BD, e sera retornada para a view
            var produtos = _repositorio.Produtos.OrderBy(p => p.Descricao)
                .Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina);

            return View(produtos);
        }
    }
}