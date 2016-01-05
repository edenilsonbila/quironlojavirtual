﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{

    

    //Esta classe herda a Classe DbContext
    public class EfDbContext : DbContext
    {
        //Mapeia a classe de Entidade produtos para ser usada com o Banco de Dados e o Entity
       public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

       public DbSet<Administrador> Administradores { get; set; }

        //Desabilita a Pluralização de Tabelas do BD
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EfDbContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Apelida a tabela do com o nome da Classe, O Entity Procurará a tabela como Administradores ao invés de Administrador q seria o padrao
            modelBuilder.Entity<Administrador>().ToTable("Administradores");
        }
    }
}
