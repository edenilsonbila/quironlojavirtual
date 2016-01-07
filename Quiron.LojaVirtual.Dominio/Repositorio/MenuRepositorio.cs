using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class MenuRepositorio
    {
        private readonly  EfDbContext _context = new EfDbContext();


        public IEnumerable<Categoria> ObterCategorias()
        {
            return _context.Categorias.OrderBy(c => c.CategoriaDescricao);
        }

        public IEnumerable<MarcaVitrine> ObterMarcas()
        {
            return _context.MarcaVitrine.OrderBy(c => c.MarcaDescricao);
        }

        public IEnumerable<ClubesNacionais> ObterClubesNacionais()
        {
            return _context.ClubesNacionais.OrderBy(c => c.LinhaDescricao);
        }

        public IEnumerable<ClubesInternacionais> ObterClubesInternacionais()
        {
            return _context.ClubesInternacionais.OrderBy(c => c.LinhaDescricao);
        }

        public IEnumerable<Genero> ObterGeneros()
        {
            return _context.Generos.OrderBy(g => g.GeneroDescricao);
        }

        public IEnumerable<Grupo> ObterGrupos()
        {
            return _context.Grupos.OrderBy(g => g.GrupoDescricao);
        }

    }
}
