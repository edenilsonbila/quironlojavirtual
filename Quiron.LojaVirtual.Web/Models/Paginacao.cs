using System;

namespace Quiron.LojaVirtual.Web.Models
{
    public class Paginacao
    {
        public int itensTotal { get; set; }

        public int itensPorPagina { get; set; }

        public int paginaAtual { get; set; }

        //Divide o total de itens pelo total de itens por pagina, para obter o total de paginas
        public int totalPagina
        {
            get
            {
                return (int)Math.Ceiling((decimal)itensTotal / itensPorPagina);
            }

        }

    }
}