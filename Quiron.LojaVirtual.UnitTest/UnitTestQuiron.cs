using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;
using Quiron.LojaVirtual.Web.HtmlHelpers;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestQuiron
    {
        [TestMethod]
        public void Skip()
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var resultado = from num in numeros.Take(5).Skip(2) select num;


        }

        [TestMethod]
        public void take()
        {
        }

        [TestMethod]
        public void testaPaginacao()
        {

            //Arrange ( Variaveus e atributos necessario para o Teste)
            HtmlHelper html = null;
            Paginacao paginacao = new Paginacao
            {
                paginaAtual = 2,
                itensPorPagina = 10,
                itensTotal = 28
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act (Acao, executa o metdo e testa)
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            //Assert
            Assert.AreEqual(
                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()

                            );
        }

    }
}
