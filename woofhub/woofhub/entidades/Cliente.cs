using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WoofHub.Entidades
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public virtual List<Canino> Cachorros { get; set; } = new List<Canino>();
        public virtual List<Felino> Gatos { get; set; } = new List<Felino>();
    }
}
