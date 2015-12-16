using System.Collections.Generic;
using System.Linq;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
   public class Carrinho
    {
        //Cria uma lista da Classe ItemCarrinho e nomeia como _itemCarrinho
        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();

        //Adicionar
       public void AdicionarItem(Produto produto, int quantidade)
       {
            //Instancia a classe ItemCarrinho e atribui o primeiro elemente da lista se nao tiver retorna um valor paddrao
           ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.ProdutoID == produto.ProdutoID);

            //Se o item for igual a nulo
           if (item == null)
           {
                //Adiciona o item a lista _itemCarrinho
               _itemCarrinho.Add(new ItemCarrinho {Produto = produto, Quantidade = quantidade});
           }
           else
           {
                //Caso contrario acrescenta mais um na quantidade
               item.Quantidade += quantidade;
           }
       }

       //Remover
       public void RemoverItem(Produto produto)
       {
            //A funcao remove ao remove a linha inteira e todas as colunas, Cujo produtoID nseja igual ao ProdutoID vindo como paramentro
           _itemCarrinho.RemoveAll(l => l.Produto.ProdutoID == produto.ProdutoID);
       }

       //Obter valor total
       public decimal ObterValorTotal()
       {
            //Soma da coleção todos os produtos, Fazendo preco * quantidade
           return _itemCarrinho.Sum(e => e.Produto.Preco*e.Quantidade);
       }

       //Limpar carrinho
       public void LimparCarrinho()
       {
            _itemCarrinho.Clear();
       }

       //Itens carrinho
       public IEnumerable<ItemCarrinho> ItensCarrinho
       {
           get
           {
               return _itemCarrinho;
           }
       }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
