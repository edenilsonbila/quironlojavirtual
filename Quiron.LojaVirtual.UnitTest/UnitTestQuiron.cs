using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        public void take()
        {
        }
    }
}
