using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
   public class Produto
    {

        [HiddenInput(DisplayValue = false)]
        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "Nome é Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição é Obrigatório")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite um valor")]
        [Range(0.01,double.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal Preco { get; set; }

        public string Categoria { get; set; }

    }
}
