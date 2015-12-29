using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        public RedirectToRouteResult Adicionar(Carrinho carrinho,int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoID == produtoId);

            if (produto != null)
            {
               carrinho.AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        //private Carrinho ObterCarrinho()
        //{
        //    Carrinho carrinho = (Carrinho)Session["Carrinho"];

        //    if (carrinho == null)
        //    {
        //        carrinho = new Carrinho();
        //        Session["Carrinho"] = carrinho;
        //    }

        //    return carrinho;
        //}

        public RedirectToRouteResult Remover(Carrinho carrinho, int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoID == produtoId);

            if (produto != null)
            {
                carrinho.RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }



        public ViewResult Index(Carrinho carrinho,string returnurl)
        {

            return View(new CarrinhoViewModel
            {
                Carrinho = carrinho,
                ReturnUrl = returnurl
            });
        }

        public PartialViewResult Resumo(Carrinho carrinho)
        {
            return PartialView(carrinho);
        }


        public ViewResult FecharPedido()
        {

            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Carrinho carrinho,Pedido pedido)
        {

            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")
            };

            EmailPedido emailPedido = new EmailPedido(email);

            if (!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("","Carrinho vazio");
            }

            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);
            }
        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }
    }
}