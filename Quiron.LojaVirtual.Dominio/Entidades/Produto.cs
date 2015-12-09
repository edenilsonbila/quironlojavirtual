using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    class Produto
    {
        public int ProdutoID { get; set; }

        public int Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public string Categoria { get; set; }

    }
}
