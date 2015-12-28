using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Areas.Administrativo.Controllers
{

    [Authorize]
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        // GET: Administrativo/Produto
        public ActionResult Index()
        {
            _repositorio = new ProdutosRepositorio();

            var produtos = _repositorio.Produtos;
            return View(produtos);
        }

        public ViewResult Alterar(int produtoId)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoID == produtoId);

                return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                //Se a imagem nao for nula convert ela em Bits e salva no banco de Dados
                if (image != null)
                {
                    produto.ImagemMimeType = image.ContentType;
                    produto.Imagem = new byte[image.ContentLength];
                    image.InputStream.Read(produto.Imagem, 0, image.ContentLength);
                }

                _repositorio = new ProdutosRepositorio();
                _repositorio.Salvar(produto);

                TempData["mensagem"] = string.Format("{0} foi salvo com sucesso",produto.Nome);
                return RedirectToAction("Index");
            }
            return View(produto);
        }


        public ViewResult NovoProduto()
        {
            return View("Alterar", new Produto());
        }


        //Busca a imagem e convert
        public FileContentResult ObterImagem(int produtoId)
        {
            //Instancia o repositorio
            _repositorio = new ProdutosRepositorio();

            //Busca no banco de dados
            Produto prod = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoID == produtoId);

            //Verifica se retornou nulo, Se nao retorna a imagem
            if (prod != null)
            {
                return File(prod.Imagem, prod.ImagemMimeType);
            }

            return null;
        }


        [HttpPost]
        public JsonResult Excluir(int produtoId)
        {
            string mensagem = string.Empty;
                
            _repositorio = new ProdutosRepositorio();

            Produto prod = _repositorio.Excluir(produtoId);

            if (prod != null)
            {
                mensagem = string.Format("{0} excluido com sucesso", prod.Nome);
               
            }
            return Json(mensagem,JsonRequestBehavior.AllowGet);
        }


    }
}