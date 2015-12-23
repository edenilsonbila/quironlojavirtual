using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        //Instancia a classe de Contexto do Entity
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> Produtos {
            get { return _context.Produtos; }
        } 

        //Salvar Produto - Alterar Produto

        public void Salvar(Produto produto)
        {
            if (produto.ProdutoID == 0)
            {
                //Salva
                _context.Produtos.Add(produto);
            }
            else
            {
                //Altera
                Produto prod = _context.Produtos.Find(produto.ProdutoID);

                if (prod != null)
                {
                    prod.Nome = produto.Nome;
                    prod.Descricao = produto.Descricao;
                    prod.Preco = produto.Preco;
                    prod.Categoria = produto.Categoria;

                }
            
            }

            _context.SaveChanges();
        }
    }
}
