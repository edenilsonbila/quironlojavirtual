namespace Quiron.LojaVirtual.Dominio.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Administradores
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Senha { get; set; }

        public DateTime UltimoAcesso { get; set; }
    }
}
