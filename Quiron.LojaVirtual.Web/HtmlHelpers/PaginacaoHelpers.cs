using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;


namespace Quiron.LojaVirtual.Web.HtmlHelpers
{
    public static class PaginacaoHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {
            StringBuilder resultado = new StringBuilder();

            for (int i = 1; i <= paginacao.totalPagina; i++)
            {
                //TagBuilder cria uma nova TAG HTML ex: <div> <a> etc...
                TagBuilder tag = new TagBuilder("a");

                //MargeAttributes atribui um atributo a tag acima, Neste caso seria <a href="paginaUrl"><a> onde paginaUrl recebe o valor do i no form
                tag.MergeAttribute("href",paginaUrl(i));
                //Define um valor para a Tag Atual, No caso o valor que fica entro <>valor<> ex: <a href="paginaUrl">AQUI ENTRA O INNER<a>
                tag.InnerHtml = i.ToString();

                //Verifica qual a pagina atual e muda o css para alterar a cor do botao
                if (i == paginacao.paginaAtual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                //os demais ficam com a cor padrao
                tag.AddCssClass("btn btn-default");

                resultado.Append(tag);
            }
            return MvcHtmlString.Create(resultado.ToString());
        }
    }
}