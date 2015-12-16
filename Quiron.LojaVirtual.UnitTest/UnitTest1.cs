using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //Teste Acionar Itens ao Carrinho
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {

            //Arrange - criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste 2"
            };

            Produto produto3 = new Produto
            {
                ProdutoID = 3,
                Nome = "Teste 3"
            };


            //Arrange

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);

            carrinho.AdicionarItem(produto2, 3);

            carrinho.AdicionarItem(produto3, 3);

            //Act
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            //Assert


            Assert.AreEqual(itens.Length, 3);


            Assert.AreEqual(itens[0].Produto, produto1);


            Assert.AreEqual(itens[1].Produto, produto2);


        }

        [TestMethod]
        public void AdicionarProdutoExistenteAoCarrinho()
        {


            Produto produto1 = new Produto
            {
                ProdutoID = 1,
                Nome = "Produto1"
            };

            Produto produto2 = new Produto
            {
                ProdutoID = 2,
                Nome = "Produto2"
            };




            //Arrange

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);

            carrinho.AdicionarItem(produto2, 10);

            //Act
            ItemCarrinho[] resultado = carrinho.ItensCarrinho
                .OrderBy(c => c.Produto.ProdutoID).ToArray();

            //Testa quantos tem no Carrinho
            Assert.AreEqual(resultado.Length, 2);

            //Testa quantidade do produto1
            Assert.AreEqual(resultado[0].Quantidade, 1);

            //Teste a quantidade do produto2
            Assert.AreEqual(resultado[1].Quantidade, 10);
        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste 2"
            };

            //Arrange

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);

            carrinho.AdicionarItem(produto2, 3);

            carrinho.AdicionarItem(produto2, 1);

            carrinho.RemoverItem(produto2);

            //Testa se removeu , ==0
            Assert.AreEqual(carrinho.ItensCarrinho.Where(p => p.Produto == produto2).Count(), 0);

            //
        }

        [TestMethod]
        public void CaulcularValorTotal()
        {
            Produto produto1 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto produto2 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            //Arrange

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);

            carrinho.AdicionarItem(produto2, 1);

            carrinho.AdicionarItem(produto1, 3);

            decimal resulatado = carrinho.ObterValorTotal();

            //Assert
            Assert.AreEqual(resulatado, 450M);

        }

        [TestMethod]
        public void LimparIntesCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste 1",
                Preco = 100M

            };

            Produto produto2 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste 2",
                Preco = 50M
            };


            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);

            carrinho.LimparCarrinho();

            //Assert


            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);
        }
    }
}
