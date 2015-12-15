﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;

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

            

            ProdutosViewModel model = new ProdutosViewModel
            {
                //Esta variavel recebera o resultado da query do BD, e sera retornada para a view
                Produtos = _repositorio.Produtos.OrderBy(p => p.Descricao)
                .Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina),

            Paginacao = new Paginacao
                {
                    paginaAtual = pagina,
                    itensPorPagina = ProdutosPorPagina,
                    itensTotal = _repositorio.Produtos.Count()
                }
            };


           

            return View(model);
        }
    }
}