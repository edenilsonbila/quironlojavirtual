using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Web.Infraestrutura
{
    public class CarrinhoModelBinder : IModelBinder
    {

        //Define o Objeto da sessao
        private const string SessionKey = "Carrinho";


        //IModelBinder interface define o método BindModel
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Carrinho carrinho = null;
            if (controllerContext.HttpContext.Session != null)
            {
                carrinho = (Carrinho) controllerContext.HttpContext.Session[SessionKey];
            }

            //Cria o carrinho se nao tiver a sessao
            if (carrinho == null)
            {
                carrinho = new Carrinho();

                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
                }
          
            }

            //Retorna Carrinho
            return carrinho;
        }
    }
}